using ColorPickerExtraLib.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls.LinearSliders
{
    internal class VerticalHueSlider : AColorSlider
    {
        static VerticalHueSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VerticalHueSlider), new FrameworkPropertyMetadata(typeof(VerticalHueSlider)));
        }

        public VerticalHueSlider() : base()
        {
            Maximum = 360;
            Orientation = Orientation.Vertical;
        }

        protected override void GenerateBackground()
        {
            BackgroundGradient = new GradientStopCollection()
                {
                    new GradientStop(GetColorForHue(360), 0.0),
                    new GradientStop(GetColorForHue(300), 1.0 / 6.0),
                    new GradientStop(GetColorForHue(240), 2.0 / 6.0),
                    new GradientStop(GetColorForHue(180), 3.0 / 6.0),
                    new GradientStop(GetColorForHue(120), 4.0 / 6.0),
                    new GradientStop(GetColorForHue(60), 5.0 / 6.0),
                    new GradientStop(GetColorForHue(0), 1.0)
                };
        }

        private static Color GetColorForHue(double hue)
        {
            System.Tuple<double, double, double> rgbtuple = ColorSpaceHelper.HsvToRgb(hue, 1, 1);
            return Color.FromArgb(255, (byte)(rgbtuple.Item1 * 255), (byte)(rgbtuple.Item2 * 255), (byte)(rgbtuple.Item3 * 255));
        }
    }
}