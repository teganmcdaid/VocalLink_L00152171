
using VocalLink_L00152171.ViewModels;

namespace VocalLink_L00152171.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomePageViewModel();
	}

    //used to enable the flyout menu when on home page
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        welcomeLabel.Text = ("Hello " + Preferences.Get("UserEmail", "Guest"));

        //enable flyout navigation
        if (Shell.Current is AppShell shell)
        {
            shell.EnableFlyout();
        }
    }
}