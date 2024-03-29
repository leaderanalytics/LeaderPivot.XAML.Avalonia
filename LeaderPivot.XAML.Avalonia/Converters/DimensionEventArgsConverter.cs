﻿namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia.Converters;

public class DimensionEventArgsConverter : IMultiValueConverter
{
    public object Convert(IList<object> values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (values[0] == null || values[1] == null)
            return new DimensionEventArgs { Action = DimensionAction.NoOp }; // Occurs when there are no hidden dimensions

        Dimension dimension = values[0] as Dimension ?? throw new Exception("Could not bind to Dimension");
        DimensionAction action = (DimensionAction)values[1];
        return new DimensionEventArgs { Action = action, DimensionID = dimension.DisplayValue };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
