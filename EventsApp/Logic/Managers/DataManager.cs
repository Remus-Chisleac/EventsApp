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
    public class DataManager
    {
        private static DataManager _instance;

        public static DataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                }

                return _instance;
            }
        }
    
        public DataManager()
        {
            // Setting up connections
            CSVAdapter<UserInfo> usersCSVAdapter = new CSVAdapter<UserInfo>("UsersCSV");
            CSVAdapter<Entities.EventInfo> eventsCSVAdapter = new CSVAdapter<Entities.EventInfo>("EventsCSV");

            usersCSVAdapter.Connect();
            eventsCSVAdapter.Connect();
        }

    }
}
