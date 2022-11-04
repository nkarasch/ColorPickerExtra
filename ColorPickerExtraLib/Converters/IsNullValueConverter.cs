using System;
using System.Globalization;
using System.Windows.Data;

namespace ColorPickerExtraLib.Converters
{
    public class IsNullValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return true;
            }

            if (value is double?)
            {
                double? valueDouble = (double?)value;
                return !valueDouble.HasValue || (valueDouble.HasValue && valueDouble.Value <= 0.0);
            }

            return false; // value-type
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
