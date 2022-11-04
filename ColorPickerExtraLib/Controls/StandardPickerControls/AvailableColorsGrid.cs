using ColorPickerExtraLib.Utilities;
using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls.ColorGrids
{
    internal class AvailableColorsGrid : AColorGrid
    {
        static AvailableColorsGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AvailableColorsGrid), new FrameworkPropertyMetadata(typeof(AvailableColorsGrid)));
        }

        public void OnColorEmptyPropertyChanged(bool isEmptyActive)
        {
            if (CurrentlySelectedItem != null)
            {
                if (isEmptyActive)
                {
                    CurrentlySelectedItem.RemoveHighlightBorder(ItemBorderBrush);
                }
                else
                {
                    CurrentlySelectedItem.AddHighlightBorder(ItemBorderOuterHighlightBrush, ItemBorderInnerHighlightBrush);
                }
            }
        }

        // Creating an array of colors to fill the grid
        protected override Color[] GenerateColorArray()
        {
            Color[] gridColorArray = new Color[ColumnCount * RowCount];
            int increment = 0;

            int brightValues = (ColumnCount / 2) + 1;
            int satValues = ColumnCount - brightValues;
            int hueSplit = RowCount - 1;
            double satLow = 0.25;
            double brightLow = 0.25;

            double satIncremement = (1.0 - satLow) / satValues;
            double brightIncrement = (1.0 - brightLow) / (brightValues - 1);

            // for first horizontal line going from black, through greys, to white
            if (UsingAlphaChannel)
            {
                for (int i = 0; i < ColumnCount - 1; ++i)
                {
                    byte l = (byte)(i / (float)(ColumnCount - 2) * 255);
                    gridColorArray[increment] = Color.FromRgb(l, l, l);
                    increment++;
                }

                gridColorArray[increment] = Colors.Transparent;
                increment++;
            }
            else
            {
                for (int i = 0; i < ColumnCount; ++i)
                {
                    byte l = (byte)(i / (float)(ColumnCount - 1) * 255);
                    gridColorArray[increment] = Color.FromRgb(l, l, l);
                    increment++;
                }
            }

            // for remaining horizontal lines
            // vertically ranging through hue values
            // horizontally low brightness -> 100% brightness and saturation -> low saturation  
            for (int i = 0; i < hueSplit; ++i)
            {
                float hue = 360.0f / hueSplit * i;

                for (int j = 0; j < brightValues; ++j)
                {
                    double brightness = brightLow + (j * brightIncrement);
                    gridColorArray[increment] = ColorUtilities.HsvToRgbColor(hue, 1, brightness);
                    increment++;
                }

                for (int j = satValues - 1; j >= 0; --j)
                {
                    double saturation = satLow + (j * satIncremement);
                    gridColorArray[increment] = ColorUtilities.HsvToRgbColor(hue, saturation, 1.0);
                    increment++;
                }
            }
            return gridColorArray;
        }

        protected override void OnSelectedColorChanged(Color selectedColor)
        {
            if (CurrentlySelectedItem != null && CurrentlySelectedItem.Color != selectedColor)
            {
                CurrentlySelectedItem.RemoveHighlightBorder(ItemBorderBrush);
            }

            if (ColorGridDictionary.ContainsKey(selectedColor))
            {
                ColorGridDictionary[selectedColor].AddHighlightBorder(ItemBorderOuterHighlightBrush, ItemBorderInnerHighlightBrush);
                CurrentlySelectedItem = ColorGridDictionary[selectedColor];
            }
            else
            {
                CurrentlySelectedItem = null;
            }
        }

        protected override void UsingAlphaChannelChanged()
        {
            if (!IsLoaded || ColorGrid.Children.Count < ColumnCount)
            {
                return;
            }

            if (UsingAlphaChannel)
            {
                for (int i = 0; i < ColorGrid.Children.Count; ++i)
                {
                    if (ColorGrid.Children[i] is ColorGridItem colorGridItem)
                    {
                        if (i < ColumnCount)
                        {
                            if (i < ColumnCount - 1)
                            {
                                byte l = (byte)(i / (float)(ColumnCount - 2) * 255);
                                colorGridItem.Color = Color.FromRgb(l, l, l);
                            }
                            else
                            {
                                colorGridItem.Color = Colors.Transparent;
                            }
                        }
                        colorGridItem.ToolTip = ColorUtilities.ColorToHex(colorGridItem.Color, true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < ColorGrid.Children.Count; ++i)
                {
                    if (ColorGrid.Children[i] is ColorGridItem colorGridItem)
                    {
                        if (i < ColumnCount)
                        {
                            byte l = (byte)(i / (float)(ColumnCount - 1) * 255);
                            colorGridItem.Color = Color.FromRgb(l, l, l);
                        }
                        colorGridItem.ToolTip = ColorUtilities.ColorToHex(colorGridItem.Color, false);
                    }
                }
            }
        }
    }
}