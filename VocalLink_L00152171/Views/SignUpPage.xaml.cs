using VocalLink_L00152171.ViewModels;

namespace VocalLink_L00152171.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
		BindingContext = new SignUpViewModel();
	}

    //user to clear the fields when page is opened first
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if(BindingContext is SignUpViewModel viewModel)
        {
            viewModel.ClearFields();
        }

    }
}