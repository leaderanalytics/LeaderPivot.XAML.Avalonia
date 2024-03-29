﻿namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia.Converters;

public class DimensionEventCheckedConverter : IMultiValueConverter
{
    public object Convert(IList<object> values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        Dimension dimension = values[0] as Dimension ?? throw new Exception("Could not bind to Dimension");
        DimensionAction action = (DimensionAction)values[1];
        return action == DimensionAction.Hide? false : action == DimensionAction.SortAscending ? dimension.IsAscending : ! dimension.IsAscending;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
