using ColorPickerExtraLib.Models;
using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls
{
    public partial class ColorPicker
    {
        #region Base Parent Properties

        public static readonly DependencyProperty BaseStandardButtonTextProperty =
         DependencyProperty.Register(nameof(BaseStandardButtonText), typeof(string), typeof(ColorPicker),
             new UIPropertyMetadata("Standard"));

        public static readonly DependencyProperty BaseAdvancedButtonTextProperty =
            DependencyProperty.Register(nameof(BaseAdvancedButtonText), typeof(string), typeof(ColorPicker),
                new PropertyMetadata("Advanced"));

        public static readonly DependencyProperty BaseColorModeProperty =
            DependencyProperty.Register(nameof(BaseColorMode), typeof(ColorMode), typeof(ColorPicker),
                new PropertyMetadata(ColorMode.Standard, OnColorModePropertyChanged));

        public static readonly DependencyProperty BaseAllowChangeModesProperty =
            DependencyProperty.Register(nameof(BaseAllowChangeModes), typeof(bool), typeof(ColorPicker),
                new UIPropertyMetadata(true));

        public static readonly DependencyProperty BasePickerWidthProperty =
            DependencyProperty.Register(nameof(BasePickerWidth), typeof(double), typeof(ColorPicker),
                new PropertyMetadata(280.0));

        public static readonly DependencyProperty BasePickerHeightProperty =
            DependencyProperty.Register(nameof(BasePickerHeight), typeof(double), typeof(ColorPicker),
                new PropertyMetadata(340.0));

        public string BaseStandardButtonText
        {
            get => (string)GetValue(BaseStandardButtonTextProperty);
            set => SetValue(BaseStandardButtonTextProperty, value);
        }

        public string BaseAdvancedButtonText
        {
            get => (string)GetValue(BaseAdvancedButtonTextProperty);
            set => SetValue(BaseAdvancedButtonTextProperty, value);
        }

        public ColorMode BaseColorMode
        {
            get => (ColorMode)GetValue(BaseColorModeProperty);
            set => SetValue(BaseColorModeProperty, value);
        }

        public bool BaseAllowChangeModes
        {
            get => (bool)GetValue(BaseAllowChangeModesProperty);
            set => SetValue(BaseAllowChangeModesProperty, value);
        }

        public double BasePickerWidth
        {
            get => (double)GetValue(BasePickerWidthProperty);
            set => SetValue(BasePickerWidthProperty, value);
        }

        public double BasePickerHeight
        {
            get => (double)GetValue(BasePickerHeightProperty);
            set => SetValue(BasePickerHeightProperty, value);
        }

        #endregion Base Parent Properties

        #region Standard Picker Properties

        public static readonly DependencyProperty StandardAvailableColorArrayProperty =
            DependencyProperty.Register(nameof(StandardAvailableColorArray), typeof(Color[]), typeof(ColorPicker),
                new PropertyMetadata(null));

        public static readonly DependencyProperty StandardItemSquareSizeProperty =
            DependencyProperty.Register(nameof(StandardItemSquareSize), typeof(double), typeof(ColorPicker),
                new PropertyMetadata(17.0));

        public static readonly DependencyProperty StandardItemCornerRadiusProperty =
            DependencyProperty.Register(nameof(StandardItemCornerRadius), typeof(double), typeof(ColorPicker),
                new PropertyMetadata(3.0));

        public static readonly DependencyProperty StandardItemMarginProperty =
            DependencyProperty.Register(nameof(StandardItemMargin), typeof(double), typeof(ColorPicker),
                new PropertyMetadata(1.0));

        public static readonly DependencyProperty StandardItemBorderThicknessProperty =
            DependencyProperty.Register(nameof(StandardItemBorderThickness), typeof(double), typeof(ColorPicker),
                new PropertyMetadata(1.0));

        public static readonly DependencyProperty StandardItemBorderBrushProperty =
            DependencyProperty.Register(nameof(StandardItemBorderBrush), typeof(SolidColorBrush), typeof(ColorPicker),
                new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty StandardItemInnerHighlightBrushProperty =
             DependencyProperty.Register(nameof(StandardItemInnerHighlightBrush), typeof(SolidColorBrush), typeof(ColorPicker),
                 new PropertyMetadata(Brushes.Yellow));

        public static readonly DependencyProperty StandardItemOuterHighlightBrushProperty =
            DependencyProperty.Register(nameof(StandardItemOuterHighlightBrush), typeof(SolidColorBrush), typeof(ColorPicker),
                new PropertyMetadata(Brushes.Red));

        public static readonly DependencyProperty StandardListHeaderStyleProperty =
            DependencyProperty.Register(nameof(StandardListHeaderStyle), typeof(Style), typeof(ColorPicker));

        public static readonly DependencyProperty StandardAvailableColorsHeaderProperty =
            DependencyProperty.Register(nameof(StandardAvailableColorsHeader), typeof(string), typeof(ColorPicker),
                new PropertyMetadata("Available Colors"));

        public static readonly DependencyProperty StandardAvailableColorRowsProperty =
            DependencyProperty.Register(nameof(StandardAvailableColorRows), typeof(int), typeof(ColorPicker),
                new PropertyMetadata(14));

        public static readonly DependencyProperty StandardRecentColorRowsProperty =
            DependencyProperty.Register(nameof(StandardRecentColorRows), typeof(int), typeof(ColorPicker),
                new PropertyMetadata(1));

        public static readonly DependencyProperty StandardRecentColorsHeaderProperty =
            DependencyProperty.Register(nameof(StandardRecentColorsHeader), typeof(string), typeof(ColorPicker),
                new PropertyMetadata("Recent Colors"));

        public static readonly DependencyProperty StandardShowAvailableColorsProperty =
            DependencyProperty.Register(nameof(StandardShowAvailableColors), typeof(bool), typeof(ColorPicker),
                new PropertyMetadata(true));

        public static readonly DependencyProperty StandardShowRecentColorsProperty =
            DependencyProperty.Register(nameof(StandardShowRecentColors), typeof(bool), typeof(ColorPicker),
                new PropertyMetadata(true));

        public static readonly DependencyProperty StandardColumnCountProperty =
             DependencyProperty.Register(nameof(StandardColumnCount), typeof(int), typeof(ColorPicker),
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

        public Style StandardListHeaderStyle
        {
            get => (Style)GetValue(StandardListHeaderStyleProperty);
            set => SetValue(StandardListHeaderStyleProperty, Style);
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

        public Color[] StandardAvailableColorArray
        {
            get => (Color[])GetValue(StandardAvailableColorArrayProperty);
            set => SetValue(StandardAvailableColorArrayProperty, value);
        }

        #endregion Standard Picker Properties

        #region Advanced Picker Properties

        public static readonly DependencyProperty AdvancedPickerTypeProperty =
            DependencyProperty.Register(nameof(AdvancedPickerType), typeof(AdvancedPickerType), typeof(ColorPicker),
                    new PropertyMetadata(AdvancedPickerType.HSV));

        public static readonly DependencyProperty AdvancedInnerBorderBrushProperty =
            DependencyProperty.Register(nameof(AdvancedInnerBorderBrush), typeof(Brush), typeof(ColorPicker),
                new PropertyMetadata(Brushes.DarkGray));

        public static readonly DependencyProperty AdvancedInnerBorderWidthProperty =
            DependencyProperty.Register(nameof(AdvancedInnerBorderWidth), typeof(double), typeof(ColorPicker),
                new PropertyMetadata(1.0));

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

        #endregion Advanced Picker Properties
    }
}