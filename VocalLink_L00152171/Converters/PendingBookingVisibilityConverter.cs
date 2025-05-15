using System.Globalization;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.Converters
{
    
        public class PendingBookingVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var booking = value as Booking;
                if (booking == null) return false;

            var isSinger = Preferences.Default.Get("IsSinger", false);
                return booking.Status == "Pending" && isSinger;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                => throw new NotImplementedException();
        
    }
}
