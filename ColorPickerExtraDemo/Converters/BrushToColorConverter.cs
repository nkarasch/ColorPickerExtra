using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorPickerExtraDemo.Converters
{
    [ValueConversion(typeof(SolidColorBrush), typeof(Color))]
    internal class BrushToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }
            SolidColorBrush c = (SolidColorBrush)value;
            Color col = Color.FromArgb(c.Color.A, c.Color.R, c.Color.G, c.Color.B);
            return col;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color col = (Color)value;
            Color c = Color.FromArgb(col.A, col.R, col.G, col.B);
            return new SolidColorBrush(c);
        }
    }
}
