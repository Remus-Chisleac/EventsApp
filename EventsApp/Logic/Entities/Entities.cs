using EventsApp.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Entities
{
    [System.Serializable]
    public struct UserInfo
    {
        [PrimaryKey("userID")] public Guid GUID;
        public string name;
        public string email;
        public string password;

        public UserInfo(Guid guid, string name, string email, string password)
        {
            GUID = guid;
            this.name = name;
            this.email = email;
            this.password = password;
        }

        public UserInfo(string name, string email, string password)
        {
            GUID = Guid.NewGuid();
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }

    [System.Serializable]
    public struct EventInfo
    {
        [PrimaryKey("eventID")] public Guid GUID;
        public string name;
        public string description;
        public DateTime date;
        public string location;
        public Guid organizer;

        public EventInfo(string name, string description, DateTime date, string location, Guid organizer)
        {
            GUID = Guid.NewGuid();
            this.name = name;
            this.description = description;
            this.date = date;
            this.location = location;
            this.organizer = organizer;
        }
    }
}
