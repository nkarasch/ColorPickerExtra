namespace ColorPickerExtraLib.Controls
{
    using System.Windows;
    using System.Windows.Media;
    using ColorPickerExtraLib.Models;
    using ColorPickerExtraLib.Utilities;

    public partial class PortableColorPicker
    {
        public static readonly DependencyProperty EmptyBackgroundBrushProperty =
            DependencyProperty.Register(nameof(EmptyBackgroundBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(Brushes.Transparent, UpdateBackgroundProperties));

        public Brush EmptyBackgroundBrush
        {
            get => (Brush)GetValue(EmptyBackgroundBrushProperty);
            set => SetValue(EmptyBackgroundBrushProperty, value);
        }

        #region Empty Border Mode

        public static readonly DependencyProperty EmptyBorderModeProperty =
            DependencyProperty.Register(nameof(EmptyBorderMode), typeof(EmptyElementMode), typeof(PortableColorPicker),
                new PropertyMetadata(EmptyElementMode.EmptySettings, UpdateBorderProperties));

        public static readonly DependencyProperty EmptyBorderBrushProperty =
            DependencyProperty.Register(nameof(EmptyBorderBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(ColorUtilities.DefaultGreyBrush, UpdateBorderProperties));

        public static readonly DependencyProperty EmptyBorderHighlightBrushProperty =
            DependencyProperty.Register(nameof(EmptyBorderHighlightBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(ColorUtilities.DefaultHighlightBrush, UpdateBorderProperties));

        public static readonly DependencyProperty EmptyBorderThicknessProperty =
            DependencyProperty.Register(nameof(EmptyBorderThickness), typeof(Thickness), typeof(PortableColorPicker),
                new PropertyMetadata(new Thickness(1, 1, 0, 1), UpdateBorderProperties));

        public EmptyElementMode EmptyBorderMode
        {
            get => (EmptyElementMode)GetValue(EmptyBorderModeProperty);
            set => SetValue(EmptyBorderModeProperty, value);
        }

        public Brush EmptyBorderBrush
        {
            get => (Brush)GetValue(EmptyBorderBrushProperty);
            set => SetValue(EmptyBorderBrushProperty, value);
        }

        public Brush EmptyBorderHighlightBrush
        {
            get => (Brush)GetValue(EmptyBorderHighlightBrushProperty);
            set => SetValue(EmptyBorderHighlightBrushProperty, value);
        }

        public Thickness EmptyBorderThickness
        {
            get => (Thickness)GetValue(EmptyBorderThicknessProperty);
            set => SetValue(EmptyBorderThicknessProperty, value);
        }

        #endregion Empty Border

        #region Empty Shape

        public static readonly DependencyProperty EmptyShapeModeProperty =
            DependencyProperty.Register(nameof(EmptyShapeMode), typeof(EmptyElementMode), typeof(PortableColorPicker),
                new PropertyMetadata(EmptyElementMode.EmptySettings, UpdateShapeProperties));

        public static readonly DependencyProperty EmptyShapeGeometryProperty =
            DependencyProperty.Register(nameof(EmptyShapeGeometry), typeof(ShapeGeometry), typeof(PortableColorPicker),
                new PropertyMetadata(ShapeGeometry.BorderedBottomLeftToTopRight, UpdateShapeProperties));

        public static readonly DependencyProperty EmptyShapeCustomGeometryProperty =
            DependencyProperty.Register(nameof(EmptyShapeCustomGeometry), typeof(Geometry), typeof(PortableColorPicker),
                new PropertyMetadata(null, UpdateShapeProperties));

        public static readonly DependencyProperty EmptyShapeColorBrushProperty =
            DependencyProperty.Register(nameof(EmptyShapeColorBrush), typeof(Brush), typeof(PortableColorPicker),
                new PropertyMetadata(Brushes.DarkRed, UpdateShapeProperties));

        public static readonly DependencyProperty EmptyShapeStretchProperty =
            DependencyProperty.Register(nameof(EmptyShapeStretch), typeof(Stretch), typeof(PortableColorPicker),
                new PropertyMetadata(Stretch.Uniform, UpdateShapeProperties));

        public static readonly DependencyProperty EmptyShapeMarginProperty =
            DependencyProperty.Register(nameof(EmptyShapeMargin), typeof(Thickness), typeof(PortableColorPicker), new PropertyMetadata(UpdateShapeProperties));

        public static readonly DependencyProperty EmptyShapeHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(EmptyShapeHorizontalAlignment), typeof(HorizontalAlignment), typeof(PortableColorPicker),
                new PropertyMetadata(HorizontalAlignment.Left, UpdateShapeProperties));

        public static readonly DependencyProperty EmptyShapeVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(EmptyShapeVerticalAlignment), typeof(VerticalAlignment), typeof(PortableColorPicker),
                new PropertyMetadata(VerticalAlignment.Stretch, UpdateShapeProperties));

        public static readonly DependencyProperty EmptyShapeLineWidthProperty =
            DependencyProperty.Register(nameof(EmptyShapeLineWidth), typeof(double), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(2.0, UpdateShapeProperties));

        private static void UpdateShapeProperties(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PortableColorPicker colorPicker)
            {
                colorPicker.UpdateShape();
            }
        }

        public EmptyElementMode EmptyShapeMode
        {
            get => (EmptyElementMode)GetValue(EmptyShapeModeProperty);
            set => SetValue(EmptyShapeModeProperty, value);
        }

        public ShapeGeometry EmptyShapeGeometry
        {
            get => (ShapeGeometry)GetValue(EmptyShapeGeometryProperty);
            set => SetValue(EmptyShapeGeometryProperty, value);
        }

        public Geometry EmptyShapeCustomGeometry
        {
            get => (Geometry)GetValue(EmptyShapeCustomGeometryProperty);
            set => SetValue(EmptyShapeCustomGeometryProperty, value);
        }

        public Brush EmptyShapeColorBrush
        {
            get => (Brush)GetValue(EmptyShapeColorBrushProperty);
            set => SetValue(EmptyShapeColorBrushProperty, value);
        }

        public Stretch EmptyShapeStretch
        {
            get => (Stretch)GetValue(EmptyShapeStretchProperty);
            set => SetValue(EmptyShapeStretchProperty, value);
        }

        public Thickness EmptyShapeMargin
        {
            get => (Thickness)GetValue(EmptyShapeMarginProperty);
            set => SetValue(EmptyShapeMarginProperty, value);
        }

        public HorizontalAlignment EmptyShapeHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(EmptyShapeHorizontalAlignmentProperty);
            set => SetValue(EmptyShapeHorizontalAlignmentProperty, value);
        }

        public VerticalAlignment EmptyShapeVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(EmptyShapeVerticalAlignmentProperty);
            set => SetValue(EmptyShapeVerticalAlignmentProperty, value);
        }

        public double EmptyShapeLineWidth
        {
            get => (double)GetValue(EmptyShapeLineWidthProperty);
            set => SetValue(EmptyShapeLineWidthProperty, value);
        }

        #endregion Empty Shape

        #region Empty Font

        public static readonly DependencyProperty EmptyFontModeProperty =
            DependencyProperty.Register(nameof(EmptyFontMode), typeof(EmptyElementMode), typeof(PortableColorPicker),
                new PropertyMetadata(EmptyElementMode.EmptySettings, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontBrushProperty =
            DependencyProperty.Register(nameof(EmptyFontBrush), typeof(Brush), typeof(PortableColorPicker),
            new PropertyMetadata(null, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontFamilyProperty =
            DependencyProperty.Register(nameof(EmptyFontFamily), typeof(FontFamily), typeof(PortableColorPicker), 
                new PropertyMetadata(UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontSizeProperty =
            DependencyProperty.Register(nameof(EmptyFontSize), typeof(double?), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(null, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontStyleProperty =
            DependencyProperty.Register(nameof(EmptyFontStyle), typeof(FontStyle?), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(null, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontWeightProperty =
            DependencyProperty.Register(nameof(EmptyFontWeight), typeof(FontWeight?), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(null, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(EmptyFontHorizontalAlignment), typeof(HorizontalAlignment?), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(HorizontalAlignment.Center, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(EmptyFontVerticalAlignment), typeof(VerticalAlignment?), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(null, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontMarginProperty =
            DependencyProperty.Register(nameof(EmptyFontMargin), typeof(Thickness?), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(null, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontTextProperty =
            DependencyProperty.Register(nameof(EmptyFontText), typeof(string), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata("None", UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontTextDecorationsProperty =
            DependencyProperty.Register(nameof(EmptyFontTextDecorations), typeof(TextDecorationCollection), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(null, UpdateFontProperties));

        public static readonly DependencyProperty EmptyFontViewboxStretchProperty =
            DependencyProperty.Register(nameof(EmptyFontViewboxStretch), typeof(Stretch?), typeof(PortableColorPicker),
                new FrameworkPropertyMetadata(null, UpdateFontProperties));

        public EmptyElementMode EmptyFontMode
        {
            get => (EmptyElementMode)GetValue(EmptyFontModeProperty);
            set => SetValue(EmptyFontModeProperty, value);
        }

        public Brush EmptyFontBrush
        {
            get => (Brush)GetValue(EmptyFontBrushProperty);
            set => SetValue(EmptyFontBrushProperty, value);
        }

        public FontFamily EmptyFontFamily
        {
            get => (FontFamily)GetValue(EmptyFontFamilyProperty);
            set => SetValue(EmptyFontFamilyProperty, value);
        }

        public double? EmptyFontSize
        {
            get => (double?)GetValue(EmptyFontSizeProperty);
            set => SetValue(EmptyFontSizeProperty, value);
        }

        public FontStyle? EmptyFontStyle
        {
            get => (FontStyle?)GetValue(EmptyFontStyleProperty);
            set => SetValue(EmptyFontStyleProperty, value);
        }

        public FontWeight? EmptyFontWeight
        {
            get => (FontWeight?)GetValue(EmptyFontWeightProperty);
            set => SetValue(EmptyFontWeightProperty, value);
        }

        public HorizontalAlignment? EmptyFontHorizontalAlignment
        {
            get => (HorizontalAlignment?)GetValue(EmptyFontHorizontalAlignmentProperty);
            set => SetValue(EmptyFontHorizontalAlignmentProperty, value);
        }

        public VerticalAlignment? EmptyFontVerticalAlignment
        {
            get => (VerticalAlignment?)GetValue(EmptyFontVerticalAlignmentProperty);
            set => SetValue(EmptyFontVerticalAlignmentProperty, value);
        }

        public Thickness? EmptyFontMargin
        {
            get => (Thickness?)GetValue(EmptyFontMarginProperty);
            set => SetValue(EmptyFontMarginProperty, value);
        }

        public string EmptyFontText
        {
            get => (string)GetValue(EmptyFontTextProperty);
            set => SetValue(EmptyFontTextProperty, value);
        }

        public TextDecorationCollection EmptyFontTextDecorations
        {
            get => (TextDecorationCollection)GetValue(EmptyFontTextDecorationsProperty);
            set => SetValue(EmptyFontTextDecorationsProperty, value);
        }

        public Stretch? EmptyFontViewboxStretch
        {
            get => (Stretch?)GetValue(EmptyFontViewboxStretchProperty);
            set => SetValue(EmptyFontViewboxStretchProperty, value);
        }

        #endregion Empty Font
    }
}