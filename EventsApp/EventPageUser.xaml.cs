namespace EventsApp;

public partial class EventPageUser : ContentPage
{
    private int countClickedInterestedImageButton = 0;

    public EventPageUser()
	{
		InitializeComponent();
	}

    private void InterestedImageButton_Clicked(object sender, EventArgs e)
    {
        countClickedInterestedImageButton++;
        if (countClickedInterestedImageButton % 2 == 1)
        {
            interestedImageButton.BackgroundColor = Colors.Yellow;
        }
        else
        {
            interestedImageButton.BackgroundColor = Colors.White;
        }

    }

    private void BuyTicketButton_Clicked(object sender, EventArgs e)
    {
        goingImageButton.BackgroundColor = Colors.LightGreen;
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