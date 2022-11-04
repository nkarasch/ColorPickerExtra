using System.Windows;

namespace ColorPickerExtraLib.Models
{
    public class ColorPropertyRoutedEventArgs : RoutedEventArgs
    {
        public ColorPropertyRoutedEventArgs(RoutedEvent routedEvent, string valueType, double value) : base(routedEvent)
        {
            this.Value = value;
            this.ValueType = valueType;
        }

        public string ValueType { get; private set; }
        public double Value { get; private set; }
    }
}
