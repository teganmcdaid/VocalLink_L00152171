// <copyright file="StatusToColourConverter.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Converters
{
    using System.Globalization;

    /// <summary>
    /// This class is used to assign a colour based on the booking status.
    /// </summary>
    public class StatusToColourConverter : IValueConverter
    {
        /// Method to assign the colours.<inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? status = value?.ToString();

            return status switch
            {
                "Available" => Colors.Green,
                "Pending" => Colors.Orange,
                "Booked" => Colors.Blue,
                "Declined" => Colors.Red,
                _ => Colors.LightGray
            };
        }

        /// This method is not needed for this functionality. <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}