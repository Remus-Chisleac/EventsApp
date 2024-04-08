using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Managers
{
    public class EventsManager
    {
        private DataAdapter<EventInfo> _adapter;

        private static EventsManager _instance;

        public static EventsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventsManager(new CSVAdapter<EventInfo>("EventsCSV"));
                }

                return _instance;
            }
        }
    
        public EventsManager(DataAdapter<EventInfo> adapter)
        {
            _adapter = adapter;
        }
    }
}
