namespace ColorPickerExtraLib.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;

    public static class ColorUtilities
    {
        public static readonly Dictionary<string, Color> KnownColors = GetKnownColors();


        private static Dictionary<string, Color> GetKnownColors()
        {
            var colorProperties = typeof(Colors).GetProperties(BindingFlags.Static | BindingFlags.Public);
            return colorProperties.ToDictionary(p => p.Name, p => (Color)p.GetValue(null, null));
        }

        public static string ColorToHex(Color color, bool usingAlpha)
        {
            return usingAlpha ? color.ToString() : color.ToString().Remove(1, 2);
        }

        /// <summary>
        /// Adding a fake background to transparency colors for Border and Font modes on Toggle Button
        /// 
        /// Using an over compositing formula
        /// from https://en.wikipedia.org/wiki/Alpha_compositing
        /// A0 = Aa + Ab(1-Aa)
        /// c0 = (CaAa + CbAb(1-Aa)/A0
        /// </summary>
        public static Color CombineColors(Color foregroundColor, Color? backgroundColor = null)
        {
            if (foregroundColor.A == 255)
            {
                return foregroundColor;
            }

            int r, g, b;

            if (backgroundColor == null || !backgroundColor.HasValue)
            {
                // Always using full opacity white as background so A0 and Ab is cancelled
                // c0 = CaAa + (1-Aa)
                // backgroundColor = Colors.White;
                double a = foregroundColor.A / 255.0;
                r = (int)((foregroundColor.R * a) + (255 * (1.0 - a)));
                g = (int)((foregroundColor.G * a) + (255 * (1.0 - a)));
                b = (int)((foregroundColor.B * a) + (255 * (1.0 - a)));
            }
            else
            {
                double aa = foregroundColor.A / 255.0;
                double ab = foregroundColor.A / 255.0;
                double a0 = aa + (ab * (1.0 - aa));

                r = (int)(((foregroundColor.R * aa) + (backgroundColor.Value.R * (1.0 - aa))) / a0);
                g = (int)(((foregroundColor.G * aa) + (backgroundColor.Value.G * (1.0 - aa))) / a0);
                b = (int)(((foregroundColor.B * aa) + (backgroundColor.Value.B * (1.0 - aa))) / a0);
            }

            r = Math.Max(r, 0);
            r = Math.Min(255, r);

            g = Math.Max(g, 0);
            g = Math.Min(255, g);

            b = Math.Max(b, 0);
            b = Math.Min(255, b);

            return Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
        }

        public static Color HsvToRgbColor(double h, double s = 1.0, double v = 1.0)
        {
            if (h >= 360.0)
            {
                h = 0;
            }

            h /= 60;
            int i = (int)h;
            double f = h - i;
            byte p = Convert.ToByte(255.0 * v * (1 - s));
            byte q = Convert.ToByte(255.0 * v * (1 - (s * f)));
            byte t = Convert.ToByte(255.0 * v * (1 - (s * (1 - f))));

            switch (i)
            {
                case 0: return Color.FromRgb(Convert.ToByte(v * 255), t, p);
                case 1: return Color.FromRgb(q, Convert.ToByte(v * 255), p);
                case 2: return Color.FromRgb(p, Convert.ToByte(v * 255), t);
                case 3: return Color.FromRgb(p, q, Convert.ToByte(v * 255));
                case 4: return Color.FromRgb(t, p, Convert.ToByte(v * 255));
                default: return Color.FromRgb(Convert.ToByte(v * 255), p, q);
            }
        }

        public static Brush GetInverseColorBrush(Color color, Brush darkBrush, Brush lightBrush, bool? useAlpha = false)
        {
            if (useAlpha.HasValue && useAlpha.Value)
            {
                return ((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114) + ((255.0 - color.A) / 255.0 * 255.0) > 186) ? darkBrush : lightBrush;
            }
            else
            {
                return ((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114) > 186) ? darkBrush : lightBrush;
            }
        }

        private static DrawingBrush checkerBrush = null;

        public static DrawingBrush CheckerBrush
        {
            get
            {
                if (checkerBrush != null)
                {
                    return checkerBrush;
                }

                DrawingGroup drawingGroup = new DrawingGroup();
                GeometryDrawing whiteGeometry = new GeometryDrawing(Brushes.White, null, new RectangleGeometry(new Rect(0, 0, 100, 100)));

                GeometryGroup greyGeometryGroup = new GeometryGroup();
                greyGeometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
                greyGeometryGroup.Children.Add(new RectangleGeometry(new Rect(50, 50, 50, 50)));
                GeometryDrawing greyGeometry = new GeometryDrawing(new SolidColorBrush(Colors.LightGray), null, greyGeometryGroup);

                drawingGroup.Children.Add(whiteGeometry);
                drawingGroup.Children.Add(greyGeometry);

                checkerBrush = new DrawingBrush
                {
                    TileMode = TileMode.Tile,
                    Viewport = new Rect(0, 0, 10, 10),
                    ViewportUnits = BrushMappingMode.Absolute,
                    Drawing = drawingGroup,
                };
                return checkerBrush;
            }
        }
    }
}