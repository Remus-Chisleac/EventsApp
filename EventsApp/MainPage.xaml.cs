using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using EventsApp.Logic.Managers;

namespace EventsApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Cox.Text = "Bruh";
            TestUsers();
            TestEvents();
            count = count + 2;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} timeeeee";
            else
                CounterBtn.Text = $"Clicked {count} times for VITeam";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        public void TestUsers()
        {
            CSVAdapter<UserInfo> adapter = new CSVAdapter<UserInfo>("data\\UsersCSV.csv");

            adapter.Clear();

            UserInfo user1 = new UserInfo("John Doe", "johndoe@gmail.com", "password");
            UserInfo user2 = new UserInfo("Mark Smith", "marksmith@gmail.com", "password");
            UserInfo user3 = new UserInfo("Jane Doe", "janedoe@gmail.com", "password");

            adapter.Add(user1);
            adapter.Add(user2);
            adapter.Add(user3);

            List<UserInfo> users = adapter.GetAll();
            foreach (UserInfo user in users)
            {
                Console.WriteLine(user.name);
            }

            adapter.Delete(user1.GetIdentifier());
            users = adapter.GetAll();
            foreach (UserInfo user in users)
            {
                Console.WriteLine(user.name);
            }

            UserInfo userInfo = adapter.Get(user2.GetIdentifier());
            Console.WriteLine(userInfo.name);

            bool contains = adapter.Contains(user3.GetIdentifier());
            Console.WriteLine(contains);

        }
    
        public void TestEvents()
        {
            CSVAdapter<UserInfo> usersAdapter = new CSVAdapter<UserInfo>("data\\UsersCSV.csv");
            CSVAdapter<EventInfo> adapter = new CSVAdapter<EventInfo>("data\\EventsCSV.csv");

            UserInfo sudoUser = usersAdapter.GetAll().First();

            adapter.Clear();

            EventInfo event1 = new EventInfo("Event 1", "Description 1", DateTime.Now, "Location 1", sudoUser.GUID);
            EventInfo event2 = new EventInfo("Event 2", "Description 2", DateTime.Now, "Location 2", sudoUser.GUID);
            EventInfo event3 = new EventInfo("Event 3", "Description 3", DateTime.Now, "Location 3", sudoUser.GUID);

            adapter.Add(event1);
            adapter.Add(event2);
            adapter.Add(event3);

            List<EventInfo> events = adapter.GetAll();
            foreach (EventInfo ei in events)
            {
                Console.WriteLine(ei.name);
            }

            adapter.Delete(event1.GetIdentifier());
            events = adapter.GetAll();
            foreach (EventInfo ei in events)
            {
                Console.WriteLine(ei.name);
            }

            EventInfo eventInfo = adapter.Get(event2.GetIdentifier());
            Console.WriteLine(eventInfo.name);

            bool contains = adapter.Contains(event3.GetIdentifier());
            Console.WriteLine(contains);
        }
    }
}
