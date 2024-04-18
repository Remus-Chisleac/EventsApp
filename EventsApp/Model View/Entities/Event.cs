using EventsApp.Logic.Entities;
using EventsApp.Logic.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Model_View.Entities
{
    public class Event : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string? GUID { get; set; }
        public string? Picture { get; set; }
        public string? Organizer { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
        public string? Location { get; set; }
        public string StartDate { get; set; }
        public string? Price { get; set; }
        public int NoOfParticipants { get; set; }

        public string HostInfoString
        {
            get
            {
                return "Hosted by " + Organizer;
            }
        }

        public string PriceInfoString
        {
            get
            {
                return Price + " EUR";
            }
        }

        public string ParticipantsInfoString 
        {
            get
            {
                return $"{EventsManager.GetNumberOfParticipants(Guid.Parse(GUID))} / {NoOfParticipants.ToString()}";
            }
        }

        public string DateInfoString
        {
            get
            {
                return StartDate;
            }
        }

        private bool _interested;

        public string InterestedStar
        {
            get
            {
                if (_interested)
                {
                    return "star_filled.png";
                }
                else
                {
                    return "star_empty.png";
                }
            }
        }

        public void UpdateInterestedStatus()
        {
            if (UsersManager.IsInterested(AppStateManager.currentUserGUID, Guid.Parse(GUID)) ||
                UsersManager.IsGoing(AppStateManager.currentUserGUID, Guid.Parse(GUID)))
            {
                _interested = true;
            }
            else
            {
                _interested = false;
            }
            OnPropertyChanged(nameof(InterestedStar));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public string GetStar()
        {
            if (_interested)
            {
                return "star_filled.png";
            }
            else
            {
                return "star_empty.png";
            }
        }

        public Event(string GUID, string picture, string organizer, string name, string description, string location, string date, string price, int participants)
        {
            this.GUID = GUID;
            Picture = picture;
            Organizer = organizer;
            Name = name;
            Description = description;
            Location = location;
            StartDate = date;
            Price = price;
            NoOfParticipants = participants;
        }

        public Event(EventInfo eventInfo)
        {
            GUID = eventInfo.GUID.ToString();
            Picture = eventInfo.bannerURL;
            Organizer = UsersManager.GetUser(eventInfo.organizerGUID).name;
            Name = eventInfo.eventName;
            Description = eventInfo.description;
            Location = eventInfo.location;
            StartDate = eventInfo.startDate.ToString();
            Price = eventInfo.entryFee.ToString();
            NoOfParticipants = eventInfo.maxParticipants;
            UpdateInterestedStatus();
        }
    }
}
