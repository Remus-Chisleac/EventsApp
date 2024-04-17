namespace EventsApp;

public partial class RatingPage : ContentPage
{
	public RatingPage()
	{
		InitializeComponent();
        Entry entry = new Entry { Placeholder = "Enter text" };
        entry.TextChanged += OnEntryTextChanged;
        entry.Completed += OnEntryCompleted;
    }
    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = entry.Text;
    }
    void OnEntryCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
    }
    private void OnStarClicked(object sender, EventArgs e)
    {
        ImageButton star = (ImageButton)sender;
        if (star.Source is FileImageSource fileImageSource && fileImageSource.File == "yellow_star.png")
        {
            star.Source = "white_star.png";
        }
        else
        {
            star.Source = "yellow_star.png";
        }
    }


}