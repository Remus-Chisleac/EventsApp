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

        public static List<Entities.UserInfo> GetGoingUsers(Guid eventId)
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
