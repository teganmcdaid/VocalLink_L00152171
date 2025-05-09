namespace VocalLink_L00152171.ViewModels;

public class UserBookingsViewModel : ContentPage
{
	public UserBookingsViewModel()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}