using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls.LinearSliders
{
    internal class RgbColorSlider : AColorSlider
    {
        static RgbColorSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RgbColorSlider), new FrameworkPropertyMetadata(typeof(RgbColorSlider)));
        }

        public RgbColorSlider() : base() { }

        protected override void GenerateBackground()
        {
            Color colorStart = GetColorForSelectedArgb(0);
            Color colorEnd = GetColorForSelectedArgb(255);
            LeftCapColor.Color = colorStart;
            RightCapColor.Color = colorEnd;
            BackgroundGradient = new GradientStopCollection
            {
                new GradientStop(colorStart, 0.0),
                new GradientStop(colorEnd, 1)
            };
        }

        private Color GetColorForSelectedArgb(int value)
        {
            byte a = (byte)(CurrentColorState.A * 255);
            byte r = (byte)(CurrentColorState.RGB_R * 255);
            byte g = (byte)(CurrentColorState.RGB_G * 255);
            byte b = (byte)(CurrentColorState.RGB_B * 255);

            switch (SliderType)
            {
                case "A": return Color.FromArgb((byte)value, r, g, b);
                case "R": return Color.FromArgb(a, (byte)value, g, b);
                case "G": return Color.FromArgb(a, r, (byte)value, b);
                case "B": return Color.FromArgb(a, r, g, (byte)value);
                default: return Color.FromArgb(a, r, g, b);
            }
        }
    }
}
