namespace ColorPickerExtraDemo.Views
{
    public partial class ColorSelectionView : UserControl
    {
        public class EmptyShapeComboItem
        {
            public ShapeGeometry Value { get; }
            public string Name { get; }
            public Geometry Geometry { get; }

            public EmptyShapeComboItem(ShapeGeometry shapeGeometry)
            {
                Value = shapeGeometry;
                Name = shapeGeometry.ToString();
                Geometry = EmptyShapeGeometry.GetShapeGeometry(shapeGeometry);
            }
        }

        public List<EmptyShapeComboItem> ShapeGeometryComboItems { get; } = GetGeometryList();

        public static List<EmptyShapeComboItem> GetGeometryList()
        {
            List<EmptyShapeComboItem> list = new List<EmptyShapeComboItem>();
            foreach (ShapeGeometry geometryType in (ShapeGeometry[])Enum.GetValues(typeof(ShapeGeometry)))
            {
                list.Add(new EmptyShapeComboItem(geometryType));
            }
            return list;
        }

        public struct TextDecorationComboItem
        {
            public string Name { get; }
            public TextDecorationCollection TextDecorations { get; }
            public TextDecorationComboItem(string name, TextDecorationCollection textDecorations)
            {
                Name = name;
                TextDecorations = textDecorations;
            }
        }

        public List<TextDecorationComboItem> TextDecorationComboItems { get; } =
            new List<TextDecorationComboItem> {
                new TextDecorationComboItem("", null),
                new TextDecorationComboItem("Baseline", TextDecorations.Baseline),
                new TextDecorationComboItem("OverLine", TextDecorations.OverLine),
                new TextDecorationComboItem("Strikethrough", TextDecorations.Strikethrough),
                new TextDecorationComboItem("Underline", TextDecorations.Underline)
            };

        public List<FontFamily> FontFamiliesComboItems { get; } = FontFamilies();

        private static List<FontFamily> FontFamilies()
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

        public ColorSelectionView()
        {
            InitializeComponent();
        }

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
                        _EmptyFontSize_Changer.Value = 0;
                        return 0;
                    }
                }
                return 0;
            }
            set => _PortableColorPicker.EmptyFontSize = value <= 0 ? null : (double?)value;
        }



        #region Nullify "empty" values to default to "Portable" values when not set

        private const string EmptyFontFamilyReset = "EmptyFontFamilyReset";
        private const string EmptyFontHorizontalAlignmentReset = "EmptyFontHorizontalAlignmentReset";
        private const string EmptyFontVerticalAlignmentReset = "EmptyFontVerticalAlignmentReset";
        private const string EmptyFontStyleReset = "EmptyFontStyleReset";
        private const string EmptyFontWeightReset = "EmptyFontWeightReset";
        private const string EmptyTextDecorationsReset = "EmptyTextDecorationsReset";
        private const string EmptyFontViewboxStretchReset = "EmptyFontViewboxStretchReset";
        private const string EmptyFontSizeReset = "EmptyFontSizeReset";
        private const string EmptyFontMarginReset = "EmptyFontMarginReset";
        private const string EmptyFontBrushReset = "EmptyFontBrushReset";

        private void Null_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;
            switch (clicked.Tag)
            {
                case EmptyFontFamilyReset:
                    _PortableColorPicker.EmptyFontFamily = null;
                    break;
                case EmptyFontHorizontalAlignmentReset:
                    _PortableColorPicker.EmptyFontHorizontalAlignment = null;
                    break;
                case EmptyFontVerticalAlignmentReset:
                    _PortableColorPicker.EmptyFontVerticalAlignment = null;
                    break;
                case EmptyFontStyleReset:
                    _PortableColorPicker.EmptyFontStyle = null;
                    break;
                case EmptyFontWeightReset:
                    _PortableColorPicker.EmptyFontWeight = null;
                    break;
                case EmptyTextDecorationsReset:
                    _PortableColorPicker.EmptyFontTextDecorations = null;
                    break;
                case EmptyFontViewboxStretchReset:
                    _PortableColorPicker.EmptyFontViewboxStretch = null;
                    break;
                case EmptyFontSizeReset:
                    _PortableColorPicker.EmptyFontSize = null;
                    _EmptyFontSize_Changer.Value = 0;
                    break;
                case EmptyFontMarginReset:
                    _emptyFontMargin.Text = null;
                    break;
                case EmptyFontBrushReset:
                    _emptyFontBrushPicker.IsEmpty = true;
                    _PortableColorPicker.EmptyFontBrush = null;
                    break;

            }
        }

        #endregion



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
                    newText = currentText.Replace(" ", "");
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
            if (CustomColorList == null || CustomColorList.Count == 0)
            {
                _PortableColorPicker.StandardAvailableColorArray = null;
            }
            else
            {
                _PortableColorPicker.StandardAvailableColorArray = CustomColorList.ToArray();
            }
        }
    }
}