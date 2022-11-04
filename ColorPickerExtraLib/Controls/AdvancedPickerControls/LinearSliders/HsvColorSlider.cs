using ColorPickerExtraLib.Models;
using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls.LinearSliders
{
    internal class HsvColorSlider : AColorSlider
    {
        static HsvColorSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HsvColorSlider), new FrameworkPropertyMetadata(typeof(HsvColorSlider)));
        }

        public HsvColorSlider() : base() { }

        protected override void GenerateBackground()
        {
            if (SliderType == "H")
            {
                Color colorStart = GetColorForSelectedArgb(0);
                Color colorEnd = GetColorForSelectedArgb(360);
                LeftCapColor.Color = colorStart;
                RightCapColor.Color = colorEnd;
                BackgroundGradient = new GradientStopCollection()
                {
                    new GradientStop(colorStart, 0.0),
                    new GradientStop(GetColorForSelectedArgb(60), 1.0 / 6.0),
                    new GradientStop(GetColorForSelectedArgb(120), 2.0 / 6.0),
                    new GradientStop(GetColorForSelectedArgb(180), 3.0 / 6.0),
                    new GradientStop(GetColorForSelectedArgb(240), 4.0 / 6.0),
                    new GradientStop(GetColorForSelectedArgb(300), 5.0 / 6.0),
                    new GradientStop(colorEnd, 1.0)
                };
                return;
            }

            {
                Color colorStart = GetColorForSelectedArgb(0);
                Color colorEnd = GetColorForSelectedArgb(255);
                LeftCapColor.Color = colorStart;
                RightCapColor.Color = colorEnd;
                BackgroundGradient = new GradientStopCollection
                {
                    new GradientStop(colorStart, 0.0),
                    new GradientStop(colorEnd, 1.0)
                };
            }
        }

        private Color GetColorForSelectedArgb(int value)
        {
            switch (SliderType)
            {
                case "H":
                    {
                        System.Tuple<double, double, double> rgbtuple = ColorSpaceHelper.HsvToRgb(value, CurrentColorState.HSV_S, CurrentColorState.HSV_V);
                        double r = rgbtuple.Item1, g = rgbtuple.Item2, b = rgbtuple.Item3;
                        return Color.FromArgb((byte)(CurrentColorState.A * 255), (byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
                    }

                case "S":
                    {
                        System.Tuple<double, double, double> rgbtuple = ColorSpaceHelper.HsvToRgb(CurrentColorState.HSV_H, value / 255.0, CurrentColorState.HSV_V);
                        double r = rgbtuple.Item1, g = rgbtuple.Item2, b = rgbtuple.Item3;
                        return Color.FromArgb((byte)(CurrentColorState.A * 255), (byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
                    }

                case "V":
                    {
                        System.Tuple<double, double, double> rgbtuple = ColorSpaceHelper.HsvToRgb(CurrentColorState.HSV_H, CurrentColorState.HSV_S, value / 255.0);
                        double r = rgbtuple.Item1, g = rgbtuple.Item2, b = rgbtuple.Item3;
                        return Color.FromArgb((byte)(CurrentColorState.A * 255), (byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
                    }

                default:
                    return Color.FromArgb((byte)(CurrentColorState.A * 255), (byte)(CurrentColorState.RGB_R * 255), (byte)(CurrentColorState.RGB_G * 255), (byte)(CurrentColorState.RGB_B * 255));
            }
        }
    }
}
