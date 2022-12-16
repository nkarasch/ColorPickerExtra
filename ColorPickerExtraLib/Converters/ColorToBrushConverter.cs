namespace ColorPickerExtraLib.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    [ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    internal class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Brush)
            {
                return value;
            }
            else if (value is Color color)
            {
                return new SolidColorBrush(color);
            }
            else
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush solidColorBrush)
            {
                return solidColorBrush.Color;
            }
            else
            {
                return Colors.White;
            }
        }
    }
}
