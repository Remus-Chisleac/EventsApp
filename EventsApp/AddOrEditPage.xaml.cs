
using EventsApp.Logic.Entities;
using EventsApp.Logic.Managers;

namespace EventsApp;

public partial class AddOrEditPage : ContentPage
{
    private List<string> SelectedCategories = new List<string>();
    private List<string> SelectedSponsors = new List<string>();
    private List<string> SelectedExpenses = new List<string>();

    private Guid userId;
    private Guid eventId;
    private bool edit;

    public AddOrEditPage(Guid userId, Guid eventId, bool edit)
	{
		InitializeComponent();
        this.userId = userId;
        this.eventId = eventId;
        this.edit = edit;

        if (edit) LoadEvent();
    }

    private void LoadEvent()
    {
        EventInfo eventInfo = EventsManager.GetEvent(eventId);
        LoadEventInfo(eventInfo);
    }

    private EventInfo GenerateEventInfo()
    {
        var eventInfo = new EventInfo();
        eventInfo.GUID = edit ? eventId : Guid.NewGuid();
        eventInfo.eventName = TitleEntry.Text;
        eventInfo.description = DescriptionEntry.Text;
        eventInfo.location = LocationEntry.Text;
        eventInfo.categories = string.Join(", ", SelectedCategories);

        TimeSpan startTime = StartTimePicker.Time;
        TimeSpan endTime = EndTimePicker.Time;
        DateTime dateTime = StartDatePicker.Date;
        DateTime startDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, startTime.Hours, startTime.Minutes, 0);
        DateTime endDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, endTime.Hours, endTime.Minutes, 0);
        eventInfo.startDate = startDateTime;
        eventInfo.endDate = endDateTime;
        float.TryParse(PriceEntry.Text, out eventInfo.entryFee);
        eventInfo.bannerURL = LogoURLEntry.Text;
        eventInfo.logoURL = LogoURLEntry.Text;
        eventInfo.maxParticipants = 50;
        eventInfo.ageLimit = int.Parse(AgeLimitEntry.Text);
        eventInfo.categories = string.Join(", ", SelectedCategories);
        return eventInfo;
    }

    private void LoadEventInfo(EventInfo eventInfo)
    {
        TitleEntry.Text = eventInfo.eventName;
        DescriptionEntry.Text = eventInfo.description;
        LocationEntry.Text = eventInfo.location;
        LogoURLEntry.Text = eventInfo.logoURL;
        PriceEntry.Text = eventInfo.entryFee.ToString();
        AgeLimitEntry.Text = eventInfo.ageLimit.ToString();
        string[] categories = [];
        try
        {
            eventInfo.categories.Split(", ");
            foreach (string category in categories)
            {
                SelectedCategories.Add(category);
                Frame frame = new Frame
                {
                    CornerRadius = 20,
                    BackgroundColor = Color.FromArgb("#D9DCDD"),
                    Padding = new Thickness(5),
                    Margin = new Thickness(5),
                    BorderColor = Color.FromArgb("#E0E0E0"),
                };

                Label selectedLabel = new Label
                {
                    Text = category,
                    TextColor = Color.FromArgb("#000000")
                };

                frame.Content = selectedLabel;
                SelectedItemsStack.Children.Add(frame);
            }
        }
        catch (Exception e)
        {
        }

        StartTimePicker.Time = eventInfo.startDate.TimeOfDay;
        EndTimePicker.Time = eventInfo.endDate.TimeOfDay;
        StartDatePicker.Date = eventInfo.startDate.Date;
    }

    private void OnPublishedButtonClicked(object sender, EventArgs e)
    {
        EventInfo eventInfo = GenerateEventInfo();
        EventsManager.AddNewEvent(eventInfo);
        Navigation.PopAsync();
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        EventsManager.DeleteEvent(eventId);
        Navigation.PopAsync();
        Navigation.PopAsync();
    }

    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        EventInfo eventInfo = GenerateEventInfo();
        EventsManager.UpdateEvent(eventId, eventInfo);
        Navigation.PopAsync();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnSelectCategoriesClicked(object sender, EventArgs e)
    {
        CategoriesListView.IsVisible = !CategoriesListView.IsVisible;
    }

    private void OnSponsorsClicked(object sender, EventArgs e)
    {
        string inputText = SponsorEntry.Text;

        Frame frame = new Frame {
            CornerRadius = 20,
            BackgroundColor = Color.FromArgb("#D9DCDD"),
            Padding = new Thickness(5),
            Margin = new Thickness(5),
            BorderColor = Color.FromArgb("#E0E0E0"),
        };
        Label newLabel = new Label {
            Text = inputText,
            TextColor = Color.FromArgb("#000000")
        };
        frame.Content = newLabel;
        SponsorsStack.Children.Add(frame);
        SelectedSponsors.Add(inputText);
    }

    private void OnExpensesClicked(object sender, EventArgs e)
    {
        string inputText = ExpenseNameEntry.Text;

        Frame frame = new Frame {
            CornerRadius = 20,
            BackgroundColor = Color.FromArgb("#D9DCDD"),
            Padding = new Thickness(5),
            Margin = new Thickness(5),
            BorderColor = Color.FromArgb("#E0E0E0"),
        };

        Label newLabel = new Label {
            Text = inputText,
            TextColor = Color.FromArgb("#000000")
        };
        frame.Content = newLabel;
        ExpensesStack.Children.Add(frame);
        SelectedExpenses.Add(inputText);
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        string selectedItem = e.SelectedItem as string;

        if (SelectedCategories.Count >= 3 || SelectedItemsStack.Children.Any(child => ((Label)((Frame)child).Content).Text == selectedItem))
        {
            ((ListView)sender).SelectedItem = null;
            return;
        }

        Frame frame = new Frame {
            CornerRadius = 20,
            BackgroundColor = Color.FromArgb("#D9DCDD"),
            Padding = new Thickness(5),
            Margin = new Thickness(5),
            BorderColor = Color.FromArgb("#E0E0E0"),
        };

        Label selectedLabel = new Label {
            Text = selectedItem,
            TextColor = Color.FromArgb("#000000")
        };

        frame.Content = selectedLabel;
        SelectedItemsStack.Children.Add(frame);
        SelectedCategories.Add(selectedItem);
    }
}