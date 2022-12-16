namespace ColorPickerExtraDemo.Views
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using ColorPickerExtraLib.Models;
    using ColorPickerExtraLib.Utilities;

    public partial class ColorSelectionView : UserControl
    {
        public ColorSelectionView()
        {
            InitializeComponent();
        }

        public List<EmptyShapeComboItem> ShapeGeometryComboItems { get; } = GetGeometryList();

        public List<TextDecorationComboItem> TextDecorationComboItems { get; } = GetTextDecorationItems();

        public List<FontFamily> FontFamiliesComboItems { get; } = GetFontFamilies();

        public ObservableCollection<Color> CustomColorList { get; } = new ObservableCollection<Color>();

        public double EmptyFontSize
        {
            get
            {
                if (_PortableColorPicker != null)
                {
                    double? emptyFontSize = _PortableColorPicker.EmptyFontSize;
                    if (emptyFontSize.HasValue && emptyFontSize.Value > 0)
                    {
                        return emptyFontSize.Value;
                    }
                    else
                    {
                        _EmptyFontSize_Changer.Value = _PortableColorPicker.PortableFontSize;
                        return _PortableColorPicker.PortableFontSize;
                    }
                }

                return 0;
            }

            set => _PortableColorPicker.EmptyFontSize = value <= 0 ? null : (double?)value;
        }

        #region Nullify "empty" values to default to use "Portable" values when not set

        private void EmptyFontBrushReset_Click(object sender, RoutedEventArgs e)
        {
            _emptyFontBrushPicker.IsEmpty = true;
            _PortableColorPicker.EmptyFontBrush = null;
        }

        private void EmptyFontFamilyReset_Click(object sender, RoutedEventArgs e)
        {
            _PortableColorPicker.EmptyFontFamily = null;
        }

        private void EmptyFontHorizontalAlignmentReset_Click(object sender, RoutedEventArgs e)
        {
            _PortableColorPicker.EmptyFontHorizontalAlignment = null;
        }

        private void EmptyFontVerticalAlignmentReset_Click(object sender, RoutedEventArgs e)
        {
            _PortableColorPicker.EmptyFontVerticalAlignment = null;
        }

        private void EmptyFontStyleReset_Click(object sender, RoutedEventArgs e)
        {
            _PortableColorPicker.EmptyFontStyle = null;
        }

        private void EmptyFontWeightReset_Click(object sender, RoutedEventArgs e)
        {
            _PortableColorPicker.EmptyFontWeight = null;
        }

        private void EmptyTextDecorationsReset_Click(object sender, RoutedEventArgs e)
        {
            _PortableColorPicker.EmptyFontTextDecorations = null;
        }

        private void EmptyFontViewboxStretchReset_Click(object sender, RoutedEventArgs e)
        {
            _PortableColorPicker.EmptyFontViewboxStretch = null;
        }

        private void EmptyFontSizeReset_Click(object sender, RoutedEventArgs e)
        {
            _PortableColorPicker.EmptyFontSize = null;
            _EmptyFontSize_Changer.Value = 0;
        }

        private void EmptyFontMarginReset_Click(object sender, RoutedEventArgs e)
        {
            _emptyFontMargin.Text = null;
        }

        #endregion Nullify empty values

        #region Margin text input

        private void Thickness_PreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length == 1)
            {
                char input = e.Text[0];
                if (!char.IsDigit(input) && input != ',' && input != '.' /*&& input != '-'*/)
                {
                    e.Handled = true;
                }
            }
        }

        private void Thickness_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string currentText = textBox.Text;
            string newText = currentText;
            if (currentText.Length > 0)
            {
                int currentCaretIndex = textBox.CaretIndex;
                if (currentText.Contains(' '))
                {
                    newText = currentText.Replace(" ", string.Empty);
                }

                for (int i = newText.Length - 1; i >= 0; --i)
                {
                    char c = newText[i];

                    if (c == ',' && (i == 0 || newText[i - 1] == ',' || newText.Count(f => f == ',') > 3))
                    {
                        newText = newText.Remove(i, 1);
                    }

                    if (i > 0 && c == '.' && (newText[i - 1] == '.' || HasPreceedingMatch(newText.Substring(0, i - 1), '.', ',')))
                    {
                        newText = newText.Remove(i, 1);
                    }
                }

                if (newText.Length < currentText.Length)
                {
                    int newCaretIndex = currentCaretIndex - (currentText.Length - newText.Length);
                    if (newCaretIndex >= 0)
                    {
                        textBox.Text = newText;
                        textBox.CaretIndex = newCaretIndex;
                    }
                }
            }
        }

        private static bool HasPreceedingMatch(string substring, char toFind = '.', char toStop = ',')
        {
            for (int i = substring.Length - 1; i >= 0; --i)
            {
                if (substring[i] == toFind)
                {
                    return true;
                }
                else if (substring[i] == toStop)
                {
                    return false;
                }
            }

            return false;
        }

        private void TextBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        #endregion Margin text input

        #region CustomColorArray

        private void CustomColorAdd_Click(object sender, RoutedEventArgs e)
        {
            CustomColorList.Add(_PortableColorPicker.SelectedColor);
            UpdateArray();
        }

        private void CustomColorChange_Click(object sender, RoutedEventArgs e)
        {
            if (customColorListView.SelectedIndex > -1 && customColorListView.SelectedIndex < CustomColorList.Count)
            {
                CustomColorList[customColorListView.SelectedIndex] = _PortableColorPicker.SelectedColor;
                UpdateArray();
            }
        }

        private void CustomColorRemove_Click(object sender, RoutedEventArgs e)
        {
            if (customColorListView.SelectedIndex > -1 && customColorListView.SelectedIndex < CustomColorList.Count)
            {
                CustomColorList.RemoveAt(customColorListView.SelectedIndex);
                UpdateArray();
            }
        }

        private void UpdateArray()
        {
            _PortableColorPicker.StandardAvailableColorArray = CustomColorList == null || CustomColorList.Count == 0 ? null : CustomColorList.ToArray();
        }

        #endregion CustomColorArray

        #region ComboBoxItem values

        private static List<EmptyShapeComboItem> GetGeometryList()
        {
            List<EmptyShapeComboItem> list = new List<EmptyShapeComboItem>();
            foreach (ShapeGeometry geometryType in (ShapeGeometry[])Enum.GetValues(typeof(ShapeGeometry)))
            {
                list.Add(new EmptyShapeComboItem(geometryType));
            }

            return list;
        }

        private static List<TextDecorationComboItem> GetTextDecorationItems()
        {
            return new List<TextDecorationComboItem>
                {
                    new TextDecorationComboItem(string.Empty, null),
                    new TextDecorationComboItem("Baseline", TextDecorations.Baseline),
                    new TextDecorationComboItem("OverLine", TextDecorations.OverLine),
                    new TextDecorationComboItem("Strikethrough", TextDecorations.Strikethrough),
                    new TextDecorationComboItem("Underline", TextDecorations.Underline)
                };
        }

        private static List<FontFamily> GetFontFamilies()
        {
            List<FontFamily> sorted = new List<FontFamily>();
            ICollection<FontFamily> fonts = Fonts.SystemFontFamilies;
            foreach (FontFamily font in fonts)
            {
                sorted.Add(font);
            }

            sorted.Sort((x, y) => x.Source.CompareTo(y.Source));
            return sorted;
        }

        public struct TextDecorationComboItem
        {
            public TextDecorationComboItem(string name, TextDecorationCollection textDecorations)
            {
                Name = name;
                TextDecorations = textDecorations;
            }

            public string Name { get; }

            public TextDecorationCollection TextDecorations { get; }
        }

        public struct EmptyShapeComboItem
        {
            public EmptyShapeComboItem(ShapeGeometry shapeGeometry)
            {
                Value = shapeGeometry;
                Name = shapeGeometry.ToString();
                Geometry = EmptyShapeGeometry.GetShapeGeometry(shapeGeometry);
            }

            public ShapeGeometry Value { get; }

            public string Name { get; }

            public Geometry Geometry { get; }
        }

        #endregion ComboBoxItem values
    }
}