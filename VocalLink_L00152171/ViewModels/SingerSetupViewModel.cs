using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.ViewModels;

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

    public ObservableCollection<string> Genres { get; } = new()
        {
            "Pop","Country", "Rock", "Jazz", "Acoustic", "Rap", "Folk", "Other"
        };

    private User _currentUser;

    public void SetUser(User user)
    {
        _currentUser = user;
    }

    [RelayCommand]
    async Task SaveProfileAsync()
    {
        var loggedInEmail = Preferences.Default.Get("UserEmail", "Unknown");
        if (loggedInEmail.Equals("Unknown"))
        {
            await Shell.Current.DisplayAlert("Error", "User data not available.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Genre))
        {
            await Shell.Current.DisplayAlert("Error", "Please complete all required fields.", "OK");
            return;
        }

        var singer = new Singer
        {
            UserEmail = loggedInEmail,
            Name = Name,
            Genre = Genre,
            Location = Location,
            AboutMe = AboutMe
        };

        await App.Database.SaveSingerProfileAsync(singer);

        await Shell.Current.DisplayAlert("Success", "Your singer profile has been saved.", "OK");
        await Shell.Current.GoToAsync("//LoginPage");
    }
}