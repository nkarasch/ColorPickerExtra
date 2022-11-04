namespace ColorPickerExtraLib.Converters
{
    using ColorPickerExtraLib.Utilities;
    using System;
    using System.Windows.Data;
    using System.Windows.Media;

    public class ColorToBrushWhiteBackgroundConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts an alpha color to a white background version as SolidColorBrush.
        /// </summary>
        /// <param name="value">The Color produced by the binding source with White as background layer for Border and Fonts.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted SolidColorBrush. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color foregroundColor)
            {
                return new SolidColorBrush(ColorUtilities.CombineColors(foregroundColor /*always using white as background*/));
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        /// <summary>
        /// Converts a SolidColorBrush to a Color.
        /// </summary>
        /// <remarks>Currently not used in toolkit, but provided for developer use in their own projects</remarks>
        /// <param name="value">The SolidColorBrush that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return ((SolidColorBrush)value).Color;

            return Colors.Transparent;
        }

        #endregion IValueConverter Members
    }
}
