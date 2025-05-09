using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.ViewModels;

public partial class SingerProfileViewModel : BaseViewModel

{
    [ObservableProperty] private string name;
    [ObservableProperty] private string genre;
    [ObservableProperty] private string location;
    [ObservableProperty] private string aboutMe;
    [ObservableProperty] private ObservableCollection<Booking> bookings;

    public SingerProfileViewModel(Singer singer)
    {
        Name = singer.Name;
        Genre = singer.Genre;
        Location = singer.Location;
        AboutMe = singer.AboutMe;

        LoadBookings(singer.UserEmail);
    }

    private async void LoadBookings(string email)
    {
        var result = await App.Database.GetSingerBookingsAsync(email);
        Bookings = new ObservableCollection<Booking>(result);
    }
}
