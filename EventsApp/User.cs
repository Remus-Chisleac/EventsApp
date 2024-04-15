/*namespace EventsApp;

public partial class OrganizerInvitePage : ContentPage
{
	public OrganizerInvitePage()
	{
		InitializeComponent();
	}
    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        
    }
}	*/

namespace EventsApp
{
    public class User
    {
        public string Username { get; set; }
        public string ProfilePicture { get; set; }

        // Additional properties as needed

        public User(string username, string profilePicture)
        {
            Username = username;
            ProfilePicture = profilePicture;
        }
    }
}