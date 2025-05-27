using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Syncfusion.Maui.Scheduler;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.ViewModels;

public partial class SingerProfileViewModel : BaseViewModel

{
    [ObservableProperty] public string singerEmail;
    [ObservableProperty] private string name;
    [ObservableProperty] private string genre;
    [ObservableProperty] private string location;
    [ObservableProperty] private string aboutMe;


    [ObservableProperty] private ObservableCollection<Booking> bookings;
    [ObservableProperty] private ObservableCollection<DateCell> dateCells;

    //get day of week for calendar header
    private DateTime today = DateTime.Today;

    [ObservableProperty]
    private DateTime startDate = DateTime.Today;

    public List<string> AlignedWeekDays
    {
        get
        {
            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            int offset = (int)StartDate.DayOfWeek; // e.g. if StartDate is Wednesday (3)
            return days.Skip(offset).Concat(days.Take(offset)).ToList();
        }
    }


    public SingerProfileViewModel(Singer singer)
    {
        SingerEmail = singer.UserEmail;
        Name = singer.Name;
        Genre = singer.Genre;
        Location = singer.Location;
        AboutMe = singer.AboutMe;

        LoadBookingsAndCalendar(singer.UserEmail);
    }

    private async void LoadBookingsAndCalendar(string email)
    {
        var result = await App.Database.GetSingerBookingsAsync(email);
        Bookings = new ObservableCollection<Booking>(result);

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
                Status = status
            });
        }

        DateCells = dates;
    }

    [RelayCommand]
    async Task DateTapped(DateCell cell)
    {
        //check if data is unavailable
        if (cell == null || cell.Status != "Available")
        {
            await Shell.Current.DisplayAlert("Unavailable", "This date is not available.", "OK");
            return;
        }

        //get user to confirm booking before booking
        bool confirm = await Shell.Current.DisplayAlert("Confirm Booking", $"Book this singer for {cell.Date:dd MMM yyyy}?", "Yes", "No");
        if (!confirm) return;

        // Get currently logged-in user's email from Preferences
        string businessEmail = Preferences.Default.Get("UserEmail", string.Empty);

        var booking = new Booking
        {
            SingerEmail = SingerEmail,
            SingerName = Name,
            BusinessEmail = businessEmail,
            Date = cell.Date,
            Status = "Pending"
        };

        await App.Database.SaveBookingAsync(booking);

        System.Diagnostics.Debug.WriteLine($"Booking made by {businessEmail} for singer {SingerEmail} on {cell.Date}");

        await Shell.Current.DisplayAlert("Success", "Booking request sent!", "OK");

        //refresh the calendar
        LoadBookingsAndCalendar(SingerEmail);
    }
}
