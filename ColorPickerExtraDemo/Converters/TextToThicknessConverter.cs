using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace ColorPickerExtraDemo.Converters
{
    public class TextToThicknessConverter : IMultiValueConverter
    {
        #region IValueConverter Members
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[1] == null) // supports nullable Thickness
            {
                return Binding.DoNothing;
            }

            Thickness currentThickness = (Thickness)values[1];

            // leaves empty instead of adding a 0 when user empties
            if (!(values[0] is string currentString) || currentString.Length != 0 ||
                (currentThickness.Left == 0 &&
                currentThickness.Left == currentThickness.Top &&
                currentThickness.Top == currentThickness.Right &&
                currentThickness.Right == currentThickness.Bottom))
            {
                return Binding.DoNothing;
            }

            // fills textbox on startup
            if (currentThickness.Left == currentThickness.Top &&
                currentThickness.Top == currentThickness.Right &&
                currentThickness.Right == currentThickness.Bottom)
            {
                return currentThickness.Left.ToString();
            }

            if (currentThickness.Left == currentThickness.Right &&
                currentThickness.Top == currentThickness.Bottom)
            {
                return currentThickness.Left + "," + currentThickness.Top;
            }

            return currentThickness.Left + "," + currentThickness.Top + "," + currentThickness.Right + "," + currentThickness.Bottom;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string currentString = value as string;
            return new object[] { Binding.DoNothing, (currentString == null || currentString.Length == 0) ? new Thickness(0) : StringToThickness(currentString) };
        }

        #endregion IValueConverter Members

        private static Thickness StringToThickness(string input)
        {
            List<double> outputList = StringToDoubleOutput(input);

            if (outputList.Count < 1)
            {
                return new Thickness(0);
            }
            else if (outputList.Count < 2)
            {
                return new Thickness(outputList[0]);
            }
            else if (outputList.Count < 4)
            {
                return new Thickness(outputList[0], outputList[1], outputList[0], outputList[1]);
            }
            else
            {
                return new Thickness(outputList[0], outputList[1], outputList[2], outputList[3]);
            }
        }

        private static List<double> StringToDoubleOutput(string input)
        {
            List<double> outputList = new List<double>();

            if (input == null || input.Length == 0)
            {
                return outputList;
            }

            char[] delimiters = new[] { ',', ' ' };
            string[] splitArray = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);


            foreach (string testIsNumber in splitArray)
            {
                if (double.TryParse(testIsNumber, out double testOutput))
                {
                    outputList.Add(testOutput);
                }
            }
            return outputList;
        }
    }
}