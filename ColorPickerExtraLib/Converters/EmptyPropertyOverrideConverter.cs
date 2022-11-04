using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorPickerExtraLib.Converters
{
    public class EmptyPropertyOverrideConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[0] == null || values[2] == null || values.Length < 3)
            {
                return null;
            }

            bool isEmpty = (bool)values[2];
            if (!isEmpty)
            {
                return values[0];
            }

            switch (values[0])
            {
                case FontFamily fontFamily:
                    return GetFontFamily(fontFamily, values[1]);
                case double _double:
                    return GetDouble(_double, values[1]);
                case FontStyle fontStyle:
                    return GetFontStyle(fontStyle, values[1]);
                case FontWeight fontWeight:
                    return GetFontWeight(fontWeight, values[1]);
                case HorizontalAlignment horizontalAlignment:
                    return GetHorizontalAlignment(horizontalAlignment, values[1]);
                case VerticalAlignment verticalAlignment:
                    return GetVerticalAlignment(verticalAlignment, values[1]);
                case Thickness thickness:
                    return GetThickness(thickness, values[1]);
                case Stretch stretch:
                    return GetStretch(stretch, values[1]);
                case TextDecorationCollection textDecorations:
                    return GetTextDecoration(textDecorations, values[1]);
                default:
                    break;
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static object GetDouble(double fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null && emptyModeValue is double value && value >= 0.1)
            {
                return emptyModeValue;
            }

            if (fontModeValue >= 0.1)
            {
                return fontModeValue;
            }

            return 0.1;
        }

        private static object GetTextDecoration(TextDecorationCollection fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null)
            {
                return emptyModeValue;
            }

            if (fontModeValue != null)
            {
                return fontModeValue;
            }

            return null;
        }

        private static object GetFontStyle(FontStyle fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null)
            {
                if (emptyModeValue is FontStyle? && (emptyModeValue as FontStyle?).HasValue)
                {
                    return (emptyModeValue as FontStyle?).Value;
                }

                if (emptyModeValue is FontStyle)
                {
                    return emptyModeValue;
                }
            }

            return fontModeValue;
        }

        private static object GetFontWeight(FontWeight fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null)
            {
                if (emptyModeValue is FontWeight? && (emptyModeValue as FontWeight?).HasValue)
                {
                    return (emptyModeValue as FontWeight?).Value;
                }

                if (emptyModeValue is FontWeight)
                {
                    return emptyModeValue;
                }
            }

            return fontModeValue;
        }

        private static object GetHorizontalAlignment(HorizontalAlignment fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null)
            {
                if (emptyModeValue is HorizontalAlignment? && (emptyModeValue as HorizontalAlignment?).HasValue)
                {
                    return (emptyModeValue as HorizontalAlignment?).Value;
                }

                if (emptyModeValue is HorizontalAlignment)
                {
                    return emptyModeValue;
                }
            }

            return fontModeValue;
        }

        private static object GetVerticalAlignment(VerticalAlignment fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null)
            {
                if (emptyModeValue is VerticalAlignment? && (emptyModeValue as VerticalAlignment?).HasValue)
                {
                    return (emptyModeValue as VerticalAlignment?).Value;
                }

                if (emptyModeValue is VerticalAlignment)
                {
                    return emptyModeValue;
                }
            }

            return fontModeValue;
        }

        private static object GetThickness(Thickness fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null)
            {
                if (emptyModeValue is Thickness? && (emptyModeValue as Thickness?).HasValue)
                {
                    return (emptyModeValue as Thickness?).Value;
                }

                if (emptyModeValue is Thickness)
                {
                    return emptyModeValue;
                }
            }

            return fontModeValue;
        }

        private static object GetStretch(Stretch fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null)
            {
                if (emptyModeValue is Stretch? && (emptyModeValue as Stretch?).HasValue)
                {
                    return (emptyModeValue as Stretch?).Value;
                }

                if (emptyModeValue is Stretch)
                {
                    return emptyModeValue;
                }
            }

            return fontModeValue;
        }

        private static object GetFontFamily(FontFamily fontModeValue, object emptyModeValue)
        {
            if (emptyModeValue != null)
            {
                return emptyModeValue;
            }

            return fontModeValue;
        }
    }
}
