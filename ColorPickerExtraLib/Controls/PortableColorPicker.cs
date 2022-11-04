
using ColorPickerExtraLib.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorPickerExtraLib.Controls
{
    public enum ColorPickerState
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
        private Border checkerBrushBorder;
        private Border toggleButtonRectangle;
        private Viewbox toggleButtonViewbox;
        private TextBlock fontTextBlock;
        private Path shapePath;
        private ToggleButton portableToggleButton;

        private Brush selectedColorBrush;

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
            //checkerBrushBorder.MouseEnter += CheckerBrushBorder_MouseEnter;
            //checkerBrushBorder.MouseLeave += CheckerBrushBorder_MouseLeave;
            //checkerBrushBorder.MouseDown += CheckerBrushBorder_MouseLeave;
            //checkerBrushBorder.MouseUp += CheckerBrushBorder_MouseEnter;
            toggleButtonRectangle = (Border)GetTemplateChild("PART_ToggleButtonRectangle");
            toggleButtonViewbox = (Viewbox)GetTemplateChild("PART_ToggleButtonViewbox");
            fontTextBlock = (TextBlock)GetTemplateChild("PART_ToggleButtonFontTextBlock");
            shapePath = (Path)GetTemplateChild("PART_EmptyPath");
            portableToggleButton = (ToggleButton)GetTemplateChild("PART_PortableToggleButton");
            portableToggleButton.PreviewMouseDown += PortableToggleButton_PreviewMouseDown;
            portableToggleButton.MouseEnter += PortableToggleButton_MouseEnter;
            portableToggleButton.MouseLeave += PortableToggleButton_MouseLeave;
        }

        private bool MouseOver = false;

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
            MouseOver = true; UpdateBorder();
        }

        private void ApplyProperties()
        {
            selectedColorBrush = new SolidColorBrush(SelectedColor);
            UpdateBackground();
            UpdateBorder();
            UpdateShape();
            UpdateText();
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
                    case Models.ShowOnToggleButton.Off:
                        checkerBrushBorder.Background = Brushes.Transparent;
                        break;
                    case Models.ShowOnToggleButton.ConstantColor:
                        toggleButtonRectangle.Background = PortableConstantBackgroundBrush;
                        break;
                    case Models.ShowOnToggleButton.SelectedColor:
                        toggleButtonRectangle.Background = selectedColorBrush;
                        break;
                    case Models.ShowOnToggleButton.InverseColors:
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


            if (!IsEmpty || (IsEmpty && EmptyBorderMode == Models.EmptyElementMode.PortableSettings))
            {
                switch (PortableBorderMode)
                {
                    case Models.ShowOnToggleButton.Off:
                        toggleButtonRectangle.BorderThickness = new Thickness(0);
                        break;
                    case Models.ShowOnToggleButton.ConstantColor:
                        toggleButtonRectangle.BorderThickness = PortableBorderModeThickness;
                        if (IsPopupOpen || MouseOver)
                        {
                            toggleButtonRectangle.BorderBrush = PortableConstantBorderHighlightBrush;
                        }
                        else
                        {
                            toggleButtonRectangle.BorderBrush = PortableConstantBorderBrush;
                        }
                        break;
                    case Models.ShowOnToggleButton.SelectedColor:
                        toggleButtonRectangle.BorderBrush = selectedColorBrush;
                        toggleButtonRectangle.BorderThickness = PortableBorderModeThickness;
                        break;
                    case Models.ShowOnToggleButton.InverseColors:
                        toggleButtonRectangle.BorderBrush = ColorUtilities.GetInverseColorBrush(SelectedColor, PortableInverseDarkBrush, PortableInverseLightBrush, UsingAlphaChannel);
                        toggleButtonRectangle.BorderThickness = PortableBorderModeThickness;
                        break;
                }
            }
            else if (IsEmpty && EmptyBorderMode == Models.EmptyElementMode.EmptySettings)
            {
                toggleButtonRectangle.BorderThickness = EmptyBorderThickness;
                if (IsPopupOpen || MouseOver)
                {
                    toggleButtonRectangle.BorderBrush = EmptyBorderHighlightBrush;
                }
                else
                {
                    toggleButtonRectangle.BorderBrush = EmptyBorderBrush;
                }
                return;
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

            if ((!IsEmpty || EmptyTextMode == Models.EmptyElementMode.PortableSettings) && PortableFontMode != Models.ShowOnToggleButton.Off)
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
                    case Models.ShowOnToggleButton.Off:
                        break;
                    case Models.ShowOnToggleButton.ConstantColor:
                        fontTextBlock.Foreground = PortableConstantFontBrush;
                        break;
                    case Models.ShowOnToggleButton.SelectedColor:
                        fontTextBlock.Foreground = selectedColorBrush;
                        break;
                    case Models.ShowOnToggleButton.InverseColors:
                        fontTextBlock.Foreground = ColorUtilities.GetInverseColorBrush(SelectedColor, PortableInverseDarkBrush, PortableInverseLightBrush, UsingAlphaChannel);
                        break;
                }
            }
            else if (IsEmpty && EmptyTextMode == Models.EmptyElementMode.EmptySettings)
            {
                fontTextBlock.Visibility = Visibility.Visible;
                toggleButtonViewbox.Stretch = EmptyViewboxStretch ?? PortableFontViewboxStretch;
                toggleButtonViewbox.Margin = EmptyFontMargin ?? PortableFontMargin;
                toggleButtonViewbox.HorizontalAlignment = EmptyFontHorizontalAlignment ?? PortableFontHorizontalAlignment;
                toggleButtonViewbox.VerticalAlignment = EmptyVerticalAlignment ?? PortableFontVerticalAlignment;
                fontTextBlock.Text = EmptyUseHexText ? ColorUtilities.ColorToHex(SelectedColor, UsingAlphaChannel) : EmptyText;
                fontTextBlock.FontStyle = EmptyFontStyle ?? PortableFontStyle;
                fontTextBlock.FontWeight = EmptyFontWeight ?? PortableFontWeight;
                fontTextBlock.FontSize = EmptyFontSize ?? PortableFontSize;
                fontTextBlock.TextDecorations = EmptyTextDecorations ?? PortableFontTextDecorations;
                fontTextBlock.FontFamily = EmptyFontFamily ?? PortableFontFamily;
                if (EmptyFontColorBrush != null)
                {
                    fontTextBlock.Foreground = EmptyFontColorBrush;
                }
                else
                {
                    switch (PortableFontMode)
                    {
                        case Models.ShowOnToggleButton.Off:
                        case Models.ShowOnToggleButton.ConstantColor:
                            fontTextBlock.Foreground = PortableConstantFontBrush;
                            break;
                        case Models.ShowOnToggleButton.SelectedColor:
                            fontTextBlock.Foreground = selectedColorBrush;
                            break;
                        case Models.ShowOnToggleButton.InverseColors:
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
            if (PortableShapeMode != Models.ShowOnToggleButton.Off && (!IsEmpty || (IsEmpty && EmptyShapeMode == Models.EmptyElementMode.PortableSettings)))
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
                    case Models.ShowOnToggleButton.ConstantColor:
                        shapePath.Stroke = PortableConstantShapeColorBrush;
                        break;
                    case Models.ShowOnToggleButton.SelectedColor:
                        shapePath.Stroke = selectedColorBrush;
                        break;
                    case Models.ShowOnToggleButton.InverseColors:
                        shapePath.Stroke = ColorUtilities.GetInverseColorBrush(SelectedColor, PortableInverseDarkBrush, PortableInverseLightBrush, UsingAlphaChannel);
                        break;
                }
            }
            else if (IsEmpty && EmptyShapeMode == Models.EmptyElementMode.EmptySettings)
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

        private void CheckerBrushBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            UpdateBorder();
        }

        private void CheckerBrushBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            UpdateBorder();
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

        #endregion Event Handlers

        #region Methods

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