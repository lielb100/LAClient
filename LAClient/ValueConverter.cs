using System;
using System.Windows;
using System.Windows.Data;

namespace LAClient
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null)
                return Visibility.Visible;
            bool input = bool.Parse(parameter.ToString());
            input = (MainPage.CurrentUser != null) ? input : !input;

            return (input) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion IValueConverter Members
    }
}