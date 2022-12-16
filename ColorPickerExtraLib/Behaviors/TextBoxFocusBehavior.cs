namespace ColorPickerExtraLib.Behaviors
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class TextBoxFocusBehavior
    {
        private const string IsSliderTextBox = "IsSliderTextBox";

        public static readonly DependencyProperty IsSliderTextBoxProperty =
            DependencyProperty.RegisterAttached(IsSliderTextBox, typeof(bool?), typeof(TextBoxFocusBehavior),
                new PropertyMetadata(null, OnAttached));

        public static void SetIsSliderTextBox(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSliderTextBoxProperty, value);
        }

        public static bool GetIsSliderTextBox(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSliderTextBoxProperty);
        }

        private static void OnAttached(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            OnBehaviorDisabled(dependencyObject);
            TextBox textBox = dependencyObject as TextBox;
            textBox.GotKeyboardFocus += AssociatedObjectGotKeyboardFocus;
            textBox.GotMouseCapture += AssociatedObjectGotMouseCapture;
            textBox.LostFocus += AssociatedObject_LostFocus;
            textBox.PreviewMouseLeftButtonDown += AssociatedObjectPreviewMouseLeftButtonDown;
            textBox.KeyUp += AssociatedObject_KeyUp;
        }

        private static void OnBehaviorDisabled(DependencyObject dependencyObject)
        {
            TextBox textBox = dependencyObject as TextBox;
            textBox.GotKeyboardFocus -= AssociatedObjectGotKeyboardFocus;
            textBox.GotMouseCapture -= AssociatedObjectGotMouseCapture;
            textBox.LostFocus -= AssociatedObject_LostFocus;
            textBox.PreviewMouseLeftButtonDown -= AssociatedObjectPreviewMouseLeftButtonDown;
            textBox.KeyUp -= AssociatedObject_KeyUp;
        }

        private static void AssociatedObject_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }

            DependencyObject scope = FocusManager.GetFocusScope(sender as TextBox);
            FrameworkElement parent = (FrameworkElement)(sender as TextBox).Parent;

            while (parent != null && parent is IInputElement element && !element.Focusable)
            {
                parent = (FrameworkElement)parent.Parent;
            }

            FocusManager.SetFocusedElement(scope, parent);
            Keyboard.ClearFocus();
        }

        private static void AssociatedObjectGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (GetIsSliderTextBox(sender as DependencyObject) || e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                (sender as TextBox).SelectAll();
            }
        }

        private static void AssociatedObjectGotMouseCapture(object sender, MouseEventArgs e)
        {
            if (GetIsSliderTextBox(sender as DependencyObject))
            {
                (sender as TextBox).SelectAll();
            }
        }

        private static void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Select(0, 0);
            }
        }

        private static void AssociatedObjectPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!GetIsSliderTextBox(sender as DependencyObject))
            {
                return;
            }

            if (sender is TextBox textBox && !textBox.IsKeyboardFocusWithin)
            {
                textBox.Focus();
                e.Handled = true;
            }
        }
    }
}
