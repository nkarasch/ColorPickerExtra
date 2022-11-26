
using ColorPickerExtraLib.Models;
using ColorPickerExtraLib.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorPickerExtraLib.Controls
{
    internal enum ColorPickerState
    {
        StandardOpen, AdvancedOpen, Closed
    }

    [TemplatePart(Name = "PART_CheckerBrushBorder", Type = typeof(Border))]
    [TemplatePart(Name = "PART_ToggleButtonRectangle", Type = typeof(Border))]
    [TemplatePart(Name = "PART_ToggleButtonViewbox", Type = typeof(Viewbox))]
    [TemplatePart(Name = "PART_ToggleButtonFontTextBlock", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_EmptyPath", Type = typeof(Path))]
    [TemplatePart(Name = "PART_PortableToggleButton", Type = typeof(ToggleButton))]
    public partial class PortableColorPicker : ControlBase
    {
        private bool MouseOver = false;
        private Brush selectedColorBrush;

        private Border checkerBrushBorder;
        private Border toggleButtonRectangle;
        private Viewbox toggleButtonViewbox;
        private TextBlock fontTextBlock;
        private Path shapePath;
        private ToggleButton portableToggleButton;

        #region Constructors

        static PortableColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PortableColorPicker), new FrameworkPropertyMetadata(typeof(PortableColorPicker)));
        }

        public PortableColorPicker() : base()
        {
            Keyboard.AddKeyDownHandler(this, OnKeyDown);
            Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, OnMouseDownOutsideCapturedElement);
            Loaded += (sender, e) =>
            {
                ApplyProperties();
            };
        }

        #endregion Constructors

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            checkerBrushBorder = (Border)GetTemplateChild("PART_CheckerBrushBorder");
            toggleButtonRectangle = (Border)GetTemplateChild("PART_ToggleButtonRectangle");
            toggleButtonViewbox = (Viewbox)GetTemplateChild("PART_ToggleButtonViewbox");
            fontTextBlock = (TextBlock)GetTemplateChild("PART_ToggleButtonFontTextBlock");
            shapePath = (Path)GetTemplateChild("PART_EmptyPath");
            portableToggleButton = (ToggleButton)GetTemplateChild("PART_PortableToggleButton");
            portableToggleButton.PreviewMouseDown += PortableToggleButton_PreviewMouseDown;
            portableToggleButton.MouseEnter += PortableToggleButton_MouseEnter;
            portableToggleButton.MouseLeave += PortableToggleButton_MouseLeave;
        }

        #region Internal Properties

        internal static readonly DependencyProperty IsPopupOpenProperty =
            DependencyProperty.Register(nameof(IsPopupOpen), typeof(bool), typeof(PortableColorPicker),
                new UIPropertyMetadata(false, OnIsPopupOpenChanged));

        internal bool IsPopupOpen
        {
            get => (bool)GetValue(IsPopupOpenProperty);
            set => SetValue(IsPopupOpenProperty, value);
        }

        #endregion Internal Properties

        #region Event Handlers

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!IsPopupOpen)
            {
                if (IsKeyModifyingPopupState(e))
                {
                    IsPopupOpen = true;
                    e.Handled = true;
                }
            }
            else
            {
                if (IsKeyModifyingPopupState(e))
                {
                    CloseColorPicker(true);
                    e.Handled = true;
                }
                else
                if (e.Key == Key.Escape)
                {
                    CloseColorPicker(true);
                    e.Handled = true;
                }
            }
        }

        private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
        {
            CloseColorPicker(true);
        }

        private static bool IsKeyModifyingPopupState(KeyEventArgs e)
        {
            return (((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt) &&
                    ((e.SystemKey == Key.Down) || (e.SystemKey == Key.Up))) || (e.Key == Key.F4);
        }

        private static void OnIsPopupOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool isPopupOpen = (bool)e.NewValue;

            if (d is PortableColorPicker portableColorPicker)
            {

                portableColorPicker.UpdateBorder();
                if (!isPopupOpen)
                {
                    portableColorPicker.CloseColorPicker(true);
                }
            }
        }

        private void PortableToggleButton_MouseLeave(object sender, MouseEventArgs e)
        {
            MouseOver = false;
            UpdateBorder();
        }

        private void PortableToggleButton_MouseEnter(object sender, MouseEventArgs e)
        {
            MouseOver = true;
            UpdateBorder();
        }

        private void PortableToggleButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseOver = true;
            UpdateBorder();
        }

        internal override void OnSelectedColorChanged(Color newColor)
        {
            if (IsEmpty)
            {
                IsEmpty = false;
                return;
            }
            ApplyProperties();
        }

        internal void OnIsEmptyChanged()
        {
            ApplyProperties();
        }

        #endregion Event Handlers

        #region Methods

        private void ApplyProperties()
        {
            selectedColorBrush = new SolidColorBrush(SelectedColor);
            UpdateTooltip();
            UpdateBackground();
            UpdateBorder();
            UpdateShape();
            UpdateText();
        }

        private void UpdateTooltip()
        {
            ToolTip = !IsEmpty ? ColorUtilities.ColorToHex(SelectedColor, UsingAlphaChannel) : EmptyButtonText;
        }

        private void UpdateBackground()
        {
            if (fontTextBlock == null || toggleButtonRectangle == null || checkerBrushBorder == null || shapePath == null || toggleButtonViewbox == null)
            {
                return;
            }

            if (!IsEmpty)
            {
                checkerBrushBorder.Background = UsingAlphaChannel ? ColorUtilities.CheckerBrush : (Brush)Brushes.Transparent;
                switch (PortableBackgroundMode)
                {
                    case ShowOnToggleButton.Off:
                    default:
                        toggleButtonRectangle.Background = Brushes.Transparent;
                        break;
                    case ShowOnToggleButton.ConstantColor:
                        toggleButtonRectangle.Background = PortableBackgroundConstantBrush;
                        break;
                    case ShowOnToggleButton.SelectedColor:
                        toggleButtonRectangle.Background = selectedColorBrush;
                        break;
                    case ShowOnToggleButton.InverseColors:
                        toggleButtonRectangle.Background = ColorUtilities.GetInverseColorBrush(SelectedColor, PortableInverseDarkBrush, PortableInverseLightBrush, UsingAlphaChannel);
                        break;
                }
            }
            else if (EmptyBackgroundBrush != null)
            {
                checkerBrushBorder.Background = Brushes.Transparent;
                toggleButtonRectangle.Background = EmptyBackgroundBrush;
            }
            else
            {
                checkerBrushBorder.Background = Brushes.Transparent;
                toggleButtonRectangle.Background = Brushes.Transparent;
            }
        }

        private void UpdateBorder()
        {
            if (fontTextBlock == null || toggleButtonRectangle == null || checkerBrushBorder == null || shapePath == null || toggleButtonViewbox == null)
            {
                return;
            }


            if (!IsEmpty || (IsEmpty && EmptyBorderMode == EmptyElementMode.PortableSettings))
            {
                switch (PortableBorderMode)
                {
                    case ShowOnToggleButton.Off:
                    default:
                        toggleButtonRectangle.BorderThickness = new Thickness(0);
                        break;
                    case ShowOnToggleButton.ConstantColor:
                        toggleButtonRectangle.BorderThickness = PortableBorderModeThickness;
                        toggleButtonRectangle.BorderBrush = IsPopupOpen || MouseOver ? PortableBorderConstantHighlightBrush : PortableBorderConstantBrush;
                        break;
                    case ShowOnToggleButton.SelectedColor:
                        toggleButtonRectangle.BorderBrush = selectedColorBrush;
                        toggleButtonRectangle.BorderThickness = PortableBorderModeThickness;
                        break;
                    case ShowOnToggleButton.InverseColors:
                        toggleButtonRectangle.BorderBrush = ColorUtilities.GetInverseColorBrush(SelectedColor, PortableInverseDarkBrush, PortableInverseLightBrush, UsingAlphaChannel);
                        toggleButtonRectangle.BorderThickness = PortableBorderModeThickness;
                        break;
                }
            }
            else if (IsEmpty && EmptyBorderMode == EmptyElementMode.EmptySettings)
            {
                toggleButtonRectangle.BorderThickness = EmptyBorderThickness;
                toggleButtonRectangle.BorderBrush = IsPopupOpen || MouseOver ? EmptyBorderHighlightBrush : EmptyBorderBrush;
            }
            else
            {
                toggleButtonRectangle.BorderThickness = new Thickness(0);
            }
        }

        private void UpdateText()
        {
            if (fontTextBlock == null || toggleButtonRectangle == null || checkerBrushBorder == null || shapePath == null || toggleButtonViewbox == null)
            {
                return;
            }

            if ((!IsEmpty || EmptyFontMode == EmptyElementMode.PortableSettings) && PortableFontMode != ShowOnToggleButton.Off)
            {
                fontTextBlock.Visibility = Visibility.Visible;
                toggleButtonViewbox.Stretch = PortableFontViewboxStretch;
                toggleButtonViewbox.Margin = PortableFontMargin;
                toggleButtonViewbox.HorizontalAlignment = PortableFontHorizontalAlignment;
                toggleButtonViewbox.VerticalAlignment = PortableFontVerticalAlignment;
                fontTextBlock.Text = PortableFontUseHexText ? ColorUtilities.ColorToHex(SelectedColor, UsingAlphaChannel) : PortableFontText;
                fontTextBlock.FontStyle = PortableFontStyle;
                fontTextBlock.FontWeight = PortableFontWeight;
                fontTextBlock.FontSize = PortableFontSize;
                fontTextBlock.TextDecorations = PortableFontTextDecorations;
                fontTextBlock.FontFamily = PortableFontFamily;
                switch (PortableFontMode)
                {
                    case ShowOnToggleButton.Off:
                    default:
                        break;
                    case ShowOnToggleButton.ConstantColor:
                        fontTextBlock.Foreground = PortableFontConstantBrush;
                        break;
                    case ShowOnToggleButton.SelectedColor:
                        fontTextBlock.Foreground = selectedColorBrush;
                        break;
                    case ShowOnToggleButton.InverseColors:
                        fontTextBlock.Foreground = ColorUtilities.GetInverseColorBrush(SelectedColor, PortableInverseDarkBrush, PortableInverseLightBrush, UsingAlphaChannel);
                        break;
                }
            }
            else if (IsEmpty && EmptyFontMode == EmptyElementMode.EmptySettings)
            {
                fontTextBlock.Visibility = Visibility.Visible;
                toggleButtonViewbox.Stretch = EmptyFontViewboxStretch ?? PortableFontViewboxStretch;
                toggleButtonViewbox.Margin = EmptyFontMargin ?? PortableFontMargin;
                toggleButtonViewbox.HorizontalAlignment = EmptyFontHorizontalAlignment ?? PortableFontHorizontalAlignment;
                toggleButtonViewbox.VerticalAlignment = EmptyFontVerticalAlignment ?? PortableFontVerticalAlignment;
                fontTextBlock.Text = EmptyFontText != null ? EmptyFontText : PortableFontUseHexText ? ColorUtilities.ColorToHex(SelectedColor, UsingAlphaChannel) : PortableFontText;
                fontTextBlock.FontStyle = EmptyFontStyle ?? PortableFontStyle;
                fontTextBlock.FontWeight = EmptyFontWeight ?? PortableFontWeight;
                fontTextBlock.FontSize = (EmptyFontSize.HasValue && EmptyFontSize.Value > 0) ? EmptyFontSize.Value : PortableFontSize;
                fontTextBlock.TextDecorations = EmptyFontTextDecorations ?? PortableFontTextDecorations;
                fontTextBlock.FontFamily = EmptyFontFamily ?? PortableFontFamily;
                if (EmptyFontBrush != null)
                {
                    fontTextBlock.Foreground = EmptyFontBrush;
                }
                else
                {
                    switch (PortableFontMode)
                    {
                        case ShowOnToggleButton.Off:
                        default:
                        case ShowOnToggleButton.ConstantColor:
                            fontTextBlock.Foreground = PortableFontConstantBrush;
                            break;
                        case ShowOnToggleButton.SelectedColor:
                            fontTextBlock.Foreground = selectedColorBrush;
                            break;
                        case ShowOnToggleButton.InverseColors:
                            fontTextBlock.Foreground = ColorUtilities.GetInverseColorBrush(SelectedColor, PortableInverseDarkBrush, PortableInverseLightBrush, UsingAlphaChannel);
                            break;
                    }
                }
            }
            else
            {
                fontTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateShape()
        {
            if (fontTextBlock == null || toggleButtonRectangle == null || checkerBrushBorder == null || shapePath == null || toggleButtonViewbox == null)
            {
                return;
            }
            if (PortableShapeMode != ShowOnToggleButton.Off && (!IsEmpty || (IsEmpty && EmptyShapeMode == EmptyElementMode.PortableSettings)))
            {
                shapePath.Visibility = Visibility.Visible;
                shapePath.Margin = PortableShapeMargin;
                shapePath.HorizontalAlignment = PortableShapeHorizontalAlignment;
                shapePath.VerticalAlignment = PortableShapeVerticalAlignment;
                shapePath.Stretch = PortableShapeStretch;
                shapePath.StrokeThickness = PortableShapeLineWidth;
                shapePath.Data = PortableShapeCustomGeometry ?? Utilities.EmptyShapeGeometry.GetShapeGeometry(PortableShapeGeometry);
                switch (PortableShapeMode)
                {
                    case ShowOnToggleButton.ConstantColor:
                    default:
                        shapePath.Stroke = PortableShapeConstantColorBrush;
                        break;
                    case ShowOnToggleButton.SelectedColor:
                        shapePath.Stroke = selectedColorBrush;
                        break;
                    case ShowOnToggleButton.InverseColors:
                        shapePath.Stroke = ColorUtilities.GetInverseColorBrush(SelectedColor, PortableInverseDarkBrush, PortableInverseLightBrush, UsingAlphaChannel);
                        break;
                }
            }
            else if (IsEmpty && EmptyShapeMode == EmptyElementMode.EmptySettings)
            {
                shapePath.Visibility = Visibility.Visible;
                shapePath.Margin = EmptyShapeMargin;
                shapePath.HorizontalAlignment = EmptyShapeHorizontalAlignment;
                shapePath.VerticalAlignment = EmptyShapeVerticalAlignment;
                shapePath.Stretch = EmptyShapeStretch;
                shapePath.Stroke = (EmptyShapeColorBrush == null) ? Foreground : EmptyShapeColorBrush;
                shapePath.StrokeThickness = EmptyShapeLineWidth;
                shapePath.Data = EmptyShapeCustomGeometry ?? Utilities.EmptyShapeGeometry.GetShapeGeometry(EmptyShapeGeometry);
            }
            else
            {
                shapePath.Visibility = Visibility.Collapsed;
            }
        }

        private void CloseColorPicker(bool isFocusOnColorPicker)
        {
            if (IsPopupOpen)
            {
                IsPopupOpen = false;
            }

            ReleaseMouseCapture();

            if (isFocusOnColorPicker)
            {
                Focus();
            }
        }

        #endregion Methods    
    }
}