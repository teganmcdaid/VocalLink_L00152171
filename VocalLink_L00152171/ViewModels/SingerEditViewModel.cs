using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.ViewModels;

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

    public ObservableCollection<string> Genres { get; } = new()
        {
            "Pop","Country", "Rock", "Jazz", "Acoustic", "Rap", "Folk", "Other"
        };

    private string userEmail;

    public async Task LoadSingerAsync()
    {
        userEmail = Preferences.Get("UserEmail", "");
        var singer = await App.Database.GetSingerProfileAsync(userEmail);
        if (singer != null)
        {
            Name = singer.Name;
            Genre = singer.Genre;
            Location = singer.Location;
            AboutMe = singer.AboutMe;
        }
    }

    [RelayCommand]
    async Task SaveAsync()
    {
        //check that user is ready to save 
        bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to save changes?", "Yes", "No");
        if (!confirm) return;

        var updatedSinger = new Singer
        {
            UserEmail = userEmail,
            Name = Name,
            Genre = Genre,
            Location = Location,
            AboutMe = AboutMe
        };

        await App.Database.SaveSingerProfileAsync(updatedSinger);
        await Shell.Current.DisplayAlert("Saved", "Your profile has been updated.", "OK");
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task CancelAsync()
    {
        //check that user is sure they want to cancel
        bool confirm = await Shell.Current.DisplayAlert("Cancel", "Discard changes and return to Home?", "Yes", "No");
        if (confirm)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}