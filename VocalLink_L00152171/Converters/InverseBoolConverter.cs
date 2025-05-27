// <copyright file="InverseBoolConverter.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Converters
{
    using System;
    using System.Globalization;

    /// <summary>
    /// This class is used to toggle boolean based on value input e.g. true returns false.
    /// </summary>
    public class InverseBoolConverter : IValueConverter
    {
        /// When false true is input false will return, when falue false is input true will return. <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolean)
            {
                return !boolean;
            }

            return false;
        }

        /// This method is not needed for this functionality. <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}