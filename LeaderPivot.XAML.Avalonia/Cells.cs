namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia;

public class CellContainer : ContentControl
{
    public int RowSpan { get; set; } = 1;
    public int ColSpan { get; set; } = 1;
}

public abstract class BaseCell : ContentControl, INotifyPropertyChanged
{
    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler? PropertyChanged;
    public void RaisePropertyChanged([CallerMemberNameAttribute] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void SetProp<T>(ref T prop, T value, [CallerMemberNameAttribute] string propertyName = "")
    {
        if (!Object.Equals(prop, value))
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }
    }
    #endregion
}

public class DimensionContainerCell : BaseCell
{
    public IList<Dimension> Dimensions
    {
        get { return (IList<Dimension>)GetValue(DimensionsProperty); }
        set { SetValue(DimensionsProperty, value); }
    }

    public static readonly AvaloniaProperty DimensionsProperty =
        AvaloniaProperty.Register<DimensionContainerCell, IList<Dimension>>(nameof(Dimensions));

    public bool IsRows
    {
        get { return (bool)GetValue(IsRowsProperty); }
        set { SetValue(IsRowsProperty, value); }
    }

    public static readonly AvaloniaProperty IsRowsProperty =
        AvaloniaProperty.Register<DimensionContainerCell, bool>(nameof(IsRows), false);

    public int MaxDimensions { get; set; }

    public DimensionContainerCell()
    {

    }
}

public class GroupHeaderCell : BaseCell
{
    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }

    public static readonly AvaloniaProperty IsExpandedProperty =
        AvaloniaProperty.Register<GroupHeaderCell,bool>(nameof(IsExpanded), true);


    public bool CanToggleExpansion
    {
        get { return (bool)GetValue(CanToggleExpansionProperty); }
        set { SetValue(CanToggleExpansionProperty, value); }
    }
    
    public static readonly AvaloniaProperty CanToggleExpansionProperty =
        AvaloniaProperty.Register<GroupHeaderCell,bool>(nameof(CanToggleExpansion), true);


    public string NodeID
    {
        get { return (string)GetValue(NodeIDProperty); }
        set { SetValue(NodeIDProperty, value); }
    }

    public static readonly AvaloniaProperty NodeIDProperty =
        AvaloniaProperty.Register<GroupHeaderCell,string>(nameof(NodeID));


    public ICommand ToggleNodeExpansionCommand
    {
        get { return (ICommand)GetValue(ToggleNodeExpansionCommandProperty); }
        set { SetValue(ToggleNodeExpansionCommandProperty, value); }
    }

    public static readonly AvaloniaProperty ToggleNodeExpansionCommandProperty =
        AvaloniaProperty.Register<GroupHeaderCell,ICommand>(nameof(ToggleNodeExpansionCommand));
}

public class GrandTotalHeaderCell : BaseCell 
{
    
}

public class GrandTotalCell : BaseCell
{
    
}

public class MeasureCell : BaseCell 
{
    
}

public class MeasureContainerCell : BaseCell
{
    public Style ReloadButtonStyle
    {
        get { return (Style)GetValue(ReloadButtonStyleProperty); }
        set { SetValue(ReloadButtonStyleProperty, value); }
    }

    public static readonly AvaloniaProperty ReloadButtonStyleProperty =
        AvaloniaProperty.Register<MeasureContainerCell,Style>(nameof(ReloadButtonStyle));

    public Style MeasureCheckBoxStyle
    {
        get { return (Style)GetValue(MeasureCheckBoxStyleProperty); }
        set { SetValue(MeasureCheckBoxStyleProperty, value); }
    }

    public static readonly AvaloniaProperty MeasureCheckBoxStyleProperty =
        AvaloniaProperty.Register<MeasureContainerCell,Style>(nameof(MeasureCheckBoxStyle));


    public Style HiddenDimensionsListBoxStyle
    {
        get { return (Style)GetValue(HiddenDimensionsListBoxStyleProperty); }
        set { SetValue(HiddenDimensionsListBoxStyleProperty, value); }
    }

    public static readonly AvaloniaProperty HiddenDimensionsListBoxStyleProperty =
        AvaloniaProperty.Register<MeasureContainerCell,Style>(nameof(HiddenDimensionsListBoxStyle));
}

public class MeasureLabelCell : BaseCell 
{
    
}

public class MeasureTotalLabelCell : BaseCell
{
    
}

public class TotalCell : BaseCell 
{
    
}

public class TotalHeaderCell : BaseCell 
{
    
}
