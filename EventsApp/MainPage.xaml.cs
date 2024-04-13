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
            count = count + 2;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} timeeeeexxxxxx";
            else
                CounterBtn.Text = $"Clicked {count} times for VITeam";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
