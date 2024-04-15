namespace EventsApp;

public partial class ReportsPage : ContentPage
{
    public List<UsersReportsMockData> usersReports;
	public ReportsPage()
	{
		InitializeComponent();
        usersReports = new List<UsersReportsMockData> {
            new UsersReportsMockData("User1", "Spam" ),
            new UsersReportsMockData("User2", "Harrasment")
        };
        reportsListView.ItemsSource = usersReports;
        BindingContext = this;
    }

    private void BackImageButton_Clicked(object sender, EventArgs e)
    {

    }
}
public class UsersReportsMockData
{
    public string UserName { get; set; }
    public string Report { get; set; }
    public UsersReportsMockData(String name, String report)
    {
        UserName = name;
        Report = report;
    }
}