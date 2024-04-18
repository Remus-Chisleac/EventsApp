using EventsApp.Logic.Managers;

namespace EventsApp;

public partial class BuyTicketAndDonatePage : ContentPage
{
    private string eventGuid;
    private Action _onPaymentReceived;
    private PaymentMethod paymentMethod;
    public enum PaymentMethod { Ticket, Donation };

    public BuyTicketAndDonatePage(Guid eventGUID, Action onPaymentReceived, PaymentMethod paymentMethod)
    {
        InitializeComponent();
        eventGuid = eventGUID.ToString();
        _onPaymentReceived = onPaymentReceived;
        this.paymentMethod = paymentMethod;
    }

    private void BackImageButton_Clicked(object sender, EventArgs e)
    {

    }

    private void PayForTicket()
    {
        string cardHolderName = "Name";
        string cardNumber = "1234567890123456";
        string cvv = "123";
        DateTime expirationDate = new DateTime(2023, 12, 31);

        EventsManager.BuyTicket(AppStateManager.currentUserGUID, Guid.Parse(eventGuid), cardHolderName, cardNumber, cvv, expirationDate);
    }

    private void PayForDonation()
    {
        DonationsManager.AddDonation(AppStateManager.currentUserGUID, Guid.Parse(eventGuid), 10);
    }

    private void PayButton_Clicked(object sender, EventArgs e)
    {
        if(paymentMethod == PaymentMethod.Ticket)
        {
            PayForTicket();
        }
        else if(paymentMethod == PaymentMethod.Donation)
        {
            PayForDonation();
        }

        _onPaymentReceived.Invoke();
        Navigation.PopAsync();
    }
}