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
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            UsersManager.AddNewUser("Imre", "ziggy");
            List<UserInfo> allUsers = UsersManager.GetAllUsers();
            UserInfo test = UsersManager.GetUser(allUsers[0].GUID);

            Cox.Text = "Bruh";

            CounterBtn.Text = $"{test.name} {test.password}";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
