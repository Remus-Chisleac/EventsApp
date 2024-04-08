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
        [PrimaryKey("userID")] public string GUID;
        [PrimaryKey("name")] public string name;
        public string email;
        public string password;

        public UserInfo(string guid, string name, string email, string password)
        {
            GUID = guid;
            this.name = name;
            this.email = email;
            this.password = password;
        }

        public UserInfo(string name, string email, string password)
        {
            GUID = Guid.NewGuid().ToString();
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }

    public struct EventInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }

        public EventInfo(string name, string description, DateTime date, string location, string organizer)
        {
            Name = name;
            Description = description;
            Date = date;
            Location = location;
            Organizer = organizer;
        }
    }
}
