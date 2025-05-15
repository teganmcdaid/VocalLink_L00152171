using VocalLink_L00152171.ViewModels;

namespace VocalLink_L00152171.Views;

public partial class UserBookingsPage : ContentPage
{
	public UserBookingsPage()
	{
		InitializeComponent();
        welcomeLabel.Text = ("Hello " + Preferences.Get("UserEmail", "Guest"));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is UserBookingsViewModel vm)
        {
            vm.LoadBookingsAsync();
        }
    }
}