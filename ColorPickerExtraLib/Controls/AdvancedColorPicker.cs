
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
    public class AdvancedColorPicker : AdvancedControlBase
    {
        static AdvancedColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AdvancedColorPicker), new FrameworkPropertyMetadata(typeof(AdvancedColorPicker)));
        }

        public event RoutedEventHandler ColorPropertyChanged
        {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        public static readonly RoutedEvent ColorValueChangedEvent =
            EventManager.RegisterRoutedEvent(nameof(ColorPropertyChanged),
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AdvancedControlBase));

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

        #region Internal Properties

        internal static readonly DependencyProperty IsIndependentProperty =
            DependencyProperty.Register(nameof(IsIndependent), typeof(bool), typeof(AdvancedColorPicker),
                new PropertyMetadata(true));

        internal bool IsIndependent
        {
            get => (bool)GetValue(IsIndependentProperty);
            set => SetValue(IsIndependentProperty, value);
        }

        #endregion Internal Properties
    }
}