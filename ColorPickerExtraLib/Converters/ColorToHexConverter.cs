namespace ColorPickerExtraLib.Converters
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;

    [ValueConversion(typeof(Color), typeof(string))]
    internal class ColorToHexConverter : DependencyObject, IValueConverter
    {
        private static readonly DependencyProperty UsingAlphaChannelProperty =
            DependencyProperty.Register(nameof(UsingAlphaChannel), typeof(bool), typeof(ColorToHexConverter),
                new PropertyMetadata(true, UsingAlphaChannelChangedCallback));

        public bool UsingAlphaChannel
        {
            get => (bool)GetValue(UsingAlphaChannelProperty);
            set => SetValue(UsingAlphaChannelProperty, value);
        }

        public event EventHandler OnUsingAlphaChannelChange;

        public void RaiseUsingAlphaChannelChange()
        {
            OnUsingAlphaChannelChange(this, EventArgs.Empty);
        }

        private static void UsingAlphaChannelChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ColorToHexConverter)d).RaiseUsingAlphaChannelChange();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!UsingAlphaChannel)
            {
                return ConvertNoAlpha(value);
            }

            return ((Color)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!UsingAlphaChannel)
            {
                return ConvertBackNoAlpha(value);
            }

            string text = (string)value;
            text = Regex.Replace(text.ToUpperInvariant(), @"[^0-9A-F]", string.Empty);
            StringBuilder final = new StringBuilder();
            if (text.Length == 3) // short hex with no alpha
            {
                final.Append("#FF").Append(text[0]).Append(text[0]).Append(text[1]).Append(text[1]).Append(text[2]).Append(text[2]);
            }
            else if (text.Length == 4) // short hex with alpha
            {
                final.Append("#").Append(text[0]).Append(text[0]).Append(text[1]).Append(text[1]).Append(text[2]).Append(text[2]).Append(text[3]).Append(text[3]);
            }
            else if (text.Length == 6) // hex with no alpha
            {
                final.Append("#FF").Append(text);
            }
            else
            {
                final.Append("#").Append(text);
            }

            try
            {
                return ColorConverter.ConvertFromString(final.ToString());
            }
            catch (Exception)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertNoAlpha(object value)
        {
            return "#" + ((Color)value).ToString().Substring(3, 6);
        }

        public object ConvertBackNoAlpha(object value)
        {
            string text = (string)value;
            text = Regex.Replace(text.ToUpperInvariant(), @"[^0-9A-F]", string.Empty);
            StringBuilder final = new StringBuilder();
            if (text.Length == 3) // short hex
            {
                final.Append("#FF").Append(text[0]).Append(text[0]).Append(text[1]).Append(text[1]).Append(text[2]).Append(text[2]);
            }
            else if (text.Length == 4)
            {
                return DependencyProperty.UnsetValue;
            }
            else if (text.Length > 6)
            {
                return DependencyProperty.UnsetValue;
            }
            else // regular hex
            {
                final.Append("#").Append(text);
            }

            try
            {
                return ColorConverter.ConvertFromString(final.ToString());
            }
            catch (Exception)
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
