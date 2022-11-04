
/* Unmerged change from project 'ColorPickerExtraLib (netcoreapp3.1)'
Before:
using System.ComponentModel;
After:
using ColorPickerExtraLib.Models;
using System.ComponentModel;
*/
using ColorPickerExtraLib.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls.LinearSliders
{
    [TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
    internal abstract class AColorSlider : Slider, INotifyPropertyChanged
    {
        private Thumb partThumb;

        public AColorSlider()
        {
            SmallChange = 1;
            LargeChange = 10;
            MinHeight = 12;
            PreviewMouseWheel += OnPreviewMouseWheel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Base Class Overrides

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (partThumb != null)
            {
                partThumb.MouseEnter -= new MouseEventHandler(Thumb_MouseEnter);
            }

            partThumb = (Thumb)GetTemplateChild("PART_Thumb");
            partThumb.MouseEnter += new MouseEventHandler(Thumb_MouseEnter);
        }

        public override void EndInit()
        {
            base.EndInit();
            Background = backgroundBrush;
            GenerateBackground();
        }

        protected abstract void GenerateBackground();

        #endregion Base Class Overrides

        #region Properties

        #region Dependency Properties

        public static readonly DependencyProperty CurrentColorStateProperty =
            DependencyProperty.Register(nameof(CurrentColorState), typeof(ColorState), typeof(AColorSlider),
                new PropertyMetadata(ColorStateChangedCallback));

        public static readonly DependencyProperty SmallChangeBindableProperty =
            DependencyProperty.Register(nameof(SmallChangeBindable), typeof(double), typeof(AColorSlider),
                new PropertyMetadata(1.0, SmallChangeBindableChangedCallback));

        public static readonly DependencyProperty SliderTypeProperty =
            DependencyProperty.Register(nameof(SliderType), typeof(string), typeof(AColorSlider),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty UseRectangularStyleProperty =
            DependencyProperty.Register(nameof(UseRectangularStyle), typeof(bool), typeof(AColorSlider),
                new PropertyMetadata(false));

        public bool UseRectangularStyle
        {
            get => (bool)GetValue(UseRectangularStyleProperty);
            set => SetValue(UseRectangularStyleProperty, value);
        }

        public string SliderType
        {
            get => (string)GetValue(SliderTypeProperty);
            set => SetValue(SliderTypeProperty, value);
        }

        public double SmallChangeBindable
        {
            get => (double)GetValue(SmallChangeBindableProperty);
            set => SetValue(SmallChangeBindableProperty, value);
        }

        public ColorState CurrentColorState
        {
            get => (ColorState)GetValue(CurrentColorStateProperty);
            set => SetValue(CurrentColorStateProperty, value);
        }

        #endregion Dependency Properties

        private readonly LinearGradientBrush backgroundBrush = new LinearGradientBrush();

        public GradientStopCollection BackgroundGradient
        {
            get => backgroundBrush.GradientStops;
            set => backgroundBrush.GradientStops = value;
        }

        private SolidColorBrush leftCapColor = new SolidColorBrush();

        public SolidColorBrush LeftCapColor
        {
            get => leftCapColor;
            set
            {
                leftCapColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LeftCapColor)));
            }
        }

        private SolidColorBrush rightCapColor = new SolidColorBrush();

        public SolidColorBrush RightCapColor
        {
            get => rightCapColor;
            set
            {
                rightCapColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RightCapColor)));
            }
        }

        #endregion Properties

        #region Events

        protected static void ColorStateChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AColorSlider slider = (AColorSlider)d;
            slider.GenerateBackground();
        }

        private static void SmallChangeBindableChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AColorSlider)d).SmallChange = (double)e.NewValue;
        }

        private void Thumb_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MouseButtonEventArgs args = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left)
                {
                    RoutedEvent = MouseLeftButtonDownEvent
                };

                (sender as Thumb).RaiseEvent(args);
            }
        }

        private void OnPreviewMouseWheel(object sender, MouseWheelEventArgs args)
        {
            Value = MathHelper.Clamp(Value + (SmallChange * args.Delta / 120), Minimum, Maximum);
            args.Handled = true;
        }

        #endregion Events        
    }
}
