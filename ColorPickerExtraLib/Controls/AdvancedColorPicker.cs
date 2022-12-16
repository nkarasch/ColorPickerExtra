namespace ColorPickerExtraLib.Controls
{
    using System.Windows;
    using System.Windows.Media;
    using ColorPickerExtraLib.Models;

    public class AdvancedColorPicker : AdvancedControlBase
    {
        static AdvancedColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AdvancedColorPicker), new FrameworkPropertyMetadata(typeof(AdvancedColorPicker)));
        }

        #region Public Properties

        public static readonly DependencyProperty SmallChangeProperty =
            DependencyProperty.Register(nameof(SmallChange), typeof(double), typeof(AdvancedColorPicker),
                new PropertyMetadata(1.0));

        public static readonly DependencyProperty AdvancedPickerTypeProperty =
            DependencyProperty.Register(nameof(AdvancedPickerType), typeof(AdvancedPickerType), typeof(AdvancedColorPicker),
                    new PropertyMetadata(AdvancedPickerType.HSV));

        public static readonly DependencyProperty AdvancedInnerBorderBrushProperty =
            DependencyProperty.Register(nameof(AdvancedInnerBorderBrush), typeof(Brush), typeof(AdvancedColorPicker),
                new PropertyMetadata(Brushes.DarkGray));

        public static readonly DependencyProperty AdvancedInnerBorderWidthProperty =
            DependencyProperty.Register(nameof(AdvancedInnerBorderWidth), typeof(double), typeof(AdvancedColorPicker),
                new PropertyMetadata(1.0));

        public double SmallChange
        {
            get => (double)GetValue(SmallChangeProperty);
            set => SetValue(SmallChangeProperty, value);
        }

        public AdvancedPickerType AdvancedPickerType
        {
            get => (AdvancedPickerType)GetValue(AdvancedPickerTypeProperty);
            set => SetValue(AdvancedPickerTypeProperty, value);
        }

        public Brush AdvancedInnerBorderBrush
        {
            get => (Brush)GetValue(AdvancedInnerBorderBrushProperty);
            set => SetValue(AdvancedInnerBorderBrushProperty, value);
        }

        public double AdvancedInnerBorderWidth
        {
            get => (double)GetValue(AdvancedInnerBorderWidthProperty);
            set => SetValue(AdvancedInnerBorderWidthProperty, value);
        }

        #endregion Public Properties
    }
}