using VocalLink_L00152171.ViewModels;

namespace VocalLink_L00152171.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }

    
    protected override void OnAppearing()
    {
        base.OnAppearing();

        //clear fields when page opened
        if (BindingContext is LoginViewModel viewModel)
        {
            viewModel.ClearFields();
        }

        //disable flyout navigation
        if (Shell.Current is AppShell shell)
        {
            shell.DisableFlyout();
        }
    }
}