// <copyright file="SignUpViewModel.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using VocalLink_L00152171.Model;

    /// <summary>
    /// SignUp view model for all signup page logic.
    /// </summary>
    public partial class SignUpViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string userEmail;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isSinger;

        /// <summary>
        /// Method for user to sign up for a new account.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [RelayCommand]
        public async Task SignUpAsync()
        {
            // check if fields are empty
            if (string.IsNullOrWhiteSpace(this.UserEmail) || string.IsNullOrWhiteSpace(this.Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please enter a username and password.", "OK");
                return;
            }

            // pass the user data to the home page
            var user = new User { UserEmail = this.UserEmail, Password = this.Password, IsSinger = this.IsSinger };

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
                if (!this.IsSinger)
                {
                    await Shell.Current.GoToAsync(
                                                    "//LoginPage",
                                                    true,
                                                    new Dictionary<string, object>
                                                    {
                                                        { "User", user },
                                                    });
                }
                else
                {
                    Preferences.Default.Set("UserEmail", user.UserEmail);
                    await Shell.Current.GoToAsync(
                                                    "SingerSetupPage",
                                                    true,
                                                    new Dictionary<string, object>
                                                    {
                                                        { "User", user },
                                                    });
                }

                await App.Database.SaveUserAsync(user);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        /// <summary>
        /// Method to cancel the sign-up process and navigate back to the login page.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("//LoginPage", true);
        }

        /// <summary>
        /// Clear fields method to be used when page opens.
        /// </summary>
        public void ClearFields()
        {
            this.UserEmail = string.Empty;
            this.Password = string.Empty;
            this.IsSinger = false;
        }
    }
}