using ColorPickerExtraLib.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ColorPickerExtraLib.Controls.UserControls
{
    internal partial class SquareSlider : UserControl, INotifyPropertyChanged
    {
        public SquareSlider()
        {
            GradientBitmap = new WriteableBitmap(32, 32, 96, 96, PixelFormats.Rgb24, null);
            InitializeComponent();
            RecalculateGradient();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty HueProperty =
            DependencyProperty.Register(nameof(Hue), typeof(double), typeof(SquareSlider),
                new PropertyMetadata(0.0, OnHueChanged));

        public static readonly DependencyProperty HeadXProperty =
            DependencyProperty.Register(nameof(HeadX), typeof(double), typeof(SquareSlider),
                new PropertyMetadata(0.0));

        public static readonly DependencyProperty HeadYProperty =
            DependencyProperty.Register(nameof(HeadY), typeof(double), typeof(SquareSlider),
                new PropertyMetadata(0.0));

        public static readonly DependencyProperty AdvancedPickerTypeProperty =
            DependencyProperty.Register(nameof(AdvancedPickerType), typeof(AdvancedPickerType), typeof(SquareSlider),
                new PropertyMetadata(AdvancedPickerType.HSV, OnColorSpaceChanged));

        public static readonly DependencyProperty OutsideBorderThicknessProperty =
            DependencyProperty.Register(nameof(OutsideBorderThickness), typeof(double), typeof(SquareSlider),
                new PropertyMetadata(0.0));

        public double Hue
        {
            get => (double)GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }

        public double HeadX
        {
            get => (double)GetValue(HeadXProperty);
            set => SetValue(HeadXProperty, value);
        }

        public double HeadY
        {
            get => (double)GetValue(HeadYProperty);
            set => SetValue(HeadYProperty, value);
        }

        public AdvancedPickerType AdvancedPickerType
        {
            get => (AdvancedPickerType)GetValue(AdvancedPickerTypeProperty);
            set => SetValue(AdvancedPickerTypeProperty, value);
        }

        public double OutsideBorderThickness
        {
            get => (double)GetValue(HeadYProperty);
            set => SetValue(HeadYProperty, value);
        }

        private double rangeX;
        public double RangeX
        {
            get => rangeX;
            set
            {
                rangeX = value;
                RaisePropertyChanged(nameof(RangeX));
            }
        }

        private double rangeY;
        public double RangeY
        {
            get => rangeY;
            set
            {
                rangeY = value;
                RaisePropertyChanged(nameof(RangeY));
            }
        }

        private WriteableBitmap gradientBitmap;
        public WriteableBitmap GradientBitmap
        {
            get => gradientBitmap;
            set
            {
                gradientBitmap = value;
                RaisePropertyChanged(nameof(GradientBitmap));
            }
        }

        private Func<double, double, double, Tuple<double, double, double>> colorSpaceConversionMethod = ColorSpaceHelper.HsvToRgb;

        private void RecalculateGradient()
        {
            int w = GradientBitmap.PixelWidth;
            int h = GradientBitmap.PixelHeight;
            double hue = Hue;
            byte[] pixels = new byte[w * h * 3];

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    Tuple<double, double, double> rgbtuple = colorSpaceConversionMethod(hue, i / (double)(w - 1), (h - 1 - j) / (double)(h - 1));
                    double r = rgbtuple.Item1, g = rgbtuple.Item2, b = rgbtuple.Item3;
                    int pos = ((j * h) + i) * 3;
                    pixels[pos] = (byte)(r * 255);
                    pixels[pos + 1] = (byte)(g * 255);
                    pixels[pos + 2] = (byte)(b * 255);
                }
            }

            GradientBitmap.WritePixels(new Int32Rect(0, 0, w, h), pixels, w * 3, 0);
        }

        private static void OnColorSpaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            SquareSlider sender = (SquareSlider)d;

            if ((AdvancedPickerType)args.NewValue == AdvancedPickerType.HSV)
            {
                sender.colorSpaceConversionMethod = ColorSpaceHelper.HsvToRgb;
            }
            else
            {
                sender.colorSpaceConversionMethod = ColorSpaceHelper.HslToRgb;
            }

            sender.RecalculateGradient();
        }

        private static void OnHueChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue == args.NewValue)
            {
                return;
            }

            ((SquareSlider)d).RecalculateGradient();
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ((UIElement)sender).CaptureMouse();
            UpdatePos(e.GetPosition(this));
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            if (grid.IsMouseCaptured)
            {
                UpdatePos(e.GetPosition(this));
            }
        }

        private void UpdatePos(Point pos)
        {
            HeadX = MathHelper.Clamp(pos.X / ActualWidth, 0, 1) * RangeX;
            HeadY = (1 - MathHelper.Clamp(pos.Y / ActualHeight, 0, 1)) * RangeY;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            ((UIElement)sender).ReleaseMouseCapture();
        }

        private void RaisePropertyChanged(string property)
        {
            if (property != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
