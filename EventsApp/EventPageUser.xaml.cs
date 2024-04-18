using EventsApp.Logic.Managers;
using EventsApp.Model_View.Entities;

namespace EventsApp;

public partial class EventPageUser : ContentPage
{
    string eventGuid;
    public Event Event { get; set; }

    public EventPageUser(string guid)
    {
        InitializeComponent();

        eventGuid = guid;
        Event = new Event(EventsManager.GetEvent(Guid.Parse(guid)));
        BindingContext = this;
        UpdateInterestedStatus();
        UpdateGoingStatus();
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
        if (Event != null)
        {
            Navigation.PushAsync(new BuyTicketAndDonatePage(Guid.Parse(Event.GUID), () => OnTickedPaymentReceived(), BuyTicketAndDonatePage.PaymentMethod.Ticket));
        }

   
        UpdateGoingStatus();
    }

    private void ShareImageButton_Clicked(object sender, EventArgs e)
    {

    }

    private void ReportImageButton_Clicked(object sender, EventArgs e)
    {

    }

    private void BackImageButton_Clicked(object sender, EventArgs e)
    {

    }
}