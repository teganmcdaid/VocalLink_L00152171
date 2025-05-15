using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VocalLink_L00152171.Model;
using VocalLink_L00152171.Views;

namespace VocalLink_L00152171.ViewModels;

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

    public HomePageViewModel()
    {
        //IsSinger = Preferences.Default.Get("IsSinger", false);
        //UserEmail = Preferences.Default.Get("UserEmail", "Default");

    }

    public async Task LoadDataAsync()
    {
        IsSinger = Preferences.Default.Get("IsSinger", false);
        UserEmail = Preferences.Default.Get("UserEmail", "Default");

        if (IsSinger)
        {
            await LoadBookingsAsync(UserEmail);
            Singers = new ObservableCollection<Singer>(); // Clear singers
        }
        else
        {
            await LoadSingers();
            Bookings = new ObservableCollection<Booking>(); // Clear bookings
        }
    }

    public async Task LoadSingers()
    {
        var singerList = await App.Database.GetAllSingersAsync();
        Singers = new ObservableCollection<Singer>(singerList);
    }

    [RelayCommand]
    async Task ViewProfileAsync(Singer selectedSinger)
    {
        if (selectedSinger == null)
        {
            await Shell.Current.DisplayAlert("Error", "No singer selected.", "OK");
            return;
        }

        //pass the singer data to the profile page
        await Shell.Current.Navigation.PushAsync(new SingerProfilePage(selectedSinger));

    }

    private async Task LoadBookingsAsync(string email)
    {
        var allBookings = await App.Database.GetSingerBookingsAsync(email);

        var filtered = allBookings
            .Where(b => b.Status == "Booked" && b.Date >= DateTime.Today)
            .OrderBy(b => b.Date)
            .Take(5)
            .ToList();

        Bookings = new ObservableCollection<Booking>(filtered);
    }
}