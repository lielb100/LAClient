﻿using System;
using System.Windows.Data;

namespace LAClient
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class BoolToYNConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? "Yes" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}