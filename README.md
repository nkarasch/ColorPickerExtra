# ColorPickerExtra
A WPF color picker inspired by and using a combination of modified code from the [PixiEditor ColorPicker](https://github.com/PixiEditor/ColorPicker) and [Dirkster99's version of the classic](https://github.com/Dirkster99/ColorPickerLib) that can go as low as .NET 4.0 or .Net Core 3.1. It contains templates for both curved and rectangular styles. The main purpose was to provide a color picker that has an "empty" option.

### Public Controls

#### PortableColorPicker
Contains the ColorPicker, it's StandardColorPicker and AdvancedColorPicker children, and all of their pass through properties.The intention 
is to make the toggle button appearence change dynamically allowing its background, text, shape, and border to be set without styling complications.
Normal display properties begin with the word Portable and Empty is for when IsEmpty = true.

<details>
  <summary>Sample PortableColorPicker images</summary>
  Default</br>
  <img src="https://user-images.githubusercontent.com/1914281/204080970-ba4eae09-2690-46ac-b4b7-0f33be9a1809.png" name="Default"></br>
  Default Empty</br>
  <img src="https://user-images.githubusercontent.com/1914281/204080973-637d0225-22df-4287-9a22-0c513d198422.png" name="Default Empty"></br>
  Included Dark Theme</br>
  <img src="https://user-images.githubusercontent.com/1914281/204080968-8f378253-ea73-49aa-a39c-f28ba7be1d3a.png" name="Default Dark"></br>
  Custom</br>
  <img src="https://user-images.githubusercontent.com/1914281/204080967-fbf11ea4-8c76-495a-a472-8cb43ff1abde.png" name="Custom"></br>
  Custom</br>
  <img src="https://user-images.githubusercontent.com/1914281/204080969-53195e71-9d80-48e9-8e18-618017393967.png" name="Custom"></br>
</details>

<details>
  <summary>Base dependency properties</summary>
  
| DependencyProperty         | Type      | Description                                                          |
|----------------------------|-----------|----------------------------------------------------------------------|
| PortableShowDropdownButton | bool      | Controls visibility for the icon area in toggle button               |
| PortableButtonBaseStyle    | Style     | Sets the style for the button containing the dynamic area            |
| PortableInsideMargin       | Thickness | Margin for spacing between the toggle button border and dynamic area |
  </summary>
</details>


<details>
  <summary> Portable Toggle Button Styling (when not empty)</summary>
The background, border, shape, and text are all optional and set by the enum **ShowOnToggleButton**.</br>
**Off** - Hide</br>
**SelectedColor** - Users main selected color</br>
**ConstantColor** - Brush set by [element type]ConstantBrush</br>
**Inverse** - Use opposing color to make other items more visible

| DependencyProperty              | Type               | Description                                                                   |
|---------------------------------|--------------------|-------------------------------------------------------------------------------|
| PortableBackgroundMode          | ShowOnToggleButton | Dynamic area background options Off, SelectedColor, ConstantColor, or Inverse |
| PortableBackgroundConstantBrush | Brush              | Used when PortableBackgroundMode is set to ConstantColor                      |
| PortableBorderMode                   | enum ShowOnToggleButton | Dynamic area border options Off, SelectedColor, ConstantColor, or Inverse |
| PortableBorderConstantBrush          | Brush                   | Used when PortableBorderMode is set to ConstantColor                      |
| PortableBorderConstantHighlightBrush | Brush                   | For highlighting when the mouse is over or popup is open                  |
| PortableBorderModeThickness          | Thickness               | Border thickness when not set to Off                                      |
| PortableShapeMode                | enum ShowOnToggleButton | Dynamic area shape options Off, SelectedColor, ConstantColor, or Inverse     |
| PortableShapeGeometry            | enum ShapeGeometry      | Selection for pre-defined shape paths, all are setup between {0,0} and {1,1} |
| PortableShapeCustomGeometry      | Geometry                | Set custom geometry, uses PortableShapeGeometry selection if not set         |
| PortableShapeConstantColorBrush  | Brush                   | Shape brush when using ConstantColor                                         |
| PortableShapeStretch             | Stretch                 | Stretch.Uniform / Stretch.Fill                                               |
| PortableShapeMargin              | Thickness               | Margin between shape path and border                                         |
| PortableShapeHorizontalAlignment | HorizontalAlignment     | Useful when EmptyShapeStretch is set to Stretch.Uniform                      |
| PortableShapeVerticalAlignment   | VerticalAlignment       | Useful when EmptyShapeStretch is set to Stretch.Uniform                      |
| PortableShapeLineWidth           | double                  | Width of pathed geometry lines                                               |
| PortableFontMode                | enum ShowOnToggleButton  | Dynamic area font options Off, SelectedColor, ConstantColor, or Inverse                    |
| PortableFontConstantBrush       | Brush                    | Used when PortableFontMode is set to ConstantColor                                         |
| PortableFontText                | string                   | Used when PortableFontMode is not set to Off                                               |
| PortableFontUseHexText          | bool                     | Display selected color as hexidecimal value instead of 'PortableFontText'                  |
| PortableFontFamily              | FontFamily               | FontFamily for PortableFontMode on or IsEmpty and EmptyFontFamily is not set               |
| PortableFontSize                | double                   | FontSize for PortableFontMode on or IsEmpty and EmptyFontFamily is not set                 |
| PortableFontStyle               | FontStyle                | FontStyle for PortableFontMode on or IsEmpty and EmptyFontFamily is not set                |
| PortableFontWeight              | FontWeight               | FontWeight for PortableFontMode on or IsEmpty and EmptyFontFamily is not set               |
| PortableFontMargin              | Thickness                | Margin for PortableFontMode on or IsEmpty and EmptyFontFamily is not set                   |
| PortableFontTextDecorations     | TextDecorationCollection | TextDecorationCollection for PortableFontMode on or IsEmpty and EmptyFontFamily is not set |
| PortableFontHorizontalAlignment | HorizontalAlignment      | HorizontalAlignment for PortableFontMode on or IsEmpty and EmptyFontFamily is not set      |
| PortableFontVerticalAlignment   | VerticalAlignment        | VerticalAlignment for PortableFontMode on or IsEmpty and EmptyFontFamily is not set        |
| PortableFontViewboxStretch      | Stretch                  | Stretch for PortableFontMode on or IsEmpty and EmptyFontFamily is not set                  |

</details>

<details>
  <summary>Empty Styling (is empty)</summary>
Similar to the above settings for when IsEmpty = true background, border, shape, and text are all optional and set by the enum **EmptyElementMode**.</br>
**Off** - Hide</br>
**PortableSettings** - Use the same settings set by 'Portable' above</br>
**EmptySettings** - Use the settings specific to when empty set below with the exception of text.</br>

| DependencyProperty        | Type            | Description                                                                                   |
|---------------------------|-----------------|-----------------------------------------------------------------------------------------------|
| EmptyBackgroundBrush      | Brush           | Constant empty background color                                                               |
| EmptyBorderMode           | EmptyBorderMode | Dynamic area shape options Off, PortableSettings, or EmptySettings                            |
| EmptyBorderBrush          | Brush           | Border brush for EmptyBorderMode.EmptySettings                                                |
| EmptyBorderHighlightBrush | Brush           | Border brush for mouse over/popup open open highlight brush for EmptyBorderMode.EmptySettings |
| EmptyBorderThickness      | Thickness       | Border thickness when set to                                                                                              |

| DependencyProperty            | Type                | Description                                                                    |
|-------------------------------|-----------------------|------------------------------------------------------------------------------|
| EmptyShapeMode                | enum EmptyElementMode | Dynamic area shape options Off, PortableSettings, or EmptySettings           |
| EmptyShapeGeometry            | enum ShapeGeometry    | Selection for pre-defined shape paths, all are setup between {0,0} and {1,1} |
| EmptyShapeCustomGeometry      | Geometry              | Set custom geometry, uses EmptyShapeGeometry selection if not set            |
| EmptyShapeColorBrush          | Brush                 | Shape path brush                                                             |
| EmptyShapeStretch             | Stretch               | Stretch.Uniform / Stretch.Fill                                               |
| EmptyShapeMargin              | Thickness             | Margin between shape path and border                                         |
| EmptyShapeHorizontalAlignment | HorizontalAlignment   | Useful when EmptyShapeStretch is set to Stretch.Uniform                      |
| EmptyShapeVerticalAlignment   | VerticalAlignment     | Useful when EmptyShapeStretch is set to Stretch.Uniform                      |
| EmptyShapeLineWidth           | double                | Width of pathed geometry lines                                               |

| DependencyProperty           | Type                     | Description                                                                      |
|------------------------------|--------------------------|----------------------------------------------------------------------------------|
| EmptyFontMode                | enum EmptyElementMode    | Hide, use set properties below, or PortableFont settings                         |
| EmptyFontText                | string                   | Text to display on ToggleButton when empty, default to Portable settings if null |
| EmptyFontBrush               | Brush                    | Text coloring, sets to Portable settings if null                                 |
| EmptyFontFamily              | FontFamily               | Defaults to Portable settings if using EmptySettings and null                    |
| EmptyFontSize                | double?                  | Nullable, use Portable value if set to EmptySettings if not set                  |
| EmptyFontStyle               | FontStyle?               | Nullable, use Portable value if set to EmptySettings if not set                  |
| EmptyFontWeight              | FontWeight?              | Nullable, use Portable value if set to EmptySettings if not set                  |
| EmptyFontMargin              | Thickness?               | Nullable, use Portable value if set to EmptySettings if not set                  |
| EmptyFontTextDecorations     | TextDecorationCollection | Defaults to Portable settings if using EmptySettings and null                    |
| EmptyFontHorizontalAlignment | HorizontalAlignment?     | Nullable, use Portable value if set to EmptySettings if not set                  |
| EmptyFontVerticalAlignment   | VerticalAlignment?       | Nullable, use Portable value if set to EmptySettings if not set                  |
| EmptyFontViewboxStretch      | Stretch?                 | Nullable, use Portable value if set to EmptySettings if not set                  |
  
</details>

 #### ColorPicker
Contains both StandardColorPicker and AdvancedColorPicker with the ability to swap between them. It contains all of the dependency properties of StandardColorPicker and AdvancedColorPicker to pass through.

<details>
  <summary>Sample ColorPicker images</summary>  
  
| Default    | Default Dark   |
|------------|----------------|
| <img src="https://user-images.githubusercontent.com/1914281/204080964-c2ae6dd8-ea76-4042-9bdf-038d66ee6433.png" name="Default"> | <img src="https://user-images.githubusercontent.com/1914281/204080958-a02e8c0d-a9d9-4536-8a82-9374d660550e.png" name="Default Dark"> |
  
</details>


<details>
  <summary>Dependency Properties</summary>
  
| DependencyProperty       | Type           | Description                                                               |
|--------------------------|----------------|---------------------------------------------------------------------------|
| BaseStandardButtonText | string         | Text for button displayed when in 'Advanced' to switch to 'Standard'      |
| BaseAdvancedButtonText | string         | Text for button displayed when in 'Standard' to switch to 'Advanced'      |
| BaseAllowChangeModes   | bool           | Allows user to switch between 'Standard' and 'Advanced' modes with button |
| BaseColorMode          | ColorMode      | Enum for current picker type mode whether 'Standard' or 'Advanced'        |
| BasePickerWidth        | double         | Width set for both 'Standard' and 'Advanced' pickers for size matching    |
| BasePickerHeight       | double         | Height set for both 'Standard' and 'Advanced' pickers for size matching   |

</details>

  #### StandardColorPicker
  Generates a palette of colors for a single click on a grid. The "available" grid is either generated by columns and rows
set by StandardColumnCount and StandardAvailableColorRows with the first row always being a black to white range unless. 
<details>
  <summary>Sample StandardColorPicker images</summary>

| Default    | Default Dark    |
|-------------|----------------|
| <img src="https://user-images.githubusercontent.com/1914281/204080980-57388973-ec2d-4c01-9452-a2e2121e4d70.png" /> | <img src="https://user-images.githubusercontent.com/1914281/204080981-8c313564-a812-4a3a-b7e1-ca05beaa93a4.png" /> |
| __Default Dark__    | __Dark Custom__ |
| <img src="https://user-images.githubusercontent.com/1914281/204080982-a91c3297-ebe0-4d93-bef9-f7ba56557bc6.png" name="Default">  | <img src="https://user-images.githubusercontent.com/1914281/204080958-a02e8c0d-a9d9-4536-8a82-9374d660550e.png" /> |
  </details>
  <details>
  <summary>Dependency Properties</summary>
  
| DependencyProperty              | Type            | Description                                                      |
|---------------------------------|-----------------|------------------------------------------------------------------|
| StandardItemSquareSize          | double          | Width and height of items in the selection grid                  |
| StandardItemCornerRadius        | double          | Corner radius for these items                                    |
| StandardItemMargin              | double          | Space between outer borders                                      |
| StandardItemBorderThickness     | Thickness       | Thickness of both inner and outer borders                        |
| StandardItemBorderBrush         | SolidColorBrush | Default inner border brush                                       |
| StandardItemInnerHighlightBrush | SolidColorBrush | Mouse over or selected inner border brush                        |
| StandardItemOuterHighlightBrush | SolidColorBrush | Mouse over or selected outer border brush                        |
| StandardColumnCount             | int             | Number of grid columns for both recent and available color grids |
| StandardShowAvailableColors     | bool            | Show/hide available colors grid                                  |
| StandardAvailableColorArray     | Color[]         | Array for overriding the generated colors                        |
| StandardAvailableColorsHeader   | string          | Header text for available colors grid                            |
| StandardAvailableColorRows      | int             | Rows for generated available color grid, unused with custom array|
| StandardShowRecentColors        | bool            | Show recent colors grid                                          |
| StandardRecentColorsHeader      | string          | Header text for available colors grid                            |
| StandardRecentColorRows         | int             | Rows for recent colors grid                                      |
   
</details>

#### AdvancedColorPicker
Allows the user to define their selected color more accurately than from a grid. It has the options to swap between RGB, HSV, HSL sliders in the bottom. 
The square HSV/HSL in the center top region remains the same in both 'UseRectangularStyle' modes but the cirular hue slider is replaced by a vertical linear
hue slider in the top right when UseRectangularStyle is active.

<details>
  <summary>Sample AdvancedColorPicker images</summary>
  
| Default    | Default Dark    |
|-------------|----------------|
| <img src="https://user-images.githubusercontent.com/1914281/204080943-36cf90cd-15dd-45cb-802a-18634439b0f1.png" /> | <img src="https://user-images.githubusercontent.com/1914281/204080941-441982ec-22df-4a0c-81c4-2e8a1262033e.png" /> |
| __Default Dark__    | __Dark Custom__ |
| <img src="https://user-images.githubusercontent.com/1914281/204080934-6e20aa48-9d32-40b6-af8a-d6c10d035084.png" name="Default">  | <img src="https://user-images.githubusercontent.com/1914281/204080958-a02e8c0d-a9d9-4536-8a82-9374d660550e.png" /> |
</details>

<details>
<summary>Dependency Properties</summary>
  
| DependencyProperty       | Type               | Description                                                                        |
|--------------------------|--------------------|------------------------------------------------------------------------------------|
| AdvancedPickerType       | AdvancedPickerType | enum Option between HSV and HSL layout for square hue slider                       |
| AdvancedInnerBorderBrush | Brush              | For border of circular/vertical hue sliders, square slider, and color swap items   |
| AdvancedInnerBorderWidth | double             | Border width of circular/vertical hue sliders, square slider, and color swap items |
  
</details>

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

| DependencyProperty  | Type       | Description                                                  |
|---------------------|------------|--------------------------------------------------------------|
| SelectedColor       | Color      | Selected color as System.Windows.Media.Color                 |
| SecondaryColor      | Color      | Alternative color set for swapping in 'Advanced'             |
| ColorState          | ColorState | Selected color separated into R, G, B, A, H, S, V, H, S, L   |
| UseRectangularStyle | bool       | Use alternative non-curved templates                         |
| UsingAlphaChannel   | bool       | Allow semi-tranparency                                       |
| IsEmpty             | bool       | Separate from SelectedColor, inspired by 'No Fill' in Excel  |
| EnableEmptyMode     | bool       | Adds empty toggle button for user                            |
| EmptyButtonText     | string     | Text for empty button                                        |





