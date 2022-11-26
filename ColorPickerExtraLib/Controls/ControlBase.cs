using ColorPickerExtraLib.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls
{
    public abstract class ControlBase : Control
    {
        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(nameof(ColorChanged),
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlBase));

        public event RoutedEventHandler ColorChanged
        {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        #region Public Properties

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register(nameof(SelectedColor), typeof(Color), typeof(ControlBase),
                new PropertyMetadata(Colors.Red, OnSelectedColorPropertyChange));

        public static readonly DependencyProperty SecondaryColorProperty =
            DependencyProperty.Register(nameof(SecondaryColor), typeof(Color), typeof(ControlBase),
                new PropertyMetadata(Colors.White, OnSecondaryColorPropertyChange));

        public static readonly DependencyProperty UseRectangularStyleProperty =
            DependencyProperty.Register(nameof(UseRectangularStyle), typeof(bool), typeof(ControlBase),
                new PropertyMetadata(false));

        public static readonly DependencyProperty UsingAlphaChannelProperty =
            DependencyProperty.Register(nameof(UsingAlphaChannel), typeof(bool), typeof(ControlBase),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty EnableEmptyModeProperty =
            DependencyProperty.Register(nameof(EnableEmptyMode), typeof(bool), typeof(ControlBase),
                new PropertyMetadata(false));

        public static readonly DependencyProperty IsEmptyProperty =
            DependencyProperty.Register(nameof(IsEmpty), typeof(bool), typeof(ControlBase),
                new PropertyMetadata(false, OnIsEmptyChanged));

        public static readonly DependencyProperty EmptyButtonTextProperty =
            DependencyProperty.Register(nameof(EmptyButtonText), typeof(string), typeof(ControlBase),
                new PropertyMetadata("Empty"));

        public bool UsingAlphaChannel
        {
            get => (bool)GetValue(UsingAlphaChannelProperty);
            set => SetValue(UsingAlphaChannelProperty, value);
        }

        public bool UseRectangularStyle
        {
            get => (bool)GetValue(UseRectangularStyleProperty);
            set => SetValue(UseRectangularStyleProperty, value);
        }

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        public Color SecondaryColor
        {
            get => (Color)GetValue(SecondaryColorProperty);
            set => SetValue(SecondaryColorProperty, value);
        }

        public bool IsEmpty
        {
            get => (bool)GetValue(IsEmptyProperty);
            set => SetValue(IsEmptyProperty, value);
        }

        public bool EnableEmptyMode
        {
            get => (bool)GetValue(EnableEmptyModeProperty);
            set => SetValue(EnableEmptyModeProperty, value);
        }

        public string EmptyButtonText
        {
            get => (string)GetValue(EmptyButtonTextProperty);
            set => SetValue(EmptyButtonTextProperty, value);
        }

        #endregion Public Properties

        #region Internal Properties

        internal static readonly DependencyProperty IsIndependentProperty =
            DependencyProperty.Register(nameof(IsIndependent), typeof(bool), typeof(ControlBase),
                new PropertyMetadata(true));

        internal bool IsIndependent
        {
            get => (bool)GetValue(IsIndependentProperty);
            set => SetValue(IsIndependentProperty, value);
        }

        #endregion Internal Properties

        #region Event Handlers      

        internal abstract void OnSelectedColorChanged(Color newColor);

        private static void OnSelectedColorPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if(d is ControlBase control && (control.IsIndependent || control is PortableColorPicker))
            {
                control.RaiseEvent(new ColorRoutedEventArgs(ColorChangedEvent, (Color)args.NewValue));
            }

            (d as ControlBase).OnSelectedColorChanged((Color)args.NewValue);
        }

        private static void OnSecondaryColorPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AdvancedControlBase advancedControlBase)
            {
                advancedControlBase.OnSecondaryColorPropertyChange((Color)e.NewValue);
            }
        }

        private static void OnIsEmptyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PortableColorPicker portableColorPicker)
            {
                portableColorPicker.OnIsEmptyChanged();
            }
        }

        #endregion Event Handlers
    }
}
