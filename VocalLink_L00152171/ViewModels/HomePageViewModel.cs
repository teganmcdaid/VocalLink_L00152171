// <copyright file="HomePageViewModel.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.ViewModels
{
    using System.Collections.ObjectModel;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using VocalLink_L00152171.Model;
    using VocalLink_L00152171.Views;

    /// <summary>
    /// Home Page view model for all home page logic.
    /// </summary>
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isSinger;

        [ObservableProperty]
        private string userEmail;

        [ObservableProperty]
        private ObservableCollection<Singer> singers;

        [ObservableProperty]
        private ObservableCollection<Booking> bookings;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageViewModel"/> class.
        /// </summary>
        public HomePageViewModel()
        {
        }

        /// <summary>
        /// Asynchronously loads the data for the home page.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task LoadDataAsync()
        {
            this.IsSinger = Preferences.Default.Get("IsSinger", false);
            this.UserEmail = Preferences.Default.Get("UserEmail", "Default");

            if (this.IsSinger)
            {
                await this.LoadBookingsAsync(this.UserEmail);
                this.Singers = new ObservableCollection<Singer>(); // Clear singers
            }
            else
            {
                await this.LoadSingers();
                this.Bookings = new ObservableCollection<Booking>(); // Clear bookings
            }
        }

        /// <summary>
        /// Load the list of singers from the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task LoadSingers()
        {
            var singerList = await App.Database.GetAllSingersAsync();
            this.Singers = new ObservableCollection<Singer>(singerList);
        }

        /// <summary>
        /// View profile of the selected singer.
        /// </summary>
        /// <param name="selectedSinger"> Singers profile to vist.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [RelayCommand]
        public async Task ViewProfileAsync(Singer selectedSinger)
        {
            if (selectedSinger == null)
            {
                await Shell.Current.DisplayAlert("Error", "No singer selected.", "OK");
                return;
            }

            // pass the singer data to the profile page
            await Shell.Current.Navigation.PushAsync(new SingerProfilePage(selectedSinger));
        }

        /// <summary>
        /// Edit the profile of the currently logged-in singer.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [RelayCommand]
        public async Task EditProfileAsync()
        {
            await Shell.Current.Navigation.PushAsync(new SingerEditPage());
        }

        private async Task LoadBookingsAsync(string email)
        {
            var allBookings = await App.Database.GetSingerBookingsAsync(email);

            var filtered = allBookings
                .Where(b => b.Status == "Booked" && b.Date >= DateTime.Today)
                .OrderBy(b => b.Date)
                .Take(5)
                .ToList();

            this.Bookings = new ObservableCollection<Booking>(filtered);
        }
    }
}