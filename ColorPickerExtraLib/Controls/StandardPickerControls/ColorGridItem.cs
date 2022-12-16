namespace ColorPickerExtraLib.Controls.ColorGrids
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using ColorPickerExtraLib.Utilities;

    internal class ColorGridItem : Grid
    {
        private Color color;

        internal ColorGridItem(Color color, AColorGrid parentColorGrid, Thickness margin, Thickness borderThickness, CornerRadius innerCornerRadius, CornerRadius outerCornerRadius) : base()
        {
            this.color = color;
            Width = parentColorGrid.ItemWidth;
            Height = parentColorGrid.ItemHeight;
            Background = Brushes.Transparent;
            Margin = margin;
            ToolTip = ColorUtilities.ColorToHex(color, parentColorGrid.UsingAlphaChannel);

            DisplayBorder = new Border
            {
                Background = ColorUtilities.CheckerBrush,
                BorderThickness = borderThickness,
                CornerRadius = innerCornerRadius
            };

            ColorRectangle = new Rectangle
            {
                Fill = new SolidColorBrush(color)
            };

            InternalGrid = new Grid
            {
                Margin = borderThickness,
                OpacityMask = new VisualBrush(DisplayBorder)
            };
            InternalGrid.Children.Add(DisplayBorder);
            InternalGrid.Children.Add(ColorRectangle);

            OuterBorder = new Border
            {
                Background = Brushes.Transparent,
                CornerRadius = outerCornerRadius
            };

            InnerBorder = new Border
            {
                Margin = borderThickness,
                BorderBrush = parentColorGrid.ItemBorderBrush,
                BorderThickness = borderThickness,
                Background = Brushes.Transparent,
                CornerRadius = innerCornerRadius
            };

            Children.Add(OuterBorder);
            Children.Add(InternalGrid);
            Children.Add(InnerBorder);
        }

        internal void UpdateCornerRadius(CornerRadius innerCornerRadius, CornerRadius outerCornerRadius)
        {
            DisplayBorder.CornerRadius = innerCornerRadius;
            InnerBorder.CornerRadius = innerCornerRadius;
            OuterBorder.CornerRadius = outerCornerRadius;
        }

        internal void UpdateBorderThickness(Thickness thickness)
        {
            DisplayBorder.BorderThickness = thickness;
            InternalGrid.Margin = thickness;
            InnerBorder.Margin = thickness;
            InnerBorder.BorderThickness = thickness;
        }

        internal void UpdateBorderBrush(Brush brush)
        {
            InnerBorder.BorderBrush = brush;
        }

        internal void RemoveHighlightBorder(Brush borderBrush)
        {
            InnerBorder.BorderBrush = borderBrush;
            OuterBorder.Background = Brushes.Transparent;
        }

        internal void AddHighlightBorder(Brush outerHighlightBrush, Brush innerHighlightBrush)
        {
            InnerBorder.BorderBrush = innerHighlightBrush;
            OuterBorder.Background = outerHighlightBrush;
        }

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                ColorRectangle.Fill = new SolidColorBrush(color);
            }
        }

        public Rectangle ColorRectangle { get; private set; }

        public Border InnerBorder { get; private set; }

        public Border OuterBorder { get; private set; }

        public Grid InternalGrid { get; private set; }

        public Border DisplayBorder { get; private set; }

        /*
        <Style x:Key="ColorItemContainerStyle" TargetType="{x:Type ListBoxItem}">
        <Setter Property = "ToolTip" Value="{Binding Name}" />
        <Setter Property = "OverridesDefaultStyle" Value="True" />
        <Setter Property = "HorizontalContentAlignment" Value="Stretch" />
        <Setter Property = "VerticalContentAlignment" Value="Center" />
        <Setter Property = "Template" >
            < Setter.Value >
                < ControlTemplate TargetType="{x:Type ListBoxItem}">
                    <Grid
                        Width = "{Binding SquareSize}"
                        Height="{Binding SquareSize}"
                        Margin="{Binding Margin}"
                        OverridesDefaultStyle="True"
                        ToolTip="{Binding Name}">
                        <Border
                            x:Name="_outerBorder"
                            Margin="0"
                            Background="Transparent"
                            BorderThickness="0"
                            CornerRadius="{Binding OuterCornerRadius}"
                            OverridesDefaultStyle="True" />
                        <Border
                            x:Name="_innerBorder"
                            Margin="{Binding BorderThickness}"
                            BorderBrush="{Binding BorderBrush}"
                            BorderThickness="{Binding BorderThickness}"
                            CornerRadius="{Binding CornerRadius}"
                            OverridesDefaultStyle="True" />
                        <Grid
                            x:Name="InternalGrid"
                            Margin="{Binding BorderThickness}"
                            OverridesDefaultStyle="True">
                            <Grid.OpacityMask>
                                <VisualBrush Stretch = "None" Visual="{Binding ElementName=clipMask}" />
                            </Grid.OpacityMask>
                            <Border
                                x:Name="clipMask"
                                Background="{DynamicResource CheckerBrush}"
                                BorderThickness="{Binding BorderThickness}"
                                CornerRadius="{Binding CornerRadius}"
                                OverridesDefaultStyle="True" />
                            <Rectangle Fill = "{Binding ColorBrush}" OverridesDefaultStyle="True" />
                        </Grid>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property = "IsMouseOver" Value="True">
                            <Setter TargetName = "_outerBorder" Property="Background" Value="{Binding BorderOuterHighlightBrush}" />
                            <Setter TargetName = "_innerBorder" Property="BorderBrush" Value="{Binding BorderInnerHighlightBrush}" />
                        </Trigger>
                        <Trigger Property = "IsSelected" Value="True">
                            <Setter TargetName = "_outerBorder" Property="Background" Value="{Binding BorderOuterHighlightBrush}" />
                            <Setter TargetName = "_innerBorder" Property="BorderBrush" Value="{Binding BorderInnerHighlightBrush}" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style> */
    }
}
