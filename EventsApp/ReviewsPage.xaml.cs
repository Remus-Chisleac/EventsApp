namespace EventsApp;

public partial class ReviewsPage : ContentPage
{
    public List<ReviewsMockData> mockReviews;

    public ReviewsPage()
	{
		InitializeComponent();
        mockReviews = new List<ReviewsMockData> {
            new ReviewsMockData("https://cdn-icons-png.flaticon.com/512/1144/1144760.png", "https://upload.wikimedia.org/wikipedia/commons/2/2f/Star_rating_3_of_5.png", "Nice"),
            new ReviewsMockData("https://cdn-icons-png.flaticon.com/512/1144/1144760.png", "https://upload.wikimedia.org/wikipedia/commons/1/17/Star_rating_5_of_5.png", "Felt good")
        };
        reviewsListView.ItemsSource = mockReviews;
        BindingContext = this;
    }

    private void BackImageButton_Clicked(object sender, EventArgs e)
    {

    }
}

public class ReviewsMockData
{
    public string UserImageURL { get; set; }
    public string StarsImageURL { get; set; }
    public string ReviewText {  get; set; }
    public ReviewsMockData(String userImageURL, String starsImageURL, String reviewText)
    {
        UserImageURL = userImageURL;
        StarsImageURL = starsImageURL;
        ReviewText = reviewText;
    }
}