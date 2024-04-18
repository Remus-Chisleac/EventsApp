using EventsApp.Logic.Managers;
using EventsApp.Model_View.Entities;

namespace EventsApp;

public partial class EventPageUser : ContentPage
{
    string eventGuid;
    bool isOrganizerMode = false;
    public Event Event { get; set; }

    public EventPageUser(string guid)
    {
        InitializeComponent();

        eventGuid = guid;
        Event = new Event(EventsManager.GetEvent(Guid.Parse(guid)));
        BindingContext = this;

        isOrganizerMode = EventsManager.IsOrganizer(AppStateManager.currentUserGUID, Guid.Parse(guid));

        UpdateProperties();
        UpdateInterestedStatus();
        UpdateGoingStatus();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshEvent();
        //RefreshInterestedStars();
    }

    private void RefreshEvent()
    {
        Event = new Event(EventsManager.GetEvent(Guid.Parse(eventGuid)));
        BindingContext = this;
        OnPropertyChanged(nameof(Event));
    }

    private void UpdateProperties()
    {
        buyTicketButton.Text = isOrganizerMode ? "Edit Event" : "Buy Ticket";
    }

    private void UpdateInterestedStatus()
    {
        if (UsersManager.IsInterested(AppStateManager.currentUserGUID, Guid.Parse(eventGuid)))
        {
            interestedImageButton.Source = "star_filled.png";
        }
        else
        {
            interestedImageButton.Source = "star_empty.png";
        }
    }

    private void DonateButton_Clicked(object sender, EventArgs e)
    {
        // Open BuyTicketPage
        if (Event != null)
        {
            Navigation.PushAsync(new BuyTicketAndDonatePage(Guid.Parse(Event.GUID), () => OnDonationPaymentReceived(), BuyTicketAndDonatePage.PaymentMethod.Donation));
        }
    }

    private void OnDonationPaymentReceived()
    {
        UpdateGoingStatus();
        UpdateInterestedStatus();
    }

    private void OnTickedPaymentReceived()
    {
        UpdateGoingStatus();
        UpdateInterestedStatus();
    }

    private void UpdateGoingStatus()
    {
        if (UsersManager.IsGoing(AppStateManager.currentUserGUID, Guid.Parse(eventGuid)))
        {
            goingImageButton.BackgroundColor = Color.FromHex("#FFD700");
        }
        else
        {
            goingImageButton.BackgroundColor = Color.FromHex("#FFFFFF");
        }
    }

    private void InterestedImageButton_Clicked(object sender, EventArgs e)
    {
        if (UsersManager.IsInterested(AppStateManager.currentUserGUID, Guid.Parse(eventGuid)))
        {
            UsersManager.RemoveInterestedStatus(AppStateManager.currentUserGUID, Guid.Parse(eventGuid));
        }
        else
        {
            UsersManager.SetInterestedStatus(AppStateManager.currentUserGUID, Guid.Parse(eventGuid));
        }

        UpdateInterestedStatus();
    }

    private void BuyTicketButton_Clicked(object sender, EventArgs e)
    {
        if (Event == null) return;

        if (isOrganizerMode)
        {
            Navigation.PushAsync(new AddOrEditPage(AppStateManager.currentUserGUID, Guid.Parse(Event.GUID), true));
        }
        else
        {
            Navigation.PushAsync(new BuyTicketAndDonatePage(Guid.Parse(Event.GUID), () => OnTickedPaymentReceived(), BuyTicketAndDonatePage.PaymentMethod.Ticket));
        }


        UpdateGoingStatus();
    }

    private void ShareImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserSharePage(AppStateManager.currentUserGUID, Guid.Parse(eventGuid)));
    }

    private void ReportImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ReportPage(AppStateManager.currentUserGUID, Guid.Parse(eventGuid)));
    }

    private void BackImageButton_Clicked(object sender, EventArgs e)
    {

    }
}