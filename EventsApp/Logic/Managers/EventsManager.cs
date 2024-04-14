using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using System.Diagnostics;

namespace EventsApp.Logic.Managers
{
    public static class EventsManager
    {
        private static DataAdapter<EventInfo> _eventsAdapter;
        private static DataAdapter<UserEventRelationInfo> _userEventRelationsAdapter;

        public static void Initialize(DataAdapter<EventInfo> adapter, DataAdapter<UserEventRelationInfo> userEventRelationsAdapter)
        {
            _eventsAdapter = adapter;
            _userEventRelationsAdapter = userEventRelationsAdapter;
        }

        public static EventInfo GetEvent(Guid eventId)
        {
            EventInfo eventInfo = new EventInfo(eventId);
            return _eventsAdapter.Get(eventInfo.GetIdentifier());
        }

        public static List<EventInfo> GetAllEvents()
        {
            return _eventsAdapter.GetAll();
        }

        /// <summary>
        /// Returns true if the current date is between the startDate and endDate of the event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsEventActive(Guid eventId)
        {
            EventInfo eventInfo = GetEvent(eventId);
            DateTime startDate = eventInfo.startDate;
            DateTime endDate = eventInfo.endDate;
            DateTime today = DateTime.Now;
            if (today >= startDate && today <= endDate)
                return true;
            return false;
        }

        public static void AddNewEvent(EventInfo eventInfo)
        {
            _eventsAdapter.Add(eventInfo);
        }

        public static void UpdateEvent(Guid eventId, EventInfo eventInfo)
        {
            EventInfo currentEvent = GetEvent(eventId);
            _eventsAdapter.Update(currentEvent.GetIdentifier(), eventInfo);
        }

        public static void DeleteEvent(Guid eventId)
        {
            EventInfo eventInfo = GetEvent(eventId);
            _eventsAdapter.Delete(eventInfo.GetIdentifier());
        }

        /// <summary>
        /// Returns true if the current date is after the endDate of the event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsEventOver(Guid eventId)
        {
            EventInfo eventInfo = GetEvent(eventId);
            DateTime endDate = eventInfo.endDate;
            DateTime today = DateTime.Now;
            if(today >  endDate) 
                return true;
            return false;
        }

        public static List<EventInfo> FilterEvents(EventFilter filter)
        {

            List<EventInfo> allEvents = GetAllEvents();
            // If something is null ignore that filter
            // Ex: If name is "" ignore the name filter

            List<EventInfo> filteredEvents = new List<EventInfo>();
            if (filter.name != null)
            {
               filteredEvents = allEvents.FindAll(c => c.eventName.ToLower().Contains(filter.name.ToLower()));
            }
            if (filter.maxFee != 0)
            {
                filteredEvents = filteredEvents.FindAll(e => e.entryFee <= filter.maxFee);
            }
            if (filter.startDate != null)
            {
                filteredEvents = filteredEvents.FindAll(e => e.startDate >= filter.startDate);
            }
            if (filter.categories != null)
            {
                filteredEvents = filteredEvents.FindAll(e =>
                {
                    List<string> presentCategories = e.categories.Split(',').ToList();
                    foreach(string category in filter.categories)
                    {
                        if (presentCategories.Contains(category))
                            return true;
                    }
                    return false;
                });
            }

            return filteredEvents;
        }

        public static List<UserInfo> GetInterestedUsers(Guid eventId)
        {
            EventInfo eventInfo = GetEvent(eventId);
            List<UserEventRelationInfo> userEventRelationInfos = _userEventRelationsAdapter.GetAll();
            List<UserInfo> users = new List<UserInfo>();
            foreach(UserEventRelationInfo relationInfo in userEventRelationInfos)
            {
                if(relationInfo.eventGUID == eventId && relationInfo.status == UserEventRelationInfo.Status.Interested)
                {
                    UserInfo user = UsersManager.GetUser(relationInfo.userGUID);
                    users.Add(user);
                }
            }
            return users;
        }

        public static List<UserInfo> GetGoingUsers(Guid eventId)
        {
            EventInfo eventInfo = GetEvent(eventId);
            List<UserEventRelationInfo> userEventRelationInfos = _userEventRelationsAdapter.GetAll();
            List<UserInfo> users = new List<UserInfo>();
            foreach (UserEventRelationInfo relationInfo in userEventRelationInfos)
            {
                if (relationInfo.eventGUID == eventId && relationInfo.status == UserEventRelationInfo.Status.Going)
                {
                    UserInfo user = UsersManager.GetUser(relationInfo.userGUID);
                    users.Add(user);
                }
            }
            return users;
        }

        public static UserInfo GetEventOrganizer(Guid eventId)
        {
            EventInfo eventInfo = GetEvent(eventId);
            return UsersManager.GetUser(eventInfo.organizerGUID);
        }

        public static int GetNumberOfParticipants(Guid eventId)
        {
            return GetGoingUsers(eventId).Count;
        }
    
        public static float GetTotalDonationAmount(Guid eventId)
        {
            float totalDonationAmount = 0;
            List<DonationInfo> donations =  DonationsManager.GetAllDonationsForEvent(eventId);
            foreach (DonationInfo donation in donations)
                totalDonationAmount += donation.amount;
            return totalDonationAmount;
        }

        public static List<EventInfo> GetEventsOfUser(Guid userId)
        {
            List<EventInfo> events = GetAllEvents();
            List<EventInfo> eventsForUser = new List<EventInfo>();
            foreach(EventInfo eventInfo in events)
                if(eventInfo.organizerGUID == userId)
                    eventsForUser.Add(eventInfo);
            return eventsForUser;
        }

        public static List<EventInfo> SortEventsByPopularityAscending()
        {
            List<EventInfo> events = GetAllEvents();
            events.Sort((firstEvent, secondEvent) => GetNumberOfParticipants(firstEvent.GUID).CompareTo(GetNumberOfParticipants(secondEvent.GUID)));
            return events;
        }

        public static List<EventInfo> SortEventsByPopularityDescending()
        {
            List<EventInfo> events = GetAllEvents();
            events.Sort((firstEvent, secondEvent) => GetNumberOfParticipants(secondEvent.GUID).CompareTo(GetNumberOfParticipants(firstEvent.GUID)));
            return events;
        }

        public static List<EventInfo> SortEventsByDateAscending()
        {
            List<EventInfo> events = GetAllEvents();
            events.Sort((firstEvent, secondEvent) => firstEvent.startDate.CompareTo(secondEvent.startDate));
            return events;
        }

        public static List<EventInfo> SortEventsByDateDescending()
        {
            List<EventInfo> events = GetAllEvents();
            events.Sort((firstEvent, secondEvent) => secondEvent.startDate.CompareTo(firstEvent.startDate));
            return events;
        }

        public static List<EventInfo> SortEventsByPriceAscending()
        {
            List<EventInfo> events = GetAllEvents();
            events.Sort((firstEvent, secondEvent) => firstEvent.entryFee.CompareTo(secondEvent.entryFee));
            return events;
        }

        public static List<EventInfo> SortEventsByPriceDescending()
        {
            List<EventInfo> events = GetAllEvents();
            events.Sort((firstEvent, secondEvent) => secondEvent.entryFee.CompareTo(firstEvent.entryFee));
            return events;
        }

        public struct EventFilter
        {
            public string name;
            public float maxFee;
            public DateTime startDate;
            public DateTime endDate;
            public List<string> categories;

            public EventFilter(string name, float maxFee, DateTime startDate, DateTime endDate, List<string> categories)
            {
                this.name = name;
                this.maxFee = maxFee;
                this.startDate = startDate;
                this.endDate = endDate;
                this.categories = categories;
            }
        }

        public static List<EventInfo> SearchEventByName(string nameString)
        {
            List<EventInfo> allEvents = GetAllEvents();
            List<EventInfo> filteredEvents = new List<EventInfo>();
            filteredEvents = allEvents.FindAll(eventItem => eventItem.eventName.ToLower().Contains(nameString.ToLower()));
            return filteredEvents;
        }

        public static List<EventInfo> SearchEventByLocation(string locationString)
        {
            List<EventInfo> allEvents = GetAllEvents();
            List<EventInfo> filteredEvents = new List<EventInfo>();
            filteredEvents = allEvents.FindAll(eventItem => eventItem.location.ToLower().Contains(locationString.ToLower()));
            return filteredEvents;
        }

        private static bool ProcessPayment(string cardHolderName, string cardNumber, string cvv, DateTime expirationDate)
        {
            string correctCardHolderName = cardHolderName; // get this from database
            string correctCardNumber = cardNumber; // get this from database
            string correctCvv = cvv; // get this from database
            DateTime correctExpirationDate = expirationDate; // get this from database

            if (correctExpirationDate.Date < DateTime.Now.Date || correctCardHolderName != cardHolderName || correctCardNumber != cardNumber || correctCvv != cvv || correctExpirationDate.Date != expirationDate.Date)
            {
                return false;
            }

            return true;
        }

        public static void BuyTicket(Guid eventId, Guid userId, string cardHolderName, string cardNumber, string cvv, DateTime expirationDate)
        {
            if (ProcessPayment(cardHolderName, cardNumber, cvv, expirationDate))
            {
                UserEventRelationInfo relationInfo = new UserEventRelationInfo(userId, eventId, UserEventRelationInfo.Status.Going);
                _userEventRelationsAdapter.Add(relationInfo);
            }
        }

    }
}
