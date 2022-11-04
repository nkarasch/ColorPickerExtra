using ColorPickerExtraLib.Models;
using System;
using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls
{
    public abstract class AdvancedControlBase : ControlBase, IColorStateStorage, ISecondColorStorage
    {
        private readonly SecondColorDecorator secondColorDecorator;

        private bool ignoreColorPropertyChange = false;
        private bool ignoreColorChange = false;

        private Color previousColor = System.Windows.Media.Color.FromArgb(255, 5, 5, 5);
        private bool ignoreSecondaryColorChange = false;
        private bool ignoreSecondaryColorPropertyChange = false;

        public AdvancedControlBase() : base()
        {
            Color = new NotifyableColor(this);
            Color.PropertyChanged += (sender, args) =>
            {
                Color newColor = System.Windows.Media.Color.FromArgb(
                    (byte)Math.Round(Color.A),
                    (byte)Math.Round(Color.RGB_R),
                    (byte)Math.Round(Color.RGB_G),
                    (byte)Math.Round(Color.RGB_B));
                if (newColor != previousColor)
                {
                    RaiseEvent(new ColorRoutedEventArgs(ColorChangedEvent, newColor));
                    previousColor = newColor;
                }
            };

            ColorChanged += (sender, newColor) =>
            {
                if (!ignoreColorChange)
                {
                    ignoreColorPropertyChange = true;
                    SelectedColor = ((ColorRoutedEventArgs)newColor).Color;
                    ignoreColorPropertyChange = false;
                }
            };

            secondColorDecorator = new SecondColorDecorator(this);
            SecondColor = new NotifyableColor(secondColorDecorator);
            SecondColor.PropertyChanged += (sender, args) =>
            {
                if (!ignoreSecondaryColorChange)
                {
                    ignoreSecondaryColorPropertyChange = true;
                    SecondaryColor = System.Windows.Media.Color.FromArgb((byte)SecondColor.A, (byte)SecondColor.RGB_R, (byte)SecondColor.RGB_G, (byte)SecondColor.RGB_B);
                    ignoreSecondaryColorPropertyChange = false;
                }
            };
        }

        public event RoutedEventHandler ColorChanged
        {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        public void SwapColors()
        {
            ColorState temp = ColorState;
            ColorState = SecondColorState;
            SecondColorState = temp;
        }

        #region Properties  

        public static readonly DependencyProperty ColorStateProperty =
            DependencyProperty.Register(nameof(ColorState), typeof(ColorState), typeof(AdvancedControlBase),
                new PropertyMetadata(new ColorState(1.0, 0, 0, 1, 0, 1, 1, 0, 1, 0.5), OnColorStatePropertyChange));

        internal static readonly DependencyProperty SecondColorStateProperty =
            DependencyProperty.Register(nameof(SecondColorState), typeof(ColorState), typeof(AdvancedControlBase),
                new PropertyMetadata(new ColorState(1, 1, 1, 1, 0, 0, 1, 0, 0, 1), OnSecondColorStatePropertyChange));

        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(nameof(ColorChanged),
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AdvancedControlBase));

        public ColorState ColorState
        {
            get => (ColorState)GetValue(ColorStateProperty);
            set => SetValue(ColorStateProperty, value);
        }

        public ColorState SecondColorState
        {
            get => (ColorState)GetValue(SecondColorStateProperty);
            set => SetValue(SecondColorStateProperty, value);
        }

        public NotifyableColor Color
        {
            get;
            set;
        }

        public NotifyableColor SecondColor
        {
            get;
            set;
        }

        #endregion Properties

        #region Event Handlers

        private static void OnColorStatePropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ((AdvancedControlBase)d).Color.UpdateEverything((ColorState)args.OldValue);
        }

        internal override void OnSelectedColorChanged(Color newColor)
        {
            if (ignoreColorPropertyChange)
                return;
            ignoreColorChange = true;
            Color.A = newColor.A;
            Color.RGB_R = newColor.R;
            Color.RGB_G = newColor.G;
            Color.RGB_B = newColor.B;
            ignoreColorChange = false;
        }

        private static void OnSecondColorStatePropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ((AdvancedControlBase)d).SecondColor.UpdateEverything((ColorState)args.OldValue);
        }

        internal void OnSecondaryColorPropertyChange(Color newColor)
        {
            if (ignoreSecondaryColorPropertyChange)
            {
                return;
            }
            ignoreSecondaryColorChange = true;
            SecondColor.A = newColor.A;
            SecondColor.RGB_R = newColor.R;
            SecondColor.RGB_G = newColor.G;
            SecondColor.RGB_B = newColor.B;
            ignoreSecondaryColorChange = false;
        }

        #endregion Event Handlers    
    }
}
