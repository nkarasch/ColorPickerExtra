using ColorPickerExtraLib.Controls.ColorGrids;
using ColorPickerExtraLib.Models;

/* Unmerged change from project 'ColorPickerExtraLib (netcoreapp3.1)'
Before:
using System.Windows.Media;
using ColorPickerExtraLib.Controls.ColorGrids;
using ColorPickerExtraLib.Models;
After:
using System;
using ColorPickerExtraLib.Controls.Windows;
using System.Windows.Models;
*/
using System.Windows;
using System.Windows.Media;

namespace ColorPickerExtraLib.Controls
{
    [TemplatePart(Name = "PART_AvailableColorsGrid", Type = typeof(AvailableColorsGrid))]
    [TemplatePart(Name = "PART_RecentColorsGrid", Type = typeof(RecentColorsGrid))]
    public partial class StandardColorPicker : ControlBase
    {
        private AvailableColorsGrid availableColorsGrid;
        private RecentColorsGrid recentColorsGrid;

        static StandardColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StandardColorPicker), new FrameworkPropertyMetadata(typeof(StandardColorPicker)));
        }

        public override void OnApplyTemplate()
        {
            if (availableColorsGrid != null)
            {
                availableColorsGrid.ColorChanged -= OnSelectionChanged;
            }

            availableColorsGrid = (AvailableColorsGrid)GetTemplateChild("PART_AvailableColorsGrid");
            availableColorsGrid.ColorChanged += OnSelectionChanged;

            if (recentColorsGrid != null)
            {
                recentColorsGrid.ColorChanged -= OnSelectionChanged;
            }

            recentColorsGrid = (RecentColorsGrid)GetTemplateChild("PART_RecentColorsGrid");
            recentColorsGrid.ColorChanged += OnSelectionChanged;
        }

        #region Internal Properties

        internal static readonly DependencyProperty UpdatedRecentColorsItemProperty =
            DependencyProperty.Register(nameof(UpdatedRecentColorsItem), typeof(Color),
                typeof(StandardColorPicker));

        internal static readonly DependencyProperty ToggleButtonStateProperty =
            DependencyProperty.Register(nameof(ToggleButtonState), typeof(ColorPickerState), typeof(StandardColorPicker),
                new PropertyMetadata(ColorPickerState.Closed, OnToggleButtonStateChanged));

        internal static readonly DependencyProperty IsIndependentProperty =
            DependencyProperty.Register(nameof(IsIndependent), typeof(bool), typeof(StandardColorPicker),
                new PropertyMetadata(true));

        internal Color UpdatedRecentColorsItem
        {
            get => (Color)GetValue(UpdatedRecentColorsItemProperty);
            set => SetValue(UpdatedRecentColorsItemProperty, value);
        }

        internal ColorPickerState ToggleButtonState
        {
            get => (ColorPickerState)GetValue(ToggleButtonStateProperty);
            set => SetValue(ToggleButtonStateProperty, value);
        }

        internal bool IsIndependent
        {
            get => (bool)GetValue(IsIndependentProperty);
            set => SetValue(IsIndependentProperty, value);
        }

        #endregion Internal Properties

        #region Event Handlers

        private static void OnToggleButtonStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is StandardColorPicker standard && e.OldValue != e.NewValue && (ColorPickerState)e.NewValue != ColorPickerState.AdvancedOpen)
            {
                standard.UpdatedRecentColorsItem = standard.SelectedColor;
            }
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            Color newColor = ((ColorRoutedEventArgs)e).Color;
            if (newColor != SelectedColor)
            {
                SelectedColor = newColor;
                UpdatedRecentColorsItem = newColor;
                ToggleButtonState = ColorPickerState.Closed;

                if (IsEmpty)
                {
                    IsEmpty = false;
                }
            }
        }

        internal override void OnSelectedColorChanged(Color newColor)
        {
            if (newColor != SelectedColor)
            {
                SelectedColor = newColor;
                UpdatedRecentColorsItem = newColor;
                ToggleButtonState = ColorPickerState.Closed;
                if (IsEmpty)
                {
                    IsEmpty = false;
                }
            }
        }

        public void OnIsEmptyChanged(bool isEmpty)
        {
            if (availableColorsGrid != null)
            {
                availableColorsGrid.OnColorEmptyPropertyChanged(isEmpty);
            }
        }

        #endregion Event Handlers
    }
}