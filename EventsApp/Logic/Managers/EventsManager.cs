using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;

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
            // TODO: EventsManager: Implement this method

            List<EventInfo> allEvents = GetAllEvents();
            // If something is null ignore that filter
            // Ex: If name is "" ignore the name filter

            List<EventInfo> filteredEvents = new List<EventInfo>();
            if (filter.name != null)
            {
               filteredEvents = allEvents.FindAll(c => c.eventName.ToLower().Contains(filter.name.ToLower()));
            }

            return filteredEvents;
        }

        public static List<UserInfo> GetInterestedUsers(Guid eventId)
        {
            // TODO: UsersManager: Implement this method
            EventInfo eventInfo = GetEvent(eventId);
            return new List<UserInfo>();
        }

        public static List<UserInfo> GetGoingUsers(Guid eventId)
        {
            // TODO: UsersManager: Implement this method
            return null;
        }

        public static int GetNumberOfParticipants(Guid eventId)
        {
            // TODO: EventsManager: Implement this method

            return 0;
        }
    
        public static float GetTotalDonationAmount(Guid eventId)
        {
            // TODO: EventsManager: Implement this method

            return 0;
        }

        public static List<EventInfo> GetEventsOfUser(Guid userId)
        {
            return new List<EventInfo>();
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
    }
}
