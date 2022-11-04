
/* Unmerged change from project 'ColorPickerExtraLib (netcoreapp3.1)'
Before:
using System.Windows;
After:
using ColorPickerExtraLib.Models;
using System.Windows;
*/
using ColorPickerExtraLib.Models;
using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls
{
    internal class SquarePicker : AdvancedControlBase
    {
        static SquarePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SquarePicker), new FrameworkPropertyMetadata(typeof(SquarePicker)));
        }

        public SquarePicker() : base() { }

        public static readonly DependencyProperty AdvancedPickerTypeProperty =
            DependencyProperty.Register(nameof(AdvancedPickerType), typeof(AdvancedPickerType), typeof(SquarePicker),
                new PropertyMetadata(AdvancedPickerType.HSV));

        public static readonly DependencyProperty SmallChangeProperty =
            DependencyProperty.Register(nameof(SmallChange), typeof(double), typeof(SquarePicker),
                new PropertyMetadata(1.0));

        public static readonly DependencyProperty AdvancedInnerBorderBrushProperty =
            DependencyProperty.Register(nameof(AdvancedInnerBorderBrush), typeof(Brush), typeof(SquarePicker),
                new PropertyMetadata(Brushes.DarkGray));

        public static readonly DependencyProperty AdvancedInnerBorderWidthProperty =
            DependencyProperty.Register(nameof(AdvancedInnerBorderWidth), typeof(double), typeof(SquarePicker),
                new PropertyMetadata(1.0));

        public AdvancedPickerType AdvancedPickerType
        {
            get => (AdvancedPickerType)GetValue(AdvancedPickerTypeProperty);
            set => SetValue(AdvancedPickerTypeProperty, value);
        }

        public double SmallChange
        {
            get => (double)GetValue(SmallChangeProperty);
            set => SetValue(SmallChangeProperty, value);
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
    }
}
