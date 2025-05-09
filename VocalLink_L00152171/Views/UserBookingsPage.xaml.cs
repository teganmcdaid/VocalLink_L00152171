using Syncfusion.Maui.Scheduler;

namespace VocalLink_L00152171.Views;

public partial class UserBookingsPage : ContentPage
{
	public UserBookingsPage()
	{
		InitializeComponent();
        SfScheduler scheduler = new SfScheduler();
        scheduler.View = SchedulerView.Month;
        this.Content = scheduler;
    }
}