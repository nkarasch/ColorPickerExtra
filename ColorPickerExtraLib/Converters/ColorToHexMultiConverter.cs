namespace ColorPickerExtraLib.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    public class ColorToHexMultiConverter : IMultiValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts a Color to a Hex String.
        /// </summary>
        /// <param name="values">value 1 = Color? value 2 = IsUsingAlphaChannel</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">Not used</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted string. If the value is empty a empty hex string is returned.
        /// </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //values 0 is Color
            //value 1 is UsingAlphaChannel

            if (values != null && values.Length == 2 && values[0] != null && values[1] is bool usingAlphaChannel)
            {
                return usingAlphaChannel ? ((Color)values[0]).ToString() : "#" + ((Color)values[0]).ToString().Substring(3, 6);
            }

            return string.Empty;
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
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new string[] { "Converter Return Not Implemented" };
        }

        #endregion IValueConverter Members
    }
}