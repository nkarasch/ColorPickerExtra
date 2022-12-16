namespace ColorPickerExtraLib.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    internal class ProportialConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double actual &&
                values[1] is double dimension1 &&
                values[2] is double dimension2)
            {
                return actual * (dimension1 / dimension2);
            }

            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
