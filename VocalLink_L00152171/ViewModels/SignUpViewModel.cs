using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.ViewModels;

public partial class SignUpViewModel : BaseViewModel
{
    [ObservableProperty]
    private string userEmail;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private bool isSinger;


    [RelayCommand]
    async Task SignUpAsync()
    {
        //check if fields are empty
        if (string.IsNullOrWhiteSpace(UserEmail) || string.IsNullOrWhiteSpace(Password))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please enter a username and Phone Number.", "OK");
            return;
        }

        //pass the user data to the home page
        var user = new User { UserEmail = userEmail, Password = password, IsSinger = isSinger };

        var users = await App.Database.GetUserAsync();
        foreach (var u in users)
        {

            if (user.UserEmail == u.UserEmail)
            {
                await App.Current.MainPage.DisplayAlert("Error", "This Email Address Already Has an Account", "OK");
                return;
            }
        }

        await App.Current.MainPage.DisplayAlert("Success", "You have successfully signed up.", "OK");

        try
        {
            await Shell.Current.GoToAsync($"///LoginPage", true,
                                            new Dictionary<string, object>
                                            {
                                                { "User", user }
                                            });

            await App.Database.SaveUserAsync(user);

        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    [RelayCommand]
    async Task CancelAsync()
    {
        await Shell.Current.GoToAsync($"///LoginPage", true);
    }

    //clear fields method to be used when page opens
    public void ClearFields()
    {
        UserEmail = string.Empty;
        Password = string.Empty;
        IsSinger = false;
    }
}