namespace ColorPickerExtraLib.Models
{
    public enum AdvancedPickerType : int
    {
        HSV = 0, HSL = 1
    }

    public enum ColorMode : int
    {
        Standard = 0,
        Advanced = 1
    }

    public enum EmptyElementMode : int
    {
        Off = 0,
        EmptySettings = 1,
        PortableSettings = 2
    }

    public enum ShowOnToggleButton : int
    {
        Off = 0,
        ConstantColor = 1,
        SelectedColor = 2,
        InverseColors = 3
    }

    public enum ShapeGeometry : int
    {
        BorderedBottomLeftToTopRight = 0,
        BorderedTopLeftToBottomRight = 1,
        BorderedHorizontalLine = 2,
        BorderedVerticalLine = 3,
        BorderedPerpendicularCross = 4,
        BorderedParallelCross = 5,
        Border = 6,
        BottomLeftToTopRight = 7,
        TopLeftToBottomRight = 8,
        HorizontalLine = 9,
        VerticalLine = 10,
        PerpendicularCross = 11,
        ParallelCross = 12
    }
}
