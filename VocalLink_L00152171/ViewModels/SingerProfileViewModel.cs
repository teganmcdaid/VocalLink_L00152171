// <copyright file="SingerProfileViewModel.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.ViewModels
{
    using System.Collections.ObjectModel;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using Syncfusion.Maui.Scheduler;
    using VocalLink_L00152171.Model;

    /// <summary>
    /// Singer profile view model for all Singer profile page logic.
    /// </summary>
    public partial class SingerProfileViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string singerEmail;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string genre;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private string aboutMe;

        [ObservableProperty]
        private ObservableCollection<Booking> bookings;

        [ObservableProperty]
        private ObservableCollection<DateCell> dateCells;

        // get day of week for calendar header
        private DateTime today = DateTime.Today;

        [ObservableProperty]
        private DateTime startDate = DateTime.Today;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingerProfileViewModel"/> class.
        /// </summary>
        /// <param name="singer"> Passes in the singers profile to retreive.</param>
        public SingerProfileViewModel(Singer singer)
        {
            this.SingerEmail = singer.UserEmail;
            this.Name = singer.Name;
            this.Genre = singer.Genre;
            this.Location = singer.Location;
            this.AboutMe = singer.AboutMe;

            this.LoadBookingsAndCalendar(singer.UserEmail);
        }

        /// <summary>
        /// Gets the list of aligned week days for the calendar header.
        /// </summary>
        public List<string> AlignedWeekDays
        {
            get
            {
                string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

                // calculate the offset based on the StartDates DayOfWeek
                int offset = (int)this.StartDate.DayOfWeek;
                return days.Skip(offset).Concat(days.Take(offset)).ToList();
            }
        }

        /// <summary>
        /// Handles the tap event on a date cell in the calendar.
        /// </summary>
        /// <param name="cell"> The date cell which is tapped. </param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [RelayCommand]
        public async Task DateTapped(DateCell cell)
        {
            // check if data is unavailable
            if (cell == null || cell.Status != "Available")
            {
                await Shell.Current.DisplayAlert("Unavailable", "This date is not available.", "OK");
                return;
            }

            // get user to confirm booking before booking
            bool confirm = await Shell.Current.DisplayAlert("Confirm Booking", $"Book this singer for {cell.Date:dd MMM yyyy}?", "Yes", "No");
            if (!confirm)
            {
                return;
            }

            // Get currently logged-in user's email from Preferences
            string businessEmail = Preferences.Default.Get("UserEmail", string.Empty);

            var booking = new Booking
            {
                SingerEmail = this.SingerEmail,
                SingerName = this.Name,
                BusinessEmail = businessEmail,
                Date = cell.Date,
                Status = "Pending",
            };

            await App.Database.SaveBookingAsync(booking);

            System.Diagnostics.Debug.WriteLine($"Booking made by {businessEmail} for singer {this.SingerEmail} on {cell.Date}");

            await Shell.Current.DisplayAlert("Success", "Booking request sent!", "OK");

            // refresh the calendar
            this.LoadBookingsAndCalendar(this.SingerEmail);
        }

        private async void LoadBookingsAndCalendar(string email)
        {
            var result = await App.Database.GetSingerBookingsAsync(email);
            this.Bookings = new ObservableCollection<Booking>(result);

            var today = DateTime.Today;
            var dates = new ObservableCollection<DateCell>();

            for (int i = 0; i < 30; i++)
            {
                var date = today.AddDays(i);
                var status = "Available";

                var existingBooking = result.FirstOrDefault(b => b.Date.Date == date);
                if (existingBooking != null)
                {
                    status = existingBooking.Status;
                }

                dates.Add(new DateCell
                {
                    Date = date,
                    Status = status,
                });
            }

            this.DateCells = dates;
        }
    }
}
