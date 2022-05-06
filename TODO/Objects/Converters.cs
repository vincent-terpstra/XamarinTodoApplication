using System;
using System.Globalization;
using Xamarin.Forms;

namespace TODO.Objects;

public class DateTimeToString : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((DateTime) value).ToString("MMM dd, yyyy");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
