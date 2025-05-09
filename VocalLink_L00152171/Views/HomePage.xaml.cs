
using VocalLink_L00152171.ViewModels;

namespace VocalLink_L00152171.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomePageViewModel();
	}
}