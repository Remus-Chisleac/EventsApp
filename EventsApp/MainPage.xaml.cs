using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using EventsApp.Logic.Managers;
using EventsApp.Model_View.Entities;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EventsApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        Label label;
        DateTime date = DateTime.Now;
        string FormattedDate;

        public ObservableCollection<Event> Events { 
            get; 
            set; 
        }

        private ObservableCollection<Event> GetEvents(string sortOptions = null)
        {
            List<EventInfo> eventInfos = new List<EventInfo>();

            EventsManager.GetAllEvents();
            string sortOption = EventsSort.SelectedItem?.ToString() ?? "";

            switch (sortOption)
            {
                case "By Popularity":
                    eventInfos = EventsManager.SortEventsByPopularityAscending();
                    break;
                case "By Date":
                    eventInfos = EventsManager.SortEventsByDateAscending();
                    break;
                case "By Price":
                    eventInfos = EventsManager.SortEventsByPriceAscending();
                    break;
                default:
                    eventInfos = EventsManager.GetAllEvents();
                    break;
            }

            ObservableCollection<Event> events = new ObservableCollection<Event>();

            foreach (EventInfo eventInfo in eventInfos)
            {
                Event newEvent = new Event(eventInfo);
                events.Add(newEvent);
                newEvent.UpdateInterestedStatus();
                OnPropertyChanged(nameof(newEvent.InterestedStar));
                newEvent.UpdateInterestedStatus();
            }

            return events;
        }

        public MainPage()
        {
            InitializeComponent();
            FormattedDate = date.ToString("dddd, d MMM, hh:mm tt");
            /*
            Events = new ObservableCollection<Event>
            {
                new Event("event_logo.jpg", "Cloudflight", "Hackathon", "Cluj, Centru", FormattedDate, "5 EUR", 50, false, "star_empty.png"),
                new Event("ubb_logo.png", "UBB Cluj", "Job Fair", "Cluj, Dorobantilor", FormattedDate, "Free", 110, false, "star_empty.png")
            };*/

            RefreshEvents();
        }

        private void RefreshInterestedStars()
        {
            foreach (Event ev in Events)
            {
                ev.UpdateInterestedStatus();
                OnPropertyChanged(nameof(ev.InterestedStar));
                ev.UpdateInterestedStatus();
            }
            BindingContext = this;
        }

        private void RefreshAllEvents()
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshEvents();
            //RefreshInterestedStars();
        }

        public void OnSortChanged(object sender, EventArgs e)
        {
            RefreshEvents();
        }

        public void RefreshEvents()
        {
            if(Events != null) Events.Clear();
            Events = GetEvents();
            OnPropertyChanged(nameof(Events));
            BindingContext = this;
        }

        #region Event Handlers
        async void OnEventClicked(object sender, EventArgs e)
        {
            string guid = "";
            Grid imageSender = (Grid)sender;
            if (imageSender.GestureRecognizers.Count > 0)
            {
                var gesture = (TapGestureRecognizer)imageSender.GestureRecognizers[0];
                guid = (string)gesture.CommandParameter;
            }

            await Navigation.PushAsync(new EventPageUser(guid));
        }

        void OnImageButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new AddOrEditPage(AppStateManager.currentUserGUID, Guid.Empty, false));
        }

        private void OnSearchBarTextChanged(object sender, EventArgs e)
        {
            string searchText = EventsSearchBar.Text;
            List<string> searchResults = new List<string>
            {
                "Result 1 for " + searchText,
                "Result 2 for " + searchText,
                "Result 3 for " + searchText
            };
            SearchResultsListView.ItemsSource = searchResults;
            SearchResultsListView.IsVisible = !string.IsNullOrEmpty(searchText); ;
        }

        private void OnFilterClicked(object sender, EventArgs e)
        {
            FilterOptions.IsVisible = !FilterOptions.IsVisible;
        }

        private void OnStarTapped(object sender, EventArgs e)
        {
            Image tappedStar = (Image)sender;
            Event tappedEvent = (Event)tappedStar.BindingContext;

            if(!UsersManager.IsInterested(AppStateManager.currentUserGUID, Guid.Parse(tappedEvent.GUID)))
            {
                UsersManager.SetInterestedStatus(AppStateManager.currentUserGUID, Guid.Parse(tappedEvent.GUID));
            }
            else
            {
                UsersManager.RemoveInterestedStatus(AppStateManager.currentUserGUID, Guid.Parse(tappedEvent.GUID));
            }

            tappedEvent.UpdateInterestedStatus();
        }
        #endregion
    }
}
