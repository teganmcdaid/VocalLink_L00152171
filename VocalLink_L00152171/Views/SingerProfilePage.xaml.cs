using VocalLink_L00152171.Model;
using VocalLink_L00152171.ViewModels;

namespace VocalLink_L00152171.Views;

public partial class SingerProfilePage : ContentPage
{
	public SingerProfilePage(Singer selectedSinger)
	{
		InitializeComponent();
        BindingContext = new SingerProfileViewModel(selectedSinger);
    }
}