// copy-pasta by Fredrik Hedblad
// https://stackoverflow.com/questions/3995853/how-to-display-a-different-value-for-dropdown-list-values-selected-item-in-a-wpf
namespace ColorPickerExtraDemo
{
    using System.Windows;
    using System.Windows.Controls;

    public class ComboBoxItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SelectedTemplate { get; set; }

        public DataTemplate DropDownTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ContentPresenter presenter = (ContentPresenter)container;
            return (presenter.TemplatedParent is ComboBox) ? SelectedTemplate : DropDownTemplate;
        }
    }
}