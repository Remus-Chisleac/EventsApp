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
            Test();
            count = count + 2;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        public void Test()
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
    }

}
