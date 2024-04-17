namespace EventsApp;

public partial class AddOrEditPage : ContentPage
{
    private List<string> SelectedCategories = new List<string>();
    private List<string> SelectedSponsors = new List<string>();
    private List<string> SelectedExpenses = new List<string>();
    public AddOrEditPage()
	{
		InitializeComponent();
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
        string inputText = ExpenseEntry.Text;

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