using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls
{
    public partial class HexColorTextBox : UserControl
    {
        public HexColorTextBox() : base()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty UsingAlphaChannelProperty =
            DependencyProperty.Register(nameof(UsingAlphaChannel), typeof(bool), typeof(HexColorTextBox),
                new PropertyMetadata(true));

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register(nameof(SelectedColor), typeof(Color), typeof(HexColorTextBox),
                new PropertyMetadata(Colors.Red));

        public bool UsingAlphaChannel
        {
            get => (bool)GetValue(UsingAlphaChannelProperty);
            set => SetValue(UsingAlphaChannelProperty, value);
        }

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        public double MaxLengthValue => UsingAlphaChannel ? 9 : 7;

        private void ColorToHexConverter_OnUsingAlphaChannelChange(object sender, EventArgs e)
        {
            textbox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textbox.GetBindingExpression(TextBox.MaxLengthProperty).UpdateTarget();
        }
    }
}
