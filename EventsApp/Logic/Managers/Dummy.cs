using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using EventsApp.Logic.Entities;
using Bogus;

namespace EventsApp.Logic.Managers
{
    public static class Dummy
    {
        public static Random random = new Random();

        public static void Populate()
        {
            AddCurrentlyLoggedUser();
            PopulateUsers(10);
            PopulateEvents(10);

            //List<UserInfo> users = UsersManager.GetAllUsers();
            //List<EventInfo> events = EventsManager.GetAllEvents();
        }

        public static void AddCurrentlyLoggedUser()
        {
            UserInfo currentUser = new UserInfo
            (
                AppStateManager.currentUserGUID,
                AppStateManager.name,
                AppStateManager.password
            );

            UsersManager.AddNewUser(currentUser);
        }

        public static void PopulateUsers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                UserInfo userInfo = GenerateRandomUser();
                UsersManager.AddNewUser(userInfo.name, userInfo.password);
            }
        }

        public static void PopulateEvents(int count)
        {
            for (int i = 0; i < count; i++)
            {
                EventInfo eventInfo = GenerateRandomEvent(GetRandomUserGUID());
                EventsManager.AddNewEvent(eventInfo);
            }
        }

        public static EventInfo GenerateRandomEvent(Guid organizerGuid)
        {
            // eventName, categories, location, maxParticipants, description, startDate, endDate, bannerURL
            // logoUrl, ageLimit, entryFee
            Faker faker = new Faker();

            EventInfo eventInfo = new EventInfo
            (
                organizerGuid,
                faker.Company.CompanyName(),
                faker.Commerce.Categories(1)[0],
                faker.Address.City(),
                faker.Random.Int(1, 100),
                faker.Lorem.Paragraph(),
                faker.Date.Future(),
                faker.Date.Future(),
                faker.Image.PicsumUrl(),
                faker.Image.PicsumUrl(),
                faker.Random.Int(1, 100),
                faker.Random.Int(0, 100)
            );

            return eventInfo;
        }

        public static UserInfo GenerateRandomUser()
        {
            Faker faker = new Faker();

            UserInfo userInfo = new UserInfo
            {
                name = faker.Internet.UserName(),
                password = faker.Internet.Password()
            };

            return userInfo;
        }

        public static Guid GetRandomUserGUID()
        {
            return UsersManager.GetAllUsers()[random.Next(UsersManager.GetAllUsers().Count)].GUID;
        }

        public static Guid GetRandomEventGUID()
        {
            return EventsManager.GetAllEvents()[random.Next(EventsManager.GetAllEvents().Count)].GUID;
        }
    }
}
