// <copyright file="PendingBookingVisibilityConverter.cs" company="Tegan Mc Daid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Converters
{
    using System.Globalization;
    using VocalLink_L00152171.Model;
    using VocalLink_L00152171.Services;

    /// <summary>
    /// This class is used only allow accept and decline buttons to be visible when user is Singer and booking is pending.
    /// </summary>
    public class PendingBookingVisibilityConverter : IValueConverter
    {
        private IPreferencesWrapper preferences;

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingBookingVisibilityConverter"/> class.
        /// </summary>
        public PendingBookingVisibilityConverter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingBookingVisibilityConverter"/> class.
        /// </summary>
        /// <param name="preferences"> accepts the mock prefernces set in wrapper.</param>
        public PendingBookingVisibilityConverter(IPreferencesWrapper preferences)
        {
            this.preferences = preferences;
        }

        /// method is used to return true if both booking status is pending and user is singer. <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var booking = value as Booking;
            if (booking == null)
            {
                return false;
            }

            if (this.preferences == null)
            {
                // Manually create the default PreferencesWrapper if it's null
                this.preferences = new PreferencesWrapper();
            }

            var isSinger = this.preferences.GetIsSinger();
            return booking.Status == "Pending" && isSinger;
        }

        /// This method is not needed for this functionality. <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
