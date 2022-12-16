namespace ColorPickerExtraLib.Models
{
    using System;
    using System.ComponentModel;

    public class NotifyableObject : INotifyPropertyChanged
    {
        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string property)
        {
            if (property != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
