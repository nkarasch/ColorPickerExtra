namespace ColorPickerExtraLib.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using ColorPickerExtraLib.Models;

    [ValueConversion(typeof(AdvancedPickerType), typeof(int))]
    internal class PickerTypeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return false;
            }

            return (int)value == int.Parse(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return null;
            }

            int pickerTypeIndex = int.Parse(parameter.ToString());

            if ((bool)value)
            {
                return (AdvancedPickerType)pickerTypeIndex;
            }
            else
            {
                return pickerTypeIndex == 0 ? (AdvancedPickerType)1 : 0;
            }
        }
    }
}
