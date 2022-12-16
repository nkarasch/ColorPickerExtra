namespace ColorPickerExtraDemo.Converters
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    public class EnumToBooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object matchValue, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.GetType().IsEnum)
            {
                return Equals(value, matchValue);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object matchValue, System.Globalization.CultureInfo culture)
        {
            if (value is bool boolean && boolean)
            {
                return matchValue;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        #endregion
    }
}
