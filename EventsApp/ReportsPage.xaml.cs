using EventsApp.Logic.Entities;
using EventsApp.Logic.Managers;

namespace EventsApp;

public partial class ReportsPage : ContentPage
{
    public List<ViewReports> usersReports;
    private Guid eventGuid;
	public ReportsPage(Guid eventGuid)
	{
		InitializeComponent();
        this.eventGuid = eventGuid;
        usersReports = GetReports();
        reportsListView.ItemsSource = usersReports;
        BindingContext = this;
    }

    private List<ViewReports> GetReports()
    {
        List<ReportInfo> reportInfos = ReportsManager.GetReportsForEvent(eventGuid);
        List<ViewReports> reports = new List<ViewReports>();

        foreach (ReportInfo reportInfo in reportInfos)
        {
            string userName = UsersManager.GetUser(reportInfo.userGUID).name;
            ViewReports newReport = new ViewReports(userName, reportInfo.reportType.ToString());
            reports.Add(newReport);
        }

        return reports;
    }

    private void BackImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
public class ViewReports
{
    public string UserName { get; set; }
    public string Report { get; set; }
    public ViewReports(String name, String report)
    {
        UserName = name;
        Report = report;
    }
}