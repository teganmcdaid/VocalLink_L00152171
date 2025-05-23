using System.Globalization;
using VocalLink_L00152171.Model;
using VocalLink_L00152171.Services;

namespace VocalLink_L00152171.Converters
{
    
        public class PendingBookingVisibilityConverter : IValueConverter
        {

        private readonly IPreferencesWrapper _preferences;

        public PendingBookingVisibilityConverter()
        {
        }
        public PendingBookingVisibilityConverter(IPreferencesWrapper preferences)
        {
            _preferences = preferences;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var booking = value as Booking;
            if (booking == null) return false;

            var isSinger = _preferences.GetIsSinger();
            return booking.Status == "Pending" && isSinger;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
