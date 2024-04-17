namespace EventsApp;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public partial class ReportPage : ContentPage
{
    public ReportPage()
	{
		InitializeComponent();
      
    }
   
    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}