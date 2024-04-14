using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using EventsApp.Logic.Managers;

namespace EventsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void OnLoadEventsClicked(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private async void OnEventEditClicked(object sender, EventArgs e)
        {
            string guid = (sender as Button).CommandParameter.ToString();
            Guid eventGUID = Guid.Parse(guid);

            await Navigation.PushAsync(new EventInfoPage(eventGUID));
        }

        private void LoadEvents()
        {
            // Example data for demonstration
            List<EventCard> events = GetEventCards();
            eventsListView.ItemsSource = events;
        }

        public List<EventCard> GetEventCards()
        {
            List<EventCard> eventCards = new List<EventCard>();
            List<EventInfo> events = EventsManager.GetAllEvents();
            foreach (EventInfo evt in events)
            {
                eventCards.Add(new EventCard(evt));
            }
            return eventCards;
        }

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
}
