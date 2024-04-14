using EventsApp.Logic.Entities;
using EventsApp.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.ViewEntities
{
    public class EventCard
    {
        public Guid EventGUID { get; set; }
        public string OrganizerName { get; set; }
        public string Title { get; set; }
        public string Categories { get; set; }
        public string Location { get; set; }
        public int MaxParticipants { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string BannerURL { get; set; }
        public string LogoURL { get; set; }
        public int AgeLimit { get; set; }
        public float EntryFee { get; set; }

        public EventCard(EventInfo evt)
        {
            EventGUID = evt.GUID;
            OrganizerName = UsersManager.GetUser(evt.organizerGUID).name;
            Title = evt.eventName;
            Categories = evt.categories;
            Location = evt.location;
            MaxParticipants = evt.maxParticipants;
            Description = evt.description;
            StartDate = evt.startDate.ToString();
            EndDate = evt.endDate.ToString();
            BannerURL = evt.bannerURL;
            LogoURL = evt.logoURL;
            AgeLimit = evt.ageLimit;
            EntryFee = evt.entryFee;
        }
    }
}
