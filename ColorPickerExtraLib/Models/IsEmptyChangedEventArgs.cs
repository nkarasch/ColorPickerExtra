using System;

namespace ColorPickerExtraLib.Models
{
    public class IsEmptyChangedEventArgs : EventArgs
    {
        public IsEmptyChangedEventArgs(bool isEmpty)
        {
            IsEmpty = isEmpty;
        }

        public bool IsEmpty { get; }
    }
}
