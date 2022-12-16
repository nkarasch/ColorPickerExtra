namespace ColorPickerExtraLib.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using ColorPickerExtraLib.Models;
    using ColorPickerExtraLib.Utilities;

    public class EmptyShapeGeometryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ShapeGeometry geometryType = (ShapeGeometry)value;
            return EmptyShapeGeometry.GetShapeGeometry(geometryType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
