using VocalLink_L00152171.Model;
using VocalLink_L00152171.ViewModels;
using Syncfusion.Maui.Scheduler;

namespace VocalLink_L00152171.Views;

public partial class SingerProfilePage : ContentPage
{
    public SingerProfilePage(Singer selectedSinger)
    {
        InitializeComponent();
        BindingContext = new SingerProfileViewModel(selectedSinger);
    }

    private void Scheduler_Tapped(object sender, SchedulerTappedEventArgs e)
    {
        if (BindingContext is SingerProfileViewModel vm)
        {
            //vm.SchedulerTappedCommand.Execute(e);
        }
    }
}