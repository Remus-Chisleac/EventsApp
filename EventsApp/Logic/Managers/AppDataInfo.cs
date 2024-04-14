using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Managers
{
    public static class AppDataInfo
    {
        public const string AppFolder = "EventsApp";
        public const string UsersCSV = "UsersCSV.csv";
        public const string EventsCSV = "EventsCSV.csv";
        public const string DataBase = "Events.mdf";
        public static string PersistentDataPath => FileSystem.Current.AppDataDirectory;

        public static string ValidatePath(string path)
        {
            // Data\UsersCSV.csv will be converted to C:\Users\{username}\AppData\Roaming\EventsApp\Data\UsersCSV.csv
            // log.txt will be converted to C:\Users\{username}\AppData\Roaming\EventsApp\log.txt
            string dataFolder = FileSystem.Current.AppDataDirectory;

            // Check if path is already a full path
            if(!path.Contains(dataFolder))
            {
                path = Path.Combine(dataFolder, path);
            }

            // Create folders if they don't exist
            string folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return path;
        }
    }
}
