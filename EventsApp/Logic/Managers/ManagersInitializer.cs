using EventsApp.Logic.Adapters;
using EventsApp.Logic.Attributes;
using EventsApp.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
