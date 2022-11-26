using ColorPickerExtraLib.Controls;
using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public enum Theme { Default, Dark, Light }

        private void DefaultRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            app.ChangeTheme(Theme.Default);
        }

        private void DarkRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            app.ChangeTheme(Theme.Dark);
        }

        private void LightRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            app.ChangeTheme(Theme.Light);
        }

        private void DefaultScheme_Checked(object sender, RoutedEventArgs e)
        {
            if (Demo != null && Demo.IsLoaded && Demo._PortableColorPicker != null)
            {
                PortableColorPicker picker = Demo._PortableColorPicker;
                picker.EnableEmptyMode = false;
                picker.Width = 72;
                picker.Height = 24;
                picker.PortableShapeStretch = Stretch.Uniform;
                picker.PortableShapeHorizontalAlignment = HorizontalAlignment.Left;
                picker.PortableShapeMode = ColorPickerExtraLib.Models.ShowOnToggleButton.Off;
                picker.PortableShapeGeometry = ColorPickerExtraLib.Models.ShapeGeometry.ParallelCross;
            }
        }

        private void TextScheme_Checked(object sender, RoutedEventArgs e)
        {
            if (Demo != null && Demo.IsLoaded && Demo._PortableColorPicker != null)
            {
                PortableColorPicker picker = Demo._PortableColorPicker;
                picker.StandardAvailableColorArray = new Color[]
                {
                    Colors.Red,Colors.Blue, Colors.Green, Colors.Yellow, Colors.Orange, Colors.Purple, Colors.Brown, Colors.Black
                };
                picker.StandardItemSquareSize = 60;
                picker.StandardAvailableColorsHeader = "Crayons";
                picker.StandardShowRecentColors = false;
                picker.SelectedColor = Color.FromRgb(181, 255, 64);
                picker.StandardItemBorderBrush = Brushes.White;
                picker.StandardItemBorderThickness = 5;
                picker.EnableEmptyMode = false;
                picker.IsEmpty = false;
                picker.Width = 100;
                picker.Height = 24;
                picker.EmptyBorderMode = ColorPickerExtraLib.Models.EmptyElementMode.PortableSettings;
                picker.PortableShowDropdownButton = true;
                picker.PortableFontSize = 12;
                picker.PortableBorderModeThickness = new Thickness(2,2,0,2);
                picker.PortableBorderConstantBrush = Brushes.Black;
                picker.PortableBorderMode = ColorPickerExtraLib.Models.ShowOnToggleButton.ConstantColor;
                picker.PortableBorderConstantHighlightBrush = Brushes.Red;
                picker.PortableFontMode = ColorPickerExtraLib.Models.ShowOnToggleButton.SelectedColor;
                picker.PortableFontMargin = new Thickness(0);
                picker.PortableBackgroundMode = ColorPickerExtraLib.Models.ShowOnToggleButton.InverseColors;
                picker.PortableShapeStretch = Stretch.Uniform;
                picker.PortableShapeMode = ColorPickerExtraLib.Models.ShowOnToggleButton.Off;
                picker.EmptyShapeMode = ColorPickerExtraLib.Models.EmptyElementMode.Off;
                picker.EmptyFontMargin = new Thickness(0);
                picker.EmptyFontMode = ColorPickerExtraLib.Models.EmptyElementMode.EmptySettings;
                picker.EmptyFontText = "No Fill";
                picker.EmptyFontSize = null;
                picker.EmptyFontTextDecorations = TextDecorations.Strikethrough;
                picker.EmptyFontHorizontalAlignment = HorizontalAlignment.Center;
            }
        }

        private void ShapeScheme_Checked(object sender, RoutedEventArgs e)
        {
            if (Demo != null && Demo.IsLoaded && Demo._PortableColorPicker != null)
            {
                PortableColorPicker picker = Demo._PortableColorPicker;
                picker.SelectedColor = Color.FromRgb(181, 255, 64);
                picker.EnableEmptyMode = true;
                picker.IsEmpty = false;
                picker.StandardAvailableColorArray = null;
                picker.StandardItemSquareSize = 15;
                picker.Width = 200;
                picker.Height = 40;
                picker.EmptyBorderMode = ColorPickerExtraLib.Models.EmptyElementMode.PortableSettings;
                picker.PortableShowDropdownButton = false;
                picker.PortableFontSize = 20;
                picker.PortableBorderModeThickness = new Thickness(5);
                picker.PortableBorderConstantBrush = Brushes.Orange;
                picker.PortableBorderMode = ColorPickerExtraLib.Models.ShowOnToggleButton.ConstantColor;
                picker.PortableBorderConstantHighlightBrush = Brushes.Red;
                picker.PortableFontMode = ColorPickerExtraLib.Models.ShowOnToggleButton.SelectedColor;
                picker.PortableFontUseHexText = true;
                picker.PortableShapeLineWidth = 5;
                picker.PortableShapeMargin = new Thickness(2);
                picker.PortableFontMargin = new Thickness(0, 0, 20, 0);
                picker.PortableShapeHorizontalAlignment = HorizontalAlignment.Right;
                picker.PortableFontHorizontalAlignment = HorizontalAlignment.Center;
                picker.PortableBackgroundMode = ColorPickerExtraLib.Models.ShowOnToggleButton.InverseColors;
                picker.PortableShapeStretch = Stretch.Uniform;
                picker.PortableShapeMode = ColorPickerExtraLib.Models.ShowOnToggleButton.SelectedColor;
                picker.PortableShapeGeometry = ColorPickerExtraLib.Models.ShapeGeometry.ParallelCross;
            }
        }
    }
}
