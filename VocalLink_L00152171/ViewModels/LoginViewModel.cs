using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    private string userEmail;

    [ObservableProperty]
    private string password;

    [RelayCommand]
    async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(UserEmail) || string.IsNullOrWhiteSpace(Password))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please enter a Email and Password.", "OK");
            return;
        }


        //pass the user data to the home page
        var user = new User { UserEmail = userEmail, Password = password };

        //getlist of users from databae
        var users = await App.Database.GetUserAsync();

        //set default values to false only change when these are true
        bool registeredUser = false;
        bool incorrectPassword = false;

        //iterate through users
        foreach (var u in users)
        {
            //check if user is stored in database
            if (user.UserEmail == u.UserEmail &&
                user.Password == u.Password)
            {
                //set registered user to true if user is found in database
                registeredUser = true;

                //user is equal to the stored user which has correct corporate status
                user.IsSinger = u.IsSinger;
                await App.Current.MainPage.DisplayAlert("Success", "You have successfully logged in.", "OK");

                try
                {

                    //navigate to HomePage
                    await Shell.Current.GoToAsync($"///HomePage", true,
                                                    new Dictionary<string, object>
                                                    {
                                                { "User", user }
                                                    });
                    //clear prefrences incase previosuly set
                    Preferences.Default.Clear();
                    //set preferences so user will be accessible
                    Preferences.Default.Set("UserEmail", user.UserEmail);
                    Preferences.Default.Set("Password", user.Password);
                    Preferences.Default.Set("IsSinger", user.IsSinger);
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }

            }
            //If Email is in Database and password is incorrect tell user
            else if (user.UserEmail == u.UserEmail && user.Password != u.Password)
                incorrectPassword = true;
        }

        //inform user that password is incorrect, email is already registered
        if (incorrectPassword == true)
            await App.Current.MainPage.DisplayAlert("Error", "Password Incorrect.", "OK");

        //inform user that the account is not found and they need to sign up
        else if (registeredUser == false && incorrectPassword == false)
            await App.Current.MainPage.DisplayAlert("Error", "Account not found. Please sign up", "OK");
    }

    [RelayCommand]
    async Task SignUpAsync()
    {
        try
        {
            await Shell.Current.GoToAsync($"///SignUpPage", true);
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }


    //clear fields when page opens when sign up is cancelled
    public void ClearFields()
    {
        UserEmail = string.Empty;
        Password = string.Empty;
    }
}