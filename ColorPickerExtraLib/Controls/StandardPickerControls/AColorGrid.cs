namespace ColorPickerExtraLib.Controls.ColorGrids
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using ColorPickerExtraLib.Models;

    [TemplatePart(Name = "PART_ColorGrid", Type = typeof(Grid))]
    internal abstract class AColorGrid : Control
    {
        static AColorGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AColorGrid), new FrameworkPropertyMetadata(typeof(AColorGrid)));
        }

        internal AColorGrid() : base()
        {
            ColorGridDictionary = new Dictionary<Color, ColorGridItem>();
            Loaded += (sender, e) =>
            {
                if (ColorGrid != null && ColorGrid.Children.Count != ColumnCount * RowCount)
                {
                    BuildColorGrid();
                }
            };
            SnapsToDevicePixels = true;
        }

        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(nameof(ColorChanged),
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AColorGrid));

        public event RoutedEventHandler ColorChanged
        {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ColorGrid = (Grid)GetTemplateChild("PART_ColorGrid");
        }

        #region Properties

        #region DependencyProperties

        internal static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.Register(nameof(ColumnCount), typeof(int), typeof(AColorGrid),
                new PropertyMetadata(14, RebuildGrid));

        internal static readonly DependencyProperty RowCountProperty =
            DependencyProperty.Register(nameof(RowCount), typeof(int), typeof(AColorGrid),
                new PropertyMetadata(14, RebuildGrid));

        internal static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register(nameof(ItemWidth), typeof(double), typeof(AColorGrid),
                new PropertyMetadata(17.0, RebuildGrid));

        internal static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register(nameof(ItemHeight), typeof(double), typeof(AColorGrid),
                new PropertyMetadata(17.0, RebuildGrid));

        internal static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.Register(nameof(ItemCornerRadius), typeof(double), typeof(AColorGrid),
                new PropertyMetadata(3.0, RebuildGrid));

        internal static readonly DependencyProperty ItemMarginProperty =
            DependencyProperty.Register(nameof(ItemMargin), typeof(double), typeof(AColorGrid),
                new PropertyMetadata(1.0, RebuildGrid));

        internal static readonly DependencyProperty ItemBorderThicknessProperty =
            DependencyProperty.Register(nameof(ItemBorderThickness), typeof(double), typeof(AColorGrid),
                new PropertyMetadata(1.0, RebuildGrid));

        internal static readonly DependencyProperty ItemBorderBrushProperty =
            DependencyProperty.Register(nameof(ItemBorderBrush), typeof(SolidColorBrush), typeof(AColorGrid),
                new PropertyMetadata(Brushes.Black, OnItemBorderBrushChanged));

        internal static readonly DependencyProperty ItemBorderOuterHighlightBrushProperty =
            DependencyProperty.Register(nameof(ItemBorderOuterHighlightBrush), typeof(SolidColorBrush), typeof(AColorGrid),
                new PropertyMetadata(Brushes.Red, OnItemBorderHighlightBrushChanged));

        internal static readonly DependencyProperty ItemBorderInnerHighlightBrushProperty =
            DependencyProperty.Register(nameof(ItemBorderInnerHighlightBrush), typeof(SolidColorBrush), typeof(AColorGrid),
                new PropertyMetadata(Brushes.Yellow, OnItemBorderHighlightBrushChanged));

        internal static readonly DependencyProperty UsingAlphaChannelProperty =
            DependencyProperty.Register(nameof(UsingAlphaChannel), typeof(bool), typeof(AColorGrid),
                new PropertyMetadata(true, UsingAlphaChannelChanged));

        internal static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register(nameof(SelectedColor), typeof(Color), typeof(AColorGrid),
                new PropertyMetadata(Colors.Transparent, OnSelectedColorChanged));

        internal int ColumnCount
        {
            get => (int)GetValue(ColumnCountProperty);
            set => SetValue(ColumnCountProperty, value);
        }

        internal int RowCount
        {
            get => (int)GetValue(RowCountProperty);
            set => SetValue(RowCountProperty, value);
        }

        internal double ItemWidth
        {
            get => (double)GetValue(ItemWidthProperty);
            set => SetValue(ItemWidthProperty, value);
        }

        internal double ItemHeight
        {
            get => (double)GetValue(ItemHeightProperty);
            set => SetValue(ItemHeightProperty, value);
        }

        internal double ItemCornerRadius
        {
            get => (double)GetValue(ItemCornerRadiusProperty);
            set => SetValue(ItemCornerRadiusProperty, value);
        }

        internal double ItemMargin
        {
            get => (double)GetValue(ItemMarginProperty);
            set => SetValue(ItemMarginProperty, value);
        }

        internal double ItemBorderThickness
        {
            get => (double)GetValue(ItemBorderThicknessProperty);
            set => SetValue(ItemBorderThicknessProperty, value);
        }

        internal SolidColorBrush ItemBorderBrush
        {
            get => (SolidColorBrush)GetValue(ItemBorderBrushProperty);
            set => SetValue(ItemBorderBrushProperty, value);
        }

        internal SolidColorBrush ItemBorderInnerHighlightBrush
        {
            get => (SolidColorBrush)GetValue(ItemBorderInnerHighlightBrushProperty);
            set => SetValue(ItemBorderInnerHighlightBrushProperty, value);
        }

        internal SolidColorBrush ItemBorderOuterHighlightBrush
        {
            get => (SolidColorBrush)GetValue(ItemBorderOuterHighlightBrushProperty);
            set => SetValue(ItemBorderOuterHighlightBrushProperty, value);
        }

        internal bool UsingAlphaChannel
        {
            get => (bool)GetValue(UsingAlphaChannelProperty);
            set => SetValue(UsingAlphaChannelProperty, value);
        }

        internal Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        #endregion DependencyProperties

        protected Grid ColorGrid { get; private set; }

        protected ColorGridItem CurrentlySelectedItem { get; set; }

        protected Dictionary<Color, ColorGridItem> ColorGridDictionary { get; private set; }

        #endregion Properties

        #region Property Changed Handlers

        protected abstract void UsingAlphaChannelChanged();

        protected abstract void OnSelectedColorChanged(Color selectedColor);

        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AColorGrid aColorGrid)
            {
                aColorGrid.OnSelectedColorChanged((Color)e.NewValue);
            }
        }

        protected static void RebuildGrid(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is AColorGrid colorGrid && colorGrid.IsLoaded)
            {
                colorGrid.BuildColorGrid();
                return;
            }
        }

        private static void OnItemBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AColorGrid colorGrid && colorGrid.IsLoaded)
            {
                foreach (ColorGridItem colorGriditem in colorGrid.ColorGrid.Children)
                {
                    colorGriditem.InnerBorder.BorderBrush = colorGrid.ItemBorderBrush;
                }
            }
        }

        private static void OnItemBorderHighlightBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AColorGrid colorGrid && colorGrid.CurrentlySelectedItem != null)
            {
                colorGrid.CurrentlySelectedItem.AddHighlightBorder(colorGrid.ItemBorderOuterHighlightBrush, colorGrid.ItemBorderInnerHighlightBrush);
            }
        }

        private static void UsingAlphaChannelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AColorGrid colorGrid)
            {
                colorGrid.UsingAlphaChannelChanged();
            }
        }

        #endregion Property Changed Handlers

        #region Event Handlers

        private void OuterGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is ColorGridItem colorGridItem)
            {
                RaiseEvent(new ColorRoutedEventArgs(ColorChangedEvent, colorGridItem.Color));
            }
        }

        private void OuterGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is ColorGridItem colorGridItem && colorGridItem != CurrentlySelectedItem)
            {
                colorGridItem.RemoveHighlightBorder(ItemBorderBrush);
            }
        }

        private void OuterGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is ColorGridItem colorGridItem)
            {
                colorGridItem.AddHighlightBorder(ItemBorderOuterHighlightBrush, ItemBorderInnerHighlightBrush);
            }
        }

        #endregion Event Handlers

        #region Methods        

        private void BuildColorGrid()
        {
            ColorGridDictionary.Clear();
            if (ColorGrid == null)
            {
                return;
            }

            if (ColorGrid.Children != null)
            {
                ColorGrid.Children.Clear();
            }

            if (ColorGrid.ColumnDefinitions != null)
            {
                ColorGrid.ColumnDefinitions.Clear();
            }

            if (ColorGrid.RowDefinitions != null)
            {
                ColorGrid.RowDefinitions.Clear();
            }

            CreateGridItems(GetColorArray());
        }

        private void CreateGridItems(Color[] colorArray)
        {
            int actualRowCount = ((colorArray.Length - 1) / ColumnCount) + 1;
            double perSizeWidth = ItemWidth + (ItemMargin * 2);
            double perSizeHeight = ItemHeight + (ItemMargin * 2);

            ColorGrid.Width = perSizeWidth * ColumnCount;
            ColorGrid.Height = perSizeHeight * actualRowCount;
            for (int i = 0; i < ColumnCount; ++i)
            {
                ColorGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(perSizeWidth)
                });
            }

            for (int i = 0; i < actualRowCount; ++i)
            {
                ColorGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(perSizeHeight)
                });
            }

            Thickness margin = new Thickness(ItemMargin);
            Thickness borderThickness = new Thickness(ItemBorderThickness);
            CornerRadius innerCornerRadius = new CornerRadius(ItemCornerRadius);
            CornerRadius outerCornerRadius = new CornerRadius(ItemCornerRadius + ItemBorderThickness);
            for (int i = 0; i < colorArray.Length; ++i)
            {
                int row = i / ColumnCount;
                int column = i % ColumnCount;
                ColorGridItem colorItem = new ColorGridItem(colorArray[i], this, margin, borderThickness, innerCornerRadius, outerCornerRadius);
                ColorGrid.Children.Add(colorItem);
                Grid.SetRow(colorItem, row);
                Grid.SetColumn(colorItem, column);

                ColorGridDictionary[colorArray[i]] = colorItem;

                colorItem.MouseEnter += OuterGrid_MouseEnter;
                colorItem.MouseLeave += OuterGrid_MouseLeave;
                colorItem.MouseDown += OuterGrid_MouseDown;
            }
        }

        protected abstract Color[] GetColorArray();

        #endregion Methods        
    }
}
