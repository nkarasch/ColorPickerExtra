namespace ColorPickerExtraLib.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using ColorPickerExtraLib.Models;
    using ColorPickerExtraLib.Utilities;

    public partial class PortableColorPicker
    {
        #region Base Properties   

        public static readonly DependencyProperty PortableShowDropdownButtonProperty =
            DependencyProperty.Register(nameof(PortableShowDropdownButton), typeof(bool), typeof(PortableColorPicker),
                new PropertyMetadata(true));

        public static readonly DependencyProperty PortableButtonBaseStyleProperty =
            DependencyProperty.Register(nameof(PortableButtonBaseStyle), typeof(Style), typeof(PortableColorPicker));

        public static readonly DependencyProperty PortableInsideMarginProperty =
            DependencyProperty.Register(nameof(PortableInsideMargin), typeof(Thickness), typeof(PortableColorPicker));

        public bool PortableShowDropdownButton
        {
            get => (bool)GetValue(PortableShowDropdownButtonProperty);
            set => SetValue(PortableShowDropdownButtonProperty, value);
        }

        public Style PortableButtonBaseStyle
        {
            get => (Style)GetValue(PortableButtonBaseStyleProperty);
            set => SetValue(PortableButtonBaseStyleProperty, value);
        }

        public Thickness PortableInsideMargin
        {
            get => (Thickness)GetValue(PortableInsideMarginProperty);
            set => SetValue(PortableInsideMarginProperty, value);
        }

        #endregion Base Properties

        #region Background Mode

        public static readonly DependencyProperty PortableBackgroundModeProperty =
            DependencyProperty.Register(nameof(PortableBackgroundMode), typeof(ShowOnToggleButton), typeof(PortableColorPicker),
                new PropertyMetadata(ShowOnToggleButton.SelectedColor, UpdateBackgroundProperties));

        public static readonly DependencyProperty PortableBackgroundConstantBrushProperty =
            DependencyProperty.Register(nameof(PortableBackgroundConstantBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(ColorUtilities.DefaultGreyBrush, UpdateBackgroundProperties));

        private static void UpdateBackgroundProperties(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PortableColorPicker colorPicker)
            {
                colorPicker.UpdateBackground();
            }
        }

        public ShowOnToggleButton PortableBackgroundMode
        {
            get => (ShowOnToggleButton)GetValue(PortableBackgroundModeProperty);
            set => SetValue(PortableBackgroundModeProperty, value);
        }

        public Brush PortableBackgroundConstantBrush
        {
            get => (Brush)GetValue(PortableBackgroundConstantBrushProperty);
            set => SetValue(PortableBackgroundConstantBrushProperty, value);
        }

        #endregion Background Mode

        #region Shape

        public static readonly DependencyProperty PortableShapeModeProperty =
            DependencyProperty.Register(nameof(PortableShapeMode), typeof(ShowOnToggleButton), typeof(PortableColorPicker),
                new PropertyMetadata(ShowOnToggleButton.Off, UpdateShapeProperties));

        public static readonly DependencyProperty PortableShapeGeometryProperty =
            DependencyProperty.Register(nameof(PortableShapeGeometry), typeof(ShapeGeometry), typeof(PortableColorPicker),
                new PropertyMetadata(ShapeGeometry.BorderedBottomLeftToTopRight, UpdateShapeProperties));

        public static readonly DependencyProperty PortableShapeCustomGeometryProperty =
            DependencyProperty.Register(nameof(PortableShapeCustomGeometry), typeof(Geometry), typeof(PortableColorPicker),
                new PropertyMetadata(null, UpdateShapeProperties));

        public static readonly DependencyProperty PortableShapeConstantColorBrushProperty =
            DependencyProperty.Register(nameof(PortableShapeConstantColorBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(ColorUtilities.DefaultGreyBrush, UpdateShapeProperties));

        public static readonly DependencyProperty PortableShapeStretchProperty =
            DependencyProperty.Register(nameof(PortableShapeStretch), typeof(Stretch), typeof(PortableColorPicker),
                new PropertyMetadata(Stretch.Fill, UpdateShapeProperties));

        public static readonly DependencyProperty PortableShapeMarginProperty =
            DependencyProperty.Register(nameof(PortableShapeMargin), typeof(Thickness), typeof(PortableColorPicker), new PropertyMetadata(UpdateShapeProperties));

        public static readonly DependencyProperty PortableShapeHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(PortableShapeHorizontalAlignment), typeof(HorizontalAlignment), typeof(PortableColorPicker),
                new PropertyMetadata(HorizontalAlignment.Stretch, UpdateShapeProperties));

        public static readonly DependencyProperty PortableShapeVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(PortableShapeVerticalAlignment), typeof(VerticalAlignment), typeof(PortableColorPicker),
                new PropertyMetadata(VerticalAlignment.Stretch, UpdateShapeProperties));

        public static readonly DependencyProperty PortableShapeLineWidthProperty =
            DependencyProperty.Register(nameof(PortableShapeLineWidth), typeof(double), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(2.0, UpdateShapeProperties));

        public ShowOnToggleButton PortableShapeMode
        {
            get => (ShowOnToggleButton)GetValue(PortableShapeModeProperty);
            set => SetValue(PortableShapeModeProperty, value);
        }

        public ShapeGeometry PortableShapeGeometry
        {
            get => (ShapeGeometry)GetValue(PortableShapeGeometryProperty);
            set => SetValue(PortableShapeGeometryProperty, value);
        }

        public Geometry PortableShapeCustomGeometry
        {
            get => (Geometry)GetValue(PortableShapeCustomGeometryProperty);
            set => SetValue(PortableShapeCustomGeometryProperty, value);
        }

        public Brush PortableShapeConstantColorBrush
        {
            get => (Brush)GetValue(PortableShapeConstantColorBrushProperty);
            set => SetValue(PortableShapeConstantColorBrushProperty, value);
        }

        public Stretch PortableShapeStretch
        {
            get => (Stretch)GetValue(PortableShapeStretchProperty);
            set => SetValue(PortableShapeStretchProperty, value);
        }

        public Thickness PortableShapeMargin
        {
            get => (Thickness)GetValue(PortableShapeMarginProperty);
            set => SetValue(PortableShapeMarginProperty, value);
        }

        public HorizontalAlignment PortableShapeHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(PortableShapeHorizontalAlignmentProperty);
            set => SetValue(PortableShapeHorizontalAlignmentProperty, value);
        }

        public VerticalAlignment PortableShapeVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(PortableShapeVerticalAlignmentProperty);
            set => SetValue(PortableShapeVerticalAlignmentProperty, value);
        }

        public double PortableShapeLineWidth
        {
            get => (double)GetValue(PortableShapeLineWidthProperty);
            set => SetValue(PortableShapeLineWidthProperty, value);
        }

        #endregion Shape

        #region Font Mode

        public static readonly DependencyProperty PortableFontModeProperty =
            DependencyProperty.Register(nameof(PortableFontMode), typeof(ShowOnToggleButton), typeof(PortableColorPicker),
                new UIPropertyMetadata(ShowOnToggleButton.Off, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontConstantBrushProperty =
            DependencyProperty.Register(nameof(PortableFontConstantBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(ColorUtilities.DefaultGreyBrush, UpdateFontProperties));

        public ShowOnToggleButton PortableFontMode
        {
            get => (ShowOnToggleButton)GetValue(PortableFontModeProperty);
            set => SetValue(PortableFontModeProperty, value);
        }

        public Brush PortableFontConstantBrush
        {
            get => (Brush)GetValue(PortableFontConstantBrushProperty);
            set => SetValue(PortableFontConstantBrushProperty, value);
        }

        public static readonly DependencyProperty PortableFontFamilyProperty =
            DependencyProperty.Register(nameof(PortableFontFamily), typeof(FontFamily), typeof(PortableColorPicker),
                new PropertyMetadata(TextBlock.FontFamilyProperty.DefaultMetadata.DefaultValue, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontSizeProperty =
            DependencyProperty.Register(nameof(PortableFontSize), typeof(double), typeof(PortableColorPicker),
                new PropertyMetadata(12.0, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontStyleProperty =
            DependencyProperty.Register(nameof(PortableFontStyle), typeof(FontStyle), typeof(PortableColorPicker),
                new PropertyMetadata(FontStyles.Normal, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontWeightProperty =
            DependencyProperty.Register(nameof(PortableFontWeight), typeof(FontWeight), typeof(PortableColorPicker),
            new PropertyMetadata(FontWeights.Normal, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontMarginProperty =
            DependencyProperty.Register(nameof(PortableFontMargin), typeof(Thickness), typeof(PortableColorPicker), new PropertyMetadata(UpdateFontProperties));

        public static readonly DependencyProperty PortableFontTextProperty =
            DependencyProperty.Register(nameof(PortableFontText), typeof(string), typeof(PortableColorPicker),
                new PropertyMetadata("Font", UpdateFontProperties));

        public static readonly DependencyProperty PortableFontTextDecorationsProperty =
            DependencyProperty.Register(nameof(PortableFontTextDecorations), typeof(TextDecorationCollection), typeof(PortableColorPicker),
                new PropertyMetadata(null, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontUseHexTextProperty =
            DependencyProperty.Register(nameof(PortableFontUseHexText), typeof(bool), typeof(PortableColorPicker),
                new PropertyMetadata(false, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(PortableFontVerticalAlignment), typeof(VerticalAlignment), typeof(PortableColorPicker),
                new PropertyMetadata(VerticalAlignment.Center, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontViewboxStretchProperty =
            DependencyProperty.Register(nameof(PortableFontViewboxStretch), typeof(Stretch), typeof(PortableColorPicker),
                new PropertyMetadata(Stretch.None, UpdateFontProperties));

        public static readonly DependencyProperty PortableFontHorizontalAlignmentProperty =
          DependencyProperty.Register(nameof(PortableFontHorizontalAlignment), typeof(HorizontalAlignment), typeof(PortableColorPicker),
              new PropertyMetadata(HorizontalAlignment.Left, UpdateFontProperties));

        private static void UpdateFontProperties(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PortableColorPicker colorPicker)
            {
                colorPicker.UpdateText();
            }
        }

        public FontFamily PortableFontFamily
        {
            get => (FontFamily)GetValue(PortableFontFamilyProperty);
            set => SetValue(PortableFontFamilyProperty, value);
        }

        public double PortableFontSize
        {
            get => (double)GetValue(PortableFontSizeProperty);
            set => SetValue(PortableFontSizeProperty, value);
        }

        public FontStyle PortableFontStyle
        {
            get => (FontStyle)GetValue(PortableFontStyleProperty);
            set => SetValue(PortableFontStyleProperty, value);
        }

        public FontWeight PortableFontWeight
        {
            get => (FontWeight)GetValue(PortableFontWeightProperty);
            set => SetValue(PortableFontWeightProperty, value);
        }

        public HorizontalAlignment PortableFontHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(PortableFontHorizontalAlignmentProperty);
            set => SetValue(PortableFontHorizontalAlignmentProperty, value);
        }

        public Thickness PortableFontMargin
        {
            get => (Thickness)GetValue(PortableFontMarginProperty);
            set => SetValue(PortableFontMarginProperty, value);
        }

        public string PortableFontText
        {
            get => (string)GetValue(PortableFontTextProperty);
            set => SetValue(PortableFontTextProperty, value);
        }

        public TextDecorationCollection PortableFontTextDecorations
        {
            get => (TextDecorationCollection)GetValue(PortableFontTextDecorationsProperty);
            set => SetValue(PortableFontTextDecorationsProperty, value);
        }

        public bool PortableFontUseHexText
        {
            get => (bool)GetValue(PortableFontUseHexTextProperty);
            set => SetValue(PortableFontUseHexTextProperty, value);
        }

        public VerticalAlignment PortableFontVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(PortableFontVerticalAlignmentProperty);
            set => SetValue(PortableFontVerticalAlignmentProperty, value);
        }

        public Stretch PortableFontViewboxStretch
        {
            get => (Stretch)GetValue(PortableFontViewboxStretchProperty);
            set => SetValue(PortableFontViewboxStretchProperty, value);
        }

        #endregion Font Mode

        #region Border Mode

        public static readonly DependencyProperty PortableBorderModeProperty =
            DependencyProperty.Register(nameof(PortableBorderMode), typeof(ShowOnToggleButton), typeof(PortableColorPicker),
                new PropertyMetadata(ShowOnToggleButton.ConstantColor, UpdateBorderProperties));

        public static readonly DependencyProperty PortableBorderConstantBrushProperty =
            DependencyProperty.Register(nameof(PortableBorderConstantBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(ColorUtilities.DefaultGreyBrush, UpdateBorderProperties));

        public static readonly DependencyProperty PortableBorderConstantHighlightBrushProperty =
            DependencyProperty.Register(nameof(PortableBorderConstantHighlightBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(ColorUtilities.DefaultHighlightBrush, UpdateBorderProperties));

        public static readonly DependencyProperty PortableBorderThicknessProperty =
            DependencyProperty.Register(nameof(PortableBorderThickness), typeof(Thickness), typeof(PortableColorPicker),
                new PropertyMetadata(new Thickness(1, 1, 0, 1), UpdateBorderProperties));

        private static void UpdateBorderProperties(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PortableColorPicker colorPicker)
            {
                colorPicker.UpdateBorder();
            }
        }

        public ShowOnToggleButton PortableBorderMode
        {
            get => (ShowOnToggleButton)GetValue(PortableBorderModeProperty);
            set => SetValue(PortableBorderModeProperty, value);
        }

        public Brush PortableBorderConstantBrush
        {
            get => (Brush)GetValue(PortableBorderConstantBrushProperty);
            set => SetValue(PortableBorderConstantBrushProperty, value);
        }

        public Brush PortableBorderConstantHighlightBrush
        {
            get => (Brush)GetValue(PortableBorderConstantHighlightBrushProperty);
            set => SetValue(PortableBorderConstantHighlightBrushProperty, value);
        }

        public Thickness PortableBorderThickness
        {
            get => (Thickness)GetValue(PortableBorderThicknessProperty);
            set => SetValue(PortableBorderThicknessProperty, value);
        }

        #endregion Border Mode

        #region Inverse Colors

        public static readonly DependencyProperty PortableInverseDarkColorProperty = DependencyProperty.Register(
            nameof(PortableInverseDarkBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(ColorUtilities.DefaultNearBlack));

        public static readonly DependencyProperty PortableInverseLightColorProperty = DependencyProperty.Register(
            nameof(PortableInverseLightBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(Brushes.White));

        public Brush PortableInverseDarkBrush
        {
            get => (Brush)GetValue(PortableInverseDarkColorProperty);
            set => SetValue(PortableInverseDarkColorProperty, value);
        }

        public Brush PortableInverseLightBrush
        {
            get => (Brush)GetValue(PortableInverseLightColorProperty);
            set => SetValue(PortableInverseLightColorProperty, value);
        }

        #endregion Inverse Colors
    }
}