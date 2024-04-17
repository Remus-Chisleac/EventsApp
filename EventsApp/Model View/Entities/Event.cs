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

        public string ParticipantsInfoString {
            get
            {
                return NoOfParticipants.ToString() + " participants";
            }
        }

        public string DateInfoString
        {
            get
            {
                return StartDate;
            }
        }



        //trebuia sa adaug asta in event alfel nu afiseaza steaua in ListView
        private bool _clickedStar;

        public bool ClickedStar
        {
            get { return _clickedStar; }
            set
            {
                if (_clickedStar != value)
                {
                    _clickedStar = value;
                    OnPropertyChanged(nameof(ClickedStar));
                    OnPropertyChanged(nameof(StarIcon));
                }
            }
        }
        private string _starIcon;
        public string StarIcon
        {
            get { return _starIcon; }
            set
            {
                if (_starIcon != value)
                {
                    _starIcon = value;
                    OnPropertyChanged(nameof(StarIcon));
                }
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Event(string GUID, string picture, string organizer, string name, string description, string location, string date, string price, int participants, bool clicked, string star)
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
            _starIcon = star;
            _clickedStar = clicked;
        }

        public Event(EventInfo eventInfo, bool clicked, string star)
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
            _starIcon = star;
            _clickedStar = clicked;
        }
    }
}
