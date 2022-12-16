namespace ColorPickerExtraDemo
{
    using System;
    using System.Windows;
    using static ColorPickerExtraDemo.MainWindow;

    public partial class App : Application
    {
        private const string DefaultBase = "pack://application:,,,/Themes/DefaultTheme.xaml";
        private const string DarkBase = "pack://application:,,,/Themes/ColorfulDarkTheme.xaml";

        private const string LightBrushes = "pack://application:,,,/ColorPickerExtraLib;component/Themes/LightBrushes.xaml";
        private const string DarkBrushes = "pack://application:,,,/ColorPickerExtraLib;component/Themes/DarkBrushes.xaml";
        private const string Custom = "pack://application:,,,/ColorPickerExtraLib;component/Themes/CustomTheme.xaml";

        private const string DarkNumupDown = "pack://application:,,,/NumericUpDownLib;component/Themes/DarkBrushs.xaml";

        public ResourceDictionary ThemeDictionary => Resources.MergedDictionaries[0];

        public void ChangeTheme(Theme changeToTheme)
        {
            ThemeDictionary.MergedDictionaries.Clear();

            switch (changeToTheme)
            {
                case Theme.Default:
                default:
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(DefaultBase) });
                    break;
                case Theme.Dark:
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(DarkNumupDown) });
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(DarkBrushes) });
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(Custom) });
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(DarkBase) });
                    break;
                case Theme.Light:
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(DarkNumupDown) });
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(LightBrushes) });
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(Custom) });
                    ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(DefaultBase) });
                    break;
            }
        }
    }
}
