namespace ColorPickerExtraDemo
{
    using System.Windows;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public enum Theme
        {
            Default,
            Dark,
            Light
        }

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
    }
}
