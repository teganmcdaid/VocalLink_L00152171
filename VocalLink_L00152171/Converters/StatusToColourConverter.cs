using System.Globalization;

namespace VocalLink_L00152171.Converters;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string status = value?.ToString();

        return status switch
        {
            "Available" => Colors.Green,
            "Pending" => Colors.Orange,
            "Booked" => Colors.Blue,
            "Declined" => Colors.Red,
            _ => Colors.LightGray
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}