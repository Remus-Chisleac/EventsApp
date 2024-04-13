using EventsApp.Logic.Adapters;
using EventsApp.Logic.Attributes;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Managers
{
    public static class UsersManager
    {
        private static DataAdapter<UserInfo> _usersAdapter;
        private static DataAdapter<AdminInfo> _adminsAdapter;
        private static DataAdapter<UserEventRelationInfo> _userEventRelationsAdapter;

        public static void Initialize(DataAdapter<UserInfo> usersAdapter, DataAdapter<AdminInfo> adminsAdapter, DataAdapter<UserEventRelationInfo> userEventRelationsAdapter)
        {
            _usersAdapter = usersAdapter;
            _adminsAdapter = adminsAdapter;
            _userEventRelationsAdapter = userEventRelationsAdapter;
        }

        public static UserInfo GetUser(Guid userId)
        {
            UserInfo userInfo = new UserInfo(userId);
            return _usersAdapter.Get(userInfo.GetIdentifier());
        }

        public static List<UserInfo> GetAllUsers()
        {
            return _usersAdapter.GetAll();
        }

        public static bool IsAdmin(Guid userId)
        {
            // TODO: UsersManager: Implement this method
            return false;
        }

        public static float HasPermission(Guid userId)
        {
            // TODO: UsersManager: Implement this method
            return 0;
        }

        public static List<UserInfo> SearchUsersByUsername(string usernameString)
        {
            List<UserInfo> foundUsers = new List<UserInfo>();
            foreach (UserInfo user in GetAllUsers())
            {
                if (user.name.StartsWith(usernameString))
                {
                    foundUsers.Add(user);
                }
            }
            return foundUsers;
        }


        public static void SendNotificationToUser(Guid userInvitedId, string message)
        {
            // not implemented by us
        }

        public static void AddNewUser(string name, string password)
        {
            UserInfo userInfo = new UserInfo(name, password);
            _usersAdapter.Add(userInfo);
        }

        public static void InviteUser(Guid userId, Guid eventId, Guid userInvitedId)
        {
            SendNotificationToUser(userInvitedId, $"You have been invited to the event {EventsManager.GetEvent(eventId).eventName}! by {GetUser(userId).name}");
        }

        public static void SetInterestedStatus(Guid userId, Guid eventId)
        {
            UserEventRelationInfo userEventRelationInfo = new UserEventRelationInfo(userId, eventId, UserEventRelationInfo.Status.Interested);
            _userEventRelationsAdapter.Update(userEventRelationInfo.GetIdentifier(), userEventRelationInfo);
        }


        public static void SetGoingStatus(Guid userId, Guid eventId)
        {
            UserEventRelationInfo userEventRelationInfo = new UserEventRelationInfo(userId, eventId, UserEventRelationInfo.Status.Going);
            _userEventRelationsAdapter.Update(userEventRelationInfo.GetIdentifier(), userEventRelationInfo);
        }

        public static void RemoveStatus(Guid userId, Guid eventId)
        {
            UserEventRelationInfo userEventRelationInfo = new UserEventRelationInfo(userId, eventId);
            _userEventRelationsAdapter.Delete(userEventRelationInfo.GetIdentifier());
        }



    }
}
