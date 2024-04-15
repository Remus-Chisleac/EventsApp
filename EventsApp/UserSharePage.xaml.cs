using System.Collections.ObjectModel;

namespace EventsApp;

public partial class UserSharePage	: ContentPage
{
    public ObservableCollection<User> Users { get; set; }
    public UserSharePage()
	{	
		InitializeComponent();
        Users = new ObservableCollection<User>
            {
                new User ( "User1","circle1.jpeg" ),
                new User ("User2","circle1.jpeg" ),
                new User (  "User3","circle1.jpeg" )
            };

        BindingContext = this;
    }

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync(); 
    }
    private void InviteButton_Clicked(object sender, EventArgs e)
    {

    }

}
