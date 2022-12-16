namespace ColorPickerExtraLib.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    [TemplatePart(Name = "PART_SwapButton", Type = typeof(Button))]
    internal class ColorDisplay : AdvancedControlBase
    {
        private Button swapButton;

        static ColorDisplay()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorDisplay), new FrameworkPropertyMetadata(typeof(ColorDisplay)));
        }

        public ColorDisplay() : base()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (swapButton != null)
            {
                swapButton.Click -= SwapButton_Click;
            }

            swapButton = (Button)GetTemplateChild("PART_SwapButton");
            swapButton.Click += SwapButton_Click;
        }

        #region Event Handlers

        private void SwapButton_Click(object sender, RoutedEventArgs e)
        {
            SwapColors();
        }

        #endregion Event Handlers

        #region Properties

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(double), typeof(ColorDisplay),
                new PropertyMetadata(0d));

        public static readonly DependencyProperty AdvancedInnerBorderBrushProperty =
            DependencyProperty.Register(nameof(AdvancedInnerBorderBrush), typeof(Brush), typeof(ColorDisplay),
                new PropertyMetadata(Brushes.DarkGray));

        public static readonly DependencyProperty AdvancedInnerBorderWidthProperty =
            DependencyProperty.Register(nameof(AdvancedInnerBorderWidth), typeof(double), typeof(ColorDisplay),
                new PropertyMetadata(1.0));

        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
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

        #endregion Properties
    }
}
