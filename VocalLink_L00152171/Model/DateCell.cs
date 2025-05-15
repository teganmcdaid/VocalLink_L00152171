
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace VocalLink_L00152171.Model;

//want to make observable object so that it will be able to notify the view when the data changes
public partial class DateCell : ObservableObject
{
    [ObservableProperty] private DateTime date;
    [ObservableProperty] private string status; 

    public bool IsAvailable => Status == "Available";
}
