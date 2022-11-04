using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls
{
    public partial class StandardColorPicker
    {
        public static readonly DependencyProperty StandardItemSquareSizeProperty =
            DependencyProperty.Register(nameof(StandardItemSquareSize), typeof(double), typeof(StandardColorPicker),
            new PropertyMetadata(17.0));

        public static readonly DependencyProperty StandardItemCornerRadiusProperty =
            DependencyProperty.Register(nameof(StandardItemCornerRadius), typeof(double), typeof(StandardColorPicker),
                new PropertyMetadata(3.0));

        public static readonly DependencyProperty StandardItemMarginProperty =
            DependencyProperty.Register(nameof(StandardItemMargin), typeof(double), typeof(StandardColorPicker),
                new PropertyMetadata(1.0));

        public static readonly DependencyProperty StandardItemBorderThicknessProperty =
            DependencyProperty.Register(nameof(StandardItemBorderThickness), typeof(double), typeof(StandardColorPicker),
                new PropertyMetadata(1.0));

        public static readonly DependencyProperty StandardItemBorderBrushProperty =
            DependencyProperty.Register(nameof(StandardItemBorderBrush), typeof(SolidColorBrush), typeof(StandardColorPicker),
                new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty StandardItemInnerHighlightBrushProperty =
             DependencyProperty.Register(nameof(StandardItemInnerHighlightBrush), typeof(SolidColorBrush), typeof(StandardColorPicker),
                 new PropertyMetadata(Brushes.Yellow));

        public static readonly DependencyProperty StandardItemOuterHighlightBrushProperty =
            DependencyProperty.Register(nameof(StandardItemOuterHighlightBrush), typeof(SolidColorBrush), typeof(StandardColorPicker),
                new PropertyMetadata(Brushes.Red));

        public static readonly DependencyProperty StandardAvailableColorsHeaderProperty =
            DependencyProperty.Register(nameof(StandardAvailableColorsHeader), typeof(string), typeof(StandardColorPicker),
                new PropertyMetadata("Available Colors"));

        public static readonly DependencyProperty StandardAvailableColorRowsProperty =
            DependencyProperty.Register(nameof(StandardAvailableColorRows), typeof(int), typeof(StandardColorPicker),
                new PropertyMetadata(14));

        public static readonly DependencyProperty StandardRecentColorRowsProperty =
            DependencyProperty.Register(nameof(StandardRecentColorRows), typeof(int), typeof(StandardColorPicker),
                new PropertyMetadata(1));

        public static readonly DependencyProperty StandardRecentColorsHeaderProperty =
            DependencyProperty.Register(nameof(StandardRecentColorsHeader), typeof(string), typeof(StandardColorPicker),
                new PropertyMetadata("Recent Colors"));

        public static readonly DependencyProperty StandardShowAvailableColorsProperty =
            DependencyProperty.Register(nameof(StandardShowAvailableColors), typeof(bool), typeof(StandardColorPicker),
                new PropertyMetadata(true));

        public static readonly DependencyProperty StandardShowRecentColorsProperty =
            DependencyProperty.Register(nameof(StandardShowRecentColors), typeof(bool), typeof(StandardColorPicker),
                new PropertyMetadata(true));

        public static readonly DependencyProperty StandardColumnCountProperty =
            DependencyProperty.Register(nameof(StandardColumnCount), typeof(int), typeof(StandardColorPicker),
                new PropertyMetadata(14));

        public double StandardItemSquareSize
        {
            get => (double)GetValue(StandardItemSquareSizeProperty);
            set => SetValue(StandardItemSquareSizeProperty, value);
        }

        public double StandardItemCornerRadius
        {
            get => (double)GetValue(StandardItemCornerRadiusProperty);
            set => SetValue(StandardItemCornerRadiusProperty, value);
        }

        public double StandardItemMargin
        {
            get => (double)GetValue(StandardItemMarginProperty);
            set => SetValue(StandardItemMarginProperty, value);
        }

        public double StandardItemBorderThickness
        {
            get => (double)GetValue(StandardItemBorderThicknessProperty);
            set => SetValue(StandardItemBorderThicknessProperty, value);
        }

        public SolidColorBrush StandardItemBorderBrush
        {
            get => (SolidColorBrush)GetValue(StandardItemBorderBrushProperty);
            set => SetValue(StandardItemBorderBrushProperty, value);
        }

        public SolidColorBrush StandardItemInnerHighlightBrush
        {
            get => (SolidColorBrush)GetValue(StandardItemInnerHighlightBrushProperty);
            set => SetValue(StandardItemInnerHighlightBrushProperty, value);
        }

        public SolidColorBrush StandardItemOuterHighlightBrush
        {
            get => (SolidColorBrush)GetValue(StandardItemOuterHighlightBrushProperty);
            set => SetValue(StandardItemOuterHighlightBrushProperty, value);
        }

        public string StandardAvailableColorsHeader
        {
            get => (string)GetValue(StandardAvailableColorsHeaderProperty);
            set => SetValue(StandardAvailableColorsHeaderProperty, value);
        }

        public int StandardAvailableColorRows
        {
            get => (int)GetValue(StandardAvailableColorRowsProperty);
            set => SetValue(StandardAvailableColorRowsProperty, value);
        }

        public int StandardRecentColorRows
        {
            get => (int)GetValue(StandardRecentColorRowsProperty);
            set => SetValue(StandardRecentColorRowsProperty, value);
        }

        public string StandardRecentColorsHeader
        {
            get => (string)GetValue(StandardRecentColorsHeaderProperty);
            set => SetValue(StandardRecentColorsHeaderProperty, value);
        }

        public bool StandardShowAvailableColors
        {
            get => (bool)GetValue(StandardShowAvailableColorsProperty);
            set => SetValue(StandardShowAvailableColorsProperty, value);
        }

        public bool StandardShowRecentColors
        {
            get => (bool)GetValue(StandardShowRecentColorsProperty);
            set => SetValue(StandardShowRecentColorsProperty, value);
        }

        public int StandardColumnCount
        {
            get => (int)GetValue(StandardColumnCountProperty);
            set => SetValue(StandardColumnCountProperty, value);
        }
    }
}