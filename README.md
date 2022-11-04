# ColorPickerExtra
A WPF color picker inspired by and using a combination of modified code from the [PixiEditor ColorPicker](https://github.com/PixiEditor/ColorPicker) and [Dirkster99's version of the classic](https://github.com/Dirkster99/ColorPickerLib) that can go as low as .NET 4.0 or .Net Core 3.1. It contains templates for both curved and rectangular styles. The main purpose was to provide a color picker that has an "empty" option.

### Public Controls
  
  
  **PortableColorPicker**
  
  
  **ColorPicker**
  
  
  **StandardColorPicker**
  
  
  **AdvancedColorPicker**

### Control Heirarchy
* **PortableColorPicker**
  * **ColorPicker**
    * **StandardColorPicker**
      * AvailableColorsGrid
      * RecentColorsGrid
    * **AdvancedColorPicker**
      * SquarePicker
        * HueSlider 
        * SquareSlider
        * VerticalHueSlider
      * ColorDisplay
      * HexColorTextBox
      * ColorSliders
        * HSVColorSlider
        * HSLColorSlider
        * RGBColorSlider

| DependencyProperty    | Type       | Description                                                                           |
|-----------------------|------------|---------------------------------------------------------------------------------------|
| *SelectedColor*       | Color      | Selected color as System.Windows.Media.Color                                          |
| *ColorState*          | ColorState | Selected color separated into R, G, B, A, H, S, V, H, S, L                            |
| *UseRectangularStyle* | bool       | Use alternative non-curved templates                                                  |
| *UsingAlphaChannel*   | bool       | Allow non-100% alpha, mostly noticable with an additional slider and hexidecimal text |
| *IsEmpty*             | bool       | Separate from SelectedColor, inspired by 'No Fill' in Excel                           |
| *EnableEmptyMode*     | bool       | Adds empty toggle button for user                                                     |
| *EmptyButtonText*     | string     | Text for empty button                                                                 |

| DependencyProperty                      | Type            | Description                                                      |
|-----------------------------------------|-----------------|------------------------------------------------------------------|
| *StandardItemSquareSize*                | double          | Width and height of items in the selection grid                  |
| *StandardItemCornerRadius*              | double          | Corner radius for these items                                    |
| *StandardItemMargin*                    | double          | Space between outer borders                                      |
| *StandardItemBorderThickness*           | Thickness       | Thickness of both inner and outer borders                        |
| *StandardItemBorderBrush*               | SolidColorBrush | Default inner border brush                                       |
| *StandardItemBorderInnerHighlightBrush* | SolidColorBrush | Mouse over or selected inner border brush                        |
| *StandardItemBorderOuterHighlightBrush* | SolidColorBrush | Mouse over or selected outer border brush                        |
| *StandardListHeaderStyle*               | Style           | Option to add separate style for grid headers                    |
| *StandardColumnCount*                   | int             | Number of grid columns for both recent and available color grids |
| *StandardShowAvailableColors*           | bool            | Show/hide available colors grid                                  |
| *StandardAvailableColorsHeader*         | string          | Header text for available colors grid                            |
| *StandardAvailableColorRowCount*        | int             | Rows for generated available color grid                          |
| *StandardRecentColorRowCount*           | int             | Rows for recent colors grid                                      |
| *StandardRecentColorsHeader*            | string          | Header text for available colors grid                            |
| *StandardShowRecentColors*              | bool            | Show recent colors grid                                          |

| DependencyProperty         | Type                    | Description                                                                            |
|----------------------------|-------------------------|----------------------------------------------------------------------------------------|
| *AdvancedPickerType*       | AdvancedPickerType | enum Option between HSV and HSL layout for square hue slider |
| *AdvancedInnerBorderBrush* | Brush | For border of circular/vertical hue sliders, square slider, and color swap items |
| *AdvancedInnerBorderWidth* | double | Border width of circular/vertical hue sliders, square slider, and color swap items |

| DependencyProperty       | Type           | Description                                                               |
|--------------------------|----------------|---------------------------------------------------------------------------|
| *BaseStandardButtonText* | string         | Text for button displayed when in 'Advanced' to switch to 'Standard'      |
| *BaseAdvancedButtonText* | string         | Text for button displayed when in 'Standard' to switch to 'Advanced'      |
| *BaseAllowChangeModes*   | bool           | Allows user to switch between 'Standard' and 'Advanced' modes with button |
| *BaseColorMode*          | ColorMode      | Enum for current picker type mode whether 'Standard' or 'Advanced'        |
| *BasePickerWidth*        | double         | Width set for both 'Standard' and 'Advanced' pickers for size matching    |
| *BasePickerHeight*       | double         | Height set for both 'Standard' and 'Advanced' pickers for size matching   |


| DependencyProperty           | Type      | Description                                                          |
|------------------------------|-----------|----------------------------------------------------------------------|
| *PortableShowDropdownButton* | bool      | Controls visibility for the icon area in toggle button               |
| *PortableButtonBaseStyle*    | Style     | Sets the style for the button containing the dynamic area            |
| *PortableInsideMargin*       | Thickness | Margin for spacing between the toggle button border and dynamic area |


| DependencyProperty                | Type               | Description                                                                   |
|-----------------------------------|--------------------|-------------------------------------------------------------------------------|
| *PortableBackgroundMode*          | ShowOnToggleButton | Dynamic area background options Off, SelectedColor, ConstantColor, or Inverse |
| *PortableConstantBackgroundBrush* | Brush              | Used when PortableBackgroundMode is set to ConstantColor                      |

| DependencyProperty                     | Type                    | Description                                                               |
|----------------------------------------|-------------------------|---------------------------------------------------------------------------|
| *PortableBorderMode*                   | enum ShowOnToggleButton | Dynamic area border options Off, SelectedColor, ConstantColor, or Inverse |
| *PortableConstantBorderBrush*          | Brush                   | Used when PortableBorderMode is set to ConstantColor                      |
| *PortableConstantBorderHighlightBrush* | Brush                   | For highlighting when the mouse is over or popup is open                  |
| *PortableBorderModeThickness*          | Thickness               | Border thickness when not set to Off                                      |

| DependencyProperty                | Type                     | Description                                                                                |
|-----------------------------------|--------------------------|--------------------------------------------------------------------------------------------|
| *PortableFontMode*                | enum ShowOnToggleButton  | Dynamic area font options Off, SelectedColor, ConstantColor, or Inverse                    |
| *PortableConstantFontBrush*       | Brush                    | Used when PortableFontMode is set to ConstantColor                                         |
| *PortableFontText*                | string                   | Used when PortableFontMode is not set to Off                                               |
| *PortableFontUseHexText*          | bool                     | Display selected color as hexidecimal value instead of 'PortableFontText'                  |
| *PortableFontFamily*              | FontFamily               | FontFamily for PortableFontMode on or IsEmpty and EmptyFontFamily is not set               |
| *PortableFontSize*                | double                   | FontSize for PortableFontMode on or IsEmpty and EmptyFontFamily is not set                 |
| *PortableFontStyle*               | FontStyle                | FontStyle for PortableFontMode on or IsEmpty and EmptyFontFamily is not set                |
| *PortableFontWeight*              | FontWeight               | FontWeight for PortableFontMode on or IsEmpty and EmptyFontFamily is not set               |
| *PortableFontMargin*              | Thickness                | Margin for PortableFontMode on or IsEmpty and EmptyFontFamily is not set                   |
| *PortableFontTextDecorations*     | TextDecorationCollection | TextDecorationCollection for PortableFontMode on or IsEmpty and EmptyFontFamily is not set |
| *PortableFontHorizontalAlignment* | HorizontalAlignment      | HorizontalAlignment for PortableFontMode on or IsEmpty and EmptyFontFamily is not set      |
| *PortableFontVerticalAlignment*   | VerticalAlignment        | VerticalAlignment for PortableFontMode on or IsEmpty and EmptyFontFamily is not set        |
| *PortableFontViewboxStretch*      | Stretch                  | Stretch for PortableFontMode on or IsEmpty and EmptyFontFamily is not set                  |

| DependencyProperty   | Type                  | Description                                                  |
|----------------------|-----------------------|--------------------------------------------------------------|
| EmptyDisplayMode     | enum EmptyDisplayMode | Options for displaying a shape, text, or both when "IsEmpty" |
| EmptyBackgroundBrush | Brush                 |                                                              |

| DependencyProperty                                                                       | Type            | Description                                                                                     |
|------------------------------------------------------------------------------------------|-----------------|-------------------------------------------------------------------------------------------------|
| *EmptyBackgroundBrush*                                                                     | Brush           |                                                                                                 |
| *EmptyBorderMode*                                                                          | EmptyBorderMode | Off: No border, PortableSettings: Keep PortableBorderMode settings, EmptySetting: Use EmptyBorderBrush, EmptyBorderHighlightBrush, and EmptyBorderThickness |
| *EmptyBorderBrush*                                                                        | Brush           | Border brush for EmptyBorderMode.EmptySettings                                                  |
| *EmptyBorderHighlightBrush*                                                                | Brush           | Border brush for mouse over/popup window open highlight brush for EmptyBorderMode.EmptySettings |
| *EmptyBorderThickness*                                                                     | Thickness       |

| DependencyProperty                                                        | Type                | Description                                                                  |
|---------------------------------------------------------------------------|---------------------|------------------------------------------------------------------------------|
| *EmptyShapeGeometry*                                                        | enum ShapeGeometry  | Selection for pre-defined shape paths, all are setup between {0,0} and {1,1} |
| *EmptyShapeColorBrush*                                                      | Brush               | Shape path brush                                                             |
| *EmptyShapeStretch*                                                         | Stretch             | "Stretch.Fill: Covers entire area                                            |
| Stretch.Uniform: Use the rectangular 1:1 ratio set by EmptyShapeGeometry" |
| *EmptyShapeMargin*                                                          | Thickness           | Margin between shape path and border                                         |
| *EmptyShapeHorizontalAlignment*                                             | HorizontalAlignment | Useful when EmptyShapeStretch is set to Stretch.Uniform                      |
| *EmptyShapeLineWidth*                                                       | double              | Width of pathed lines                                                        |

| DependencyProperty             | Type                     | Description |
|--------------------------------|--------------------------|-------------|
| *EmptyFontColorBrush*          | Brush                    |             |
| *EmptyFontFamily*              | FontFamily               |             |
| *EmptyFontSize*                | double                   |             |
| *EmptyFontStyle*               | FontStyle                |             |
| *EmptyFontWeight*              | FontWeight               |             |
| *EmptyFontHorizontalAlignment* | HorizontalAlignment      |             |
| *EmptyFontMargin*              | Thickness                |             |
| *EmptyText*                    | string                   |             |
| *EmptyTextDecorations*         | TextDecorationCollection |             |
| *EmptyUseHexText*              | bool                     |             |
| *EmptyVerticalAlignment*       | VerticalAlignment        |             |
| *EmptyViewboxStretch*          | Stretch                  |

