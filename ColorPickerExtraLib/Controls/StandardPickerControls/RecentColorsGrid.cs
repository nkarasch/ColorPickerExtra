namespace ColorPickerExtraLib.Controls.ColorGrids
{
    using System.Windows;
    using System.Windows.Media;
    using ColorPickerExtraLib.Utilities;

    internal class RecentColorsGrid : AColorGrid
    {
        static RecentColorsGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RecentColorsGrid), new FrameworkPropertyMetadata(typeof(RecentColorsGrid)));
        }

        public RecentColorsGrid() : base() { }

        protected override void OnSelectedColorChanged(Color selectedColor)
        {
            if (!IsLoaded || ColorGrid.Children.Count == 0)
            {
                return;
            }

            int existingIndex = -1;
            int colorGridCount = ColorGrid.Children.Count;

            for (int i = 0; i < colorGridCount; ++i)
            {
                if (ColorGrid.Children[i] is ColorGridItem colorGridItem && colorGridItem.Color == selectedColor)
                {
                    existingIndex = i;
                    if ((UsingAlphaChannel && colorGridItem.Color != Colors.Transparent) || (!UsingAlphaChannel && colorGridItem.Color != Colors.White))
                    {
                        break;
                    }
                }
            }

            if (existingIndex == colorGridCount - 1)
            {
                return;
            }

            int startFrom = (existingIndex > -1) ? existingIndex : 0;
            for (int i = startFrom; i < colorGridCount - 1; ++i)
            {
                if (ColorGrid.Children[i] is ColorGridItem current &&
                    ColorGrid.Children[i + 1] is ColorGridItem next)
                {
                    current.Color = next.Color;
                    current.ToolTip = next.ToolTip;
                }
            }

            if (ColorGrid.Children[colorGridCount - 1] is ColorGridItem last)
            {
                last.Color = selectedColor;
                last.ToolTip = ColorUtilities.ColorToHex(selectedColor, UsingAlphaChannel);
            }
        }

        protected override Color[] GetColorArray()
        {
            Color[] colorArray = new Color[ColumnCount * RowCount];
            if (UsingAlphaChannel)
            {
                for (int i = 0; i < colorArray.Length; ++i)
                {
                    colorArray[i] = Colors.Transparent;
                }
            }
            else
            {
                for (int i = 0; i < colorArray.Length; ++i)
                {
                    colorArray[i] = Colors.White;
                }
            }

            return colorArray;
        }

        protected override void UsingAlphaChannelChanged()
        {
            if (!IsLoaded)
            {
                return;
            }

            if (UsingAlphaChannel)
            {
                foreach (ColorGridItem colorGridItem in ColorGrid.Children)
                {
                    colorGridItem.ToolTip = ColorUtilities.ColorToHex(colorGridItem.Color, true);
                }
            }
            else
            {
                foreach (ColorGridItem colorGridItem in ColorGrid.Children)
                {
                    if (colorGridItem.Color.A < 255)
                    {
                        colorGridItem.Color = Color.FromRgb(colorGridItem.Color.R, colorGridItem.Color.G, colorGridItem.Color.B);
                    }

                    colorGridItem.ToolTip = ColorUtilities.ColorToHex(colorGridItem.Color, false);
                }
            }
        }
    }
}
