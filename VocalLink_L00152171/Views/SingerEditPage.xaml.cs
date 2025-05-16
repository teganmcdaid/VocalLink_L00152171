using VocalLink_L00152171.ViewModels;

namespace VocalLink_L00152171.Views;


public partial class SingerEditPage : ContentPage
{
	public SingerEditPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is SingerEditViewModel vm)
        {
            await vm.LoadSingerAsync();
        }

        //disable flyout navigation
        if (Shell.Current is AppShell shell)
        {
            shell.DisableFlyout();
        }
    }
}