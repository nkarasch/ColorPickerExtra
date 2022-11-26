using ColorPickerExtraLib.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls
{
    [TemplatePart(Name = "PART_ColorModeButton", Type = typeof(Button))]
    public partial class ColorPicker : ControlBase
    {
        private Button colorModeButton;

        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }

        public ColorPicker() : base() { }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (colorModeButton != null)
            {
                colorModeButton.Click -= ColorModeButton_Clicked;
            }

            colorModeButton = (Button)GetTemplateChild("PART_ColorModeButton");
            colorModeButton.Click += ColorModeButton_Clicked;
        }

        #region Internal Properties
        internal static readonly DependencyProperty IsPopupOpenProperty =
            DependencyProperty.Register(nameof(IsPopupOpen), typeof(bool), typeof(ColorPicker),
                new UIPropertyMetadata(false, OnIsPopupOpenChanged));

        internal bool IsPopupOpen
        {
            get => (bool)GetValue(IsPopupOpenProperty);
            set => SetValue(IsPopupOpenProperty, value);
        }

        internal static readonly DependencyProperty ToggleButtonStateProperty =
            DependencyProperty.Register(nameof(ToggleButtonState), typeof(ColorPickerState), typeof(ColorPicker),
                new PropertyMetadata(ColorPickerState.Closed, OnToggleButtonStateChanged));

        internal ColorPickerState ToggleButtonState
        {
            get => (ColorPickerState)GetValue(ToggleButtonStateProperty);
            set => SetValue(ToggleButtonStateProperty, value);
        }

        internal static void OnToggleButtonStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && (ColorPickerState)e.NewValue == ColorPickerState.Closed)
            {
                (d as ColorPicker).IsPopupOpen = false;
            }
        }

        #endregion Internal Properties

        #region Event Handlers

        internal override void OnSelectedColorChanged(Color newColor)
        {
            if (IsEmpty)
            {
                IsEmpty = false;
            }
        }

        private static void OnIsPopupOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ColorPicker colorPicker)
            {
                if (colorPicker.IsIndependent)
                {
                    return;
                }

                bool isOpen = (bool)e.NewValue;

                if (isOpen)
                {
                    colorPicker.ToggleButtonState = (colorPicker.BaseColorMode == ColorMode.Standard) ? ColorPickerState.StandardOpen : ColorPickerState.AdvancedOpen;
                }
                else
                {
                    colorPicker.ToggleButtonState = ColorPickerState.Closed;
                }

                return;
            }
        }

        private static void OnColorModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ColorPicker colorPicker)
            {
                if (colorPicker.IsPopupOpen || colorPicker.IsIndependent)
                {
                    colorPicker.ToggleButtonState = (colorPicker.BaseColorMode == ColorMode.Standard) ? ColorPickerState.StandardOpen : ColorPickerState.AdvancedOpen;
                }
                else
                {
                    colorPicker.ToggleButtonState = ColorPickerState.Closed;
                }
            }
        }

        private void ColorModeButton_Clicked(object sender, RoutedEventArgs e)
        {
            BaseColorMode = (BaseColorMode == ColorMode.Standard) ? ColorMode.Advanced : ColorMode.Standard;
        }

        #endregion Event Handlers
    }
}
