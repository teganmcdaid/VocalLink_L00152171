using VocalLink_L00152171.ViewModels;

namespace VocalLink_L00152171.Views;

public partial class SingerSetupPage : ContentPage
{
	public SingerSetupPage()
	{
        InitializeComponent();
        BindingContext = new SingerSetupViewModel();
    }
}