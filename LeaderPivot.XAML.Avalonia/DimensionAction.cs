namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia;

public enum DimensionAction
{
    [Description("Do nothing")]
    NoOp,
    [Description("Sort Ascending")]
    SortAscending,
    [Description("Sort Descending")]
    SortDescending,
    [Description("Hide")]
    Hide,
    [Description("UnHide")]
    UnHide
}