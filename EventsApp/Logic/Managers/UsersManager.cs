using EventsApp.Logic.Adapters;
using EventsApp.Logic.Attributes;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<UserInfo> GetInterestedUsers(Guid eventId)
        {
            // TODO: UsersManager: Implement this method
            return null;
        }

        public static List<UserInfo> GetGoingUsers(Guid eventId)
        {
            // TODO: UsersManager: Implement this method
            return null;
        }
    }
}
