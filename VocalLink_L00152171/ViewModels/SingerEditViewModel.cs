// <copyright file="SingerEditViewModel.cs" company="Tgean McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.ViewModels
{
    using System.Collections.ObjectModel;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using VocalLink_L00152171.Model;

    /// <summary>
    /// Singer edit view model for all Singer edit profile page logic.
    /// </summary>
    public partial class SingerEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string genre;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private string aboutMe;

        private string userEmail;

        /// <summary>
        /// Gets the list of genres available for singers.
        /// </summary>
        public ObservableCollection<string> Genres { get; } = new ()
        {
            "Pop", "Country", "Rock", "Jazz", "Acoustic", "Rap", "Folk", "Other",
        };

        /// <summary>
        /// Load the singer's profile data asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task LoadSingerAsync()
        {
            this.userEmail = Preferences.Get("UserEmail", string.Empty);
            var singer = await App.Database.GetSingerProfileAsync(this.userEmail);
            if (singer != null)
            {
                this.Name = singer.Name;
                this.Genre = singer.Genre;
                this.Location = singer.Location;
                this.AboutMe = singer.AboutMe;
            }
        }

        /// <summary>
        /// Method to save the singer's profile changes asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [RelayCommand]
        public async Task SaveAsync()
        {
            // check that user is ready to save
            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to save changes?", "Yes", "No");
            if (!confirm)
            {
                return;
            }

            var updatedSinger = new Singer
            {
                UserEmail = this.userEmail,
                Name = this.Name,
                Genre = this.Genre,
                Location = this.Location,
                AboutMe = this.AboutMe,
            };

            await App.Database.SaveSingerProfileAsync(updatedSinger);
            await Shell.Current.DisplayAlert("Saved", "Your profile has been updated.", "OK");
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task CancelAsync()
        {
            // check that user is sure they want to cancel
            bool confirm = await Shell.Current.DisplayAlert("Cancel", "Discard changes and return to Home?", "Yes", "No");
            if (confirm)
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}