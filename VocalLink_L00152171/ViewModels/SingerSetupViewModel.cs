// <copyright file="SingerSetupViewModel.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.ViewModels
{
    using System.Collections.ObjectModel;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using VocalLink_L00152171.Model;

    /// <summary>
    /// Singer setup view model for all Singer setup page logic.
    /// </summary>
    public partial class SingerSetupViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string genre;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private string aboutMe;

        private User currentUser;

        /// <summary>
        /// Gets the list of genres available for singers.
        /// </summary>
        public ObservableCollection<string> Genres { get; } = new ()
        {
            "Pop", "Country", "Rock", "Jazz", "Acoustic", "Rap", "Folk", "Other",
        };

        /// <summary>
        /// Get the current user.
        /// </summary>
        /// <param name="user"> User to set as current user.</param>
        public void SetUser(User user)
        {
            this.currentUser = user;
        }

        /// <summary>
        /// Save updates to the singer's profile asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [RelayCommand]
        public async Task SaveProfileAsync()
        {
            var loggedInEmail = Preferences.Default.Get("UserEmail", "Unknown");
            if (loggedInEmail.Equals("Unknown"))
            {
                await Shell.Current.DisplayAlert("Error", "User data not available.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.Name) || string.IsNullOrWhiteSpace(this.Genre))
            {
                await Shell.Current.DisplayAlert("Error", "Please complete all required fields.", "OK");
                return;
            }

            var singer = new Singer
            {
                UserEmail = loggedInEmail,
                Name = this.Name,
                Genre = this.Genre,
                Location = this.Location,
                AboutMe = this.AboutMe,
            };

            await App.Database.SaveSingerProfileAsync(singer);
            await Shell.Current.DisplayAlert("Success", "Your singer profile has been saved.", "OK");
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}