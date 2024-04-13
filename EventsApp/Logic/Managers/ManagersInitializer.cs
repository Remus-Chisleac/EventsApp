using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using EventsApp.Logic.Attributes;

namespace EventsApp.Logic.Managers
{
    public static class ManagersInitializer
    { 
        public static void Initialize()
        {
            // Setting up connections
            //CSVAdapter<UserInfo> usersCSVAdapter = new CSVAdapter<UserInfo>("UsersCSV");
            //CSVAdapter<Entities.EventInfo> eventsCSVAdapter = new CSVAdapter<Entities.EventInfo>("EventsCSV");
            //usersCSVAdapter.Connect();
            //eventsCSVAdapter.Connect();
            GenerateLocalDatabase();

            DataBaseAdapter<UserInfo> usersAdapter = new DataBaseAdapter<UserInfo>("UsersDB");
            DataBaseAdapter<Entities.EventInfo> eventsAdapter = new DataBaseAdapter<Entities.EventInfo>("EventsDB");
            DataBaseAdapter<ReportInfo> reportsAdapter = new DataBaseAdapter<ReportInfo>("ReportsDB");
            DataBaseAdapter<ReviewInfo> reviewsAdapter = new DataBaseAdapter<ReviewInfo>("ReviewsDB");
            DataBaseAdapter<AdminInfo> adminsAdapter = new DataBaseAdapter<AdminInfo>("AdminsDB");
            DataBaseAdapter<UserEventRelationInfo> userEventRelationsAdapter = new DataBaseAdapter<UserEventRelationInfo>("UserEventRelationsDB");

            usersAdapter.Connect();
            eventsAdapter.Connect();
            reportsAdapter.Connect();
            reviewsAdapter.Connect();
            adminsAdapter.Connect();
            userEventRelationsAdapter.Connect();

            UsersManager.Initialize(usersAdapter, adminsAdapter, userEventRelationsAdapter);
            EventsManager.Initialize(eventsAdapter, userEventRelationsAdapter);
            ReportsManager.Initialize(reportsAdapter);
            ReviewsManager.Initialize(reviewsAdapter);
        }

        public static void GenerateLocalDatabase()
        {
            string dbPath = AppDataInfo.ValidatePath("EventsDB.mdf");
            string logPath = AppDataInfo.ValidatePath("EventsDB.ldf");

            // Construct the connection string
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(localdb)\\MSSQLLocalDB"; // or specify your SQL Server instance
            builder.InitialCatalog = "master";
            builder.IntegratedSecurity = false; // Use Windows Authentication
            builder.TrustServerCertificate = true; // Trust the server certificate
            string connectionString = builder.ConnectionString;

            // SQL command to create the database
            string dropDatabaseQuery = "DROP DATABASE IF EXISTS EventsDB";
            string createDatabaseQuery = $"CREATE DATABASE EventsDB ON PRIMARY (NAME = EventsDB, FILENAME = '{dbPath}')";

            // Drop the database if it already exists
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(dropDatabaseQuery, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(createDatabaseQuery, connection);
                try
                {
                    // Open the connection and execute the command
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Already exists
                    Console.WriteLine(ex.Message);
                }
            }

            string namespaceName = "EventsApp.Logic.Entities";

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            var structsInNamespace = types
                .Where(t => t.Namespace == namespaceName && t.IsValueType && !t.IsEnum)
                .ToList();

            foreach (var structType in structsInNamespace)
            {
                string tableName = structType.GetCustomAttribute<TableAttribute>().TableName;
                List<string> columns = new List<string>();

                // Get only structs with no consts or enums
                foreach (var field in structType.GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    bool primaryKey = field.GetCustomAttribute<PrimaryKeyAttribute>() != null;  
                    string columnName = field.Name;
                    string columnType = GetFieldType(field.FieldType);

                    string column = $"{columnName} {columnType} {(primaryKey ? "PRIMARY KEY" : "")}";
                    columns.Add(column);
                }

                string createTableQuery = $"CREATE TABLE {tableName} ({string.Join(", ", columns)})";

            }
        }

        private static string GetFieldType(Type fieldType)
        {
            if (fieldType == typeof(int))
            {
                return "INT";
            }
            else if (fieldType == typeof(string))
            {
                return "NVARCHAR(255)";
            }
            else if (fieldType == typeof(DateTime))
            {
                return "DATETIME";
            }
            else if (fieldType == typeof(float))
            {
                return "FLOAT";
            }
            else if (fieldType == typeof(bool))
            {
                return "BIT";
            }
            else
            {
                return "NVARCHAR(255)";
            }
        }
    }
}
