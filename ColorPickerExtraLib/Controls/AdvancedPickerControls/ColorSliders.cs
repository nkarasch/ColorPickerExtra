namespace ColorPickerExtraLib.Controls
{
    using System.Windows;

    internal class ColorSliders : AdvancedControlBase
    {
        static ColorSliders()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSliders), new FrameworkPropertyMetadata(typeof(ColorSliders)));
        }

        public ColorSliders() : base() { }

        public static readonly DependencyProperty SmallChangeProperty =
            DependencyProperty.Register(nameof(SmallChange), typeof(double), typeof(ColorSliders),
                new PropertyMetadata(1.0));

        public double SmallChange
        {
            get => (double)GetValue(SmallChangeProperty);
            set => SetValue(SmallChangeProperty, value);
        }
    }
}
