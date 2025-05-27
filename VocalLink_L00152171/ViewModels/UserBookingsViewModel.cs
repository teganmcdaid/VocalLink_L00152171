// <copyright file="UserBookingsViewModel.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.ViewModels
{
    using System.Collections.ObjectModel;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using VocalLink_L00152171.Model;

    /// <summary>
    /// User Bookings view model for all bookings page logic.
    /// </summary>
    public partial class UserBookingsViewModel : BaseViewModel
    {
        // used for bookings for the bookings list
        [ObservableProperty]
        private ObservableCollection<Booking> bookings;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBookingsViewModel"/> class.
        /// </summary>
        public UserBookingsViewModel()
        {
        }

        /// <summary>
        /// Method for loading bookings asynchronously.
        /// </summary>
        public async void LoadBookingsAsync()
        {
            // retrieve bookings for list
            var userEmail = Preferences.Default.Get("UserEmail", string.Empty);
            var isSinger = Preferences.Default.Get("IsSinger", false);

            if (string.IsNullOrWhiteSpace(userEmail))
            {
                return;
            }

            var bookingList = isSinger
                ? await App.Database.GetSingerBookingsAsync(userEmail)
                : await App.Database.GetBusinessBookingsAsync(userEmail);

            this.Bookings = new ObservableCollection<Booking>(bookingList);
        }

        [RelayCommand]
        private async Task Accept(Booking booking)
        {
            booking.Status = "Booked";
            await App.Database.SaveBookingAsync(booking);
            await Shell.Current.DisplayAlert("Accepted", "Booking accepted.", "OK");
            this.LoadBookingsAsync();
        }

        [RelayCommand]
        private async Task Decline(Booking booking)
        {
            booking.Status = "Declined";
            await App.Database.SaveBookingAsync(booking);
            await Shell.Current.DisplayAlert("Declined", "Booking declined.", "OK");
            this.LoadBookingsAsync();
        }
    }
}