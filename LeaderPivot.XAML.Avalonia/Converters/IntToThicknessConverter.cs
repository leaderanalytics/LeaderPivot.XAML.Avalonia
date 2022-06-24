namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia.Converters;

public class IntToThicknessConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return ((Thickness)value).Left;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return new Thickness(System.Convert.ToInt32(value));
    }
}
