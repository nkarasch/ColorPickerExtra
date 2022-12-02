using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Models
{
    public class ColorRoutedEventArgs : RoutedEventArgs
    {
        public ColorRoutedEventArgs(RoutedEvent routedEvent, Color color, bool isEmpty = false) : base(routedEvent)
        {
            Color = color;
            IsEmpty = isEmpty;
        }

        public Color Color { get; private set; }
        public bool IsEmpty { get; private set; }
    }
}
