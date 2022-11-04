namespace ColorPickerExtraDemo.Views
{
    using ColorPickerExtraLib.Models;
    using ColorPickerExtraLib.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

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
            Debug.WriteLine("getgeometrylist");
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

        public double EmptyFontSize
        {
            get
            {
                if (_PortableColorPicker != null)
                {
                    double? fontSize = _PortableColorPicker.EmptyFontSize;
                    return fontSize ?? 0;
                }
                return 0;
            }
            set => _PortableColorPicker.EmptyFontSize = value <= 0 ? null : (double?)value;
        }



        #region Reset empty values to use FontModeHelper values

        private const string FontFamilyReset = "FontFamilyReset";
        private const string HorizontalAlignmentReset = "HorizontalAlignmentReset";
        private const string VerticalAlignmentReset = "VerticalAlignmentReset";
        private const string FontStyleReset = "FontStyleReset";
        private const string FontWeightReset = "FontWeightReset";
        private const string TextDecorationsReset = "TextDecorationsReset";
        private const string ViewboxStretchReset = "ViewboxStretchReset";
        private const string FontSizeReset = "FontSizeReset";
        private const string MarginReset = "MarginReset";
        private const string TextColorReset = "TextColorReset";
        private const string ShapeColorReset = "ShapeColorReset";
        private const string EmptyBorderBrushReset = "EmptyBorderBrushReset";
        private const string EmptyBorderThicknessReset = "EmptyBorderThicknessReset";

        private void Null_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;
            switch (clicked.Tag)
            {
                case FontFamilyReset:
                    _PortableColorPicker.EmptyFontFamily = null;
                    break;
                case HorizontalAlignmentReset:
                    _PortableColorPicker.EmptyFontHorizontalAlignment = null;
                    break;
                case VerticalAlignmentReset:
                    _PortableColorPicker.EmptyVerticalAlignment = null;
                    break;
                case FontStyleReset:
                    _PortableColorPicker.EmptyFontStyle = null;
                    break;
                case FontWeightReset:
                    _PortableColorPicker.EmptyFontWeight = null;
                    break;
                case TextDecorationsReset:
                    _PortableColorPicker.EmptyTextDecorations = null;
                    break;
                case ViewboxStretchReset:
                    _PortableColorPicker.EmptyViewboxStretch = null;
                    break;
                case FontSizeReset:
                    EmptyFontSize = 0;
                    _PortableColorPicker.EmptyFontSize = null;
                    break;
                case MarginReset:
                    _emptyFontMargin.Text = "0";
                    // _PortableColorPicker.EmptyFontMargin = new Thickness?();
                    break;
                case EmptyBorderBrushReset:
                    {
                        _PortableColorPicker.EmptyBorderBrush = Brushes.Black;
                        break;
                    }
                case EmptyBorderThicknessReset:
                    _emptyBorderThickness.Text = "0";
                    //_PortableColorPicker.EmptyBorderThickness = new Thickness?();
                    break;
                case TextColorReset:
                    {
                        if (_textColorLabel != null && _textColorLabel.Foreground is SolidColorBrush brush)
                        {
                            _PortableColorPicker.EmptyFontColorBrush = brush;
                        }
                        break;
                    }
                case ShapeColorReset:
                    {
                        if (_textColorLabel != null && _textColorLabel.Foreground is SolidColorBrush brush)
                        {
                            _PortableColorPicker.EmptyShapeColorBrush = brush;
                        }
                        break;
                    }
            }
        }

        #endregion


        //public Thickness StringToThickness(string input)
        //{
        //    if (input.Length == 0)
        //    {
        //        return new Thickness(0);
        //    }

        //    char[] delimiters = new[] { ',', ' ' };
        //    string[] splitArray = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        //    List<double> outputList = new List<double>();

        //    foreach (string testIsNumber in splitArray)
        //    {
        //        if (double.TryParse(testIsNumber, out double testOutput))
        //        {
        //            outputList.Add(testOutput);
        //        }
        //    }

        //    switch (outputList.Count)
        //    {
        //        case 0:
        //        default:
        //            return new Thickness(0);
        //        case 1:
        //            return new Thickness(outputList[0]);
        //        case 2:
        //        case 3:
        //            return new Thickness(outputList[0], outputList[1], outputList[0], outputList[1]);
        //        case 4:
        //            return new Thickness(outputList[0], outputList[1], outputList[2], outputList[3]);
        //    }
        //}
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

        private void TextBox_PreviewExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void OnSetToEmptyButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (_PortableColorPicker != null)
            {
                _PortableColorPicker.EnableEmptyMode = true;
                _PortableColorPicker.IsEmpty = true;
            }
        }
    }
}