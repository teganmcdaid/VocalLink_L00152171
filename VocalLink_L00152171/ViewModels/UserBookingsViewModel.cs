using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.ViewModels;

public partial class UserBookingsViewModel : BaseViewModel
{
    //used for bookings for the bookings list
    [ObservableProperty]
    private ObservableCollection<Booking> bookings;

    public UserBookingsViewModel()
    {

    }

    public async void LoadBookingsAsync()
    {
        //retrieve bookings for list
        var userEmail = Preferences.Default.Get("UserEmail", string.Empty);
        var isSinger = Preferences.Default.Get("IsSinger", false);

        if (string.IsNullOrWhiteSpace(userEmail))
            return;

        var bookingList = isSinger
            ? await App.Database.GetSingerBookingsAsync(userEmail)
            : await App.Database.GetBusinessBookingsAsync(userEmail);

        Bookings = new ObservableCollection<Booking>(bookingList);
    }

    [RelayCommand]
    private async Task Accept(Booking booking)
    {
        booking.Status = "Booked";
        await App.Database.SaveBookingAsync(booking);
        await Shell.Current.DisplayAlert("Accepted", "Booking accepted.", "OK");
        LoadBookingsAsync();
    }

    [RelayCommand]
    private async Task Decline(Booking booking)
    {
        booking.Status = "Declined";
        await App.Database.SaveBookingAsync(booking);
        await Shell.Current.DisplayAlert("Declined", "Booking declined.", "OK");
        LoadBookingsAsync();
    }
}