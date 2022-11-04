using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorPickerExtraLib.Converters
{
    public class InverseDarkOrLightColorConverter : IMultiValueConverter
    {
        #region IValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 0)
            {
                return Brushes.White;
            }

            Color? color = values[0] as Color?;
            Color? dark = Colors.Black;
            Color? light = Colors.White;
            bool? usingAlphaChannel = false;

            if (values.Length == 4 && values[1].GetType() == typeof(Color) && values[2].GetType() == typeof(Color))
            {
                dark = values[1] as Color?;
                light = values[2] as Color?;
                usingAlphaChannel = values[3] as bool?;
            }

            if (!color.HasValue)
            {
                return Brushes.White;
            }

            return GetInverseColorBrush(color.Value, dark.Value, light.Value, usingAlphaChannel.Value);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        // Ported from "Mark Random" and "Germain" at
        // https://stackoverflow.com/questions/3942878/how-to-decide-font-color-in-white-or-black-depending-on-background-color/
        private static Brush GetInverseColorBrush(Color color, Color dark, Color light, bool? useAlpha = false)
        {
            if (useAlpha.HasValue && useAlpha.Value)
            {
                return ((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114) + ((255.0 - color.A) / 255.0 * 255.0) > 186) ? new SolidColorBrush(dark) : new SolidColorBrush(light);
            }
            else
            {
                return ((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114) > 186) ? new SolidColorBrush(dark) : new SolidColorBrush(light);
            }
        }
    }
}
