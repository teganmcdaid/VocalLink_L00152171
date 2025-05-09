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
    private ObservableCollection<Singer> singers;

    public HomePageViewModel()
    {
        IsSinger = Preferences.Default.Get("IsSinger", false);

        if (!IsSinger)
        {
            LoadSingers();
        }
    }

    private async void LoadSingers()
    {
        var singerList = await App.Database.GetAllSingersAsync();
        Singers = new ObservableCollection<Singer>(singerList);
    }

    [RelayCommand]
    async Task ViewProfileAsync(Singer selectedSinger)
    {
        if (selectedSinger == null) {
            await Shell.Current.DisplayAlert("Error", "No singer selected.", "OK");
            return;
        }

        //pass the singer data to the profile page
        await Shell.Current.Navigation.PushAsync(new SingerProfilePage(selectedSinger));

    }
}