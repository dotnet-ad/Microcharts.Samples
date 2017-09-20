namespace Bikr
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class IsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (value?.ToString() == parameter?.ToString());

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
