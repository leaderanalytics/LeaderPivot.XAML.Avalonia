using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;

namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia.Converters;

public class PaddingTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || sourceType == typeof(double) || sourceType == typeof(int);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        return value switch
        {
            //string stringValue => new Avalonia.Padding(double.Parse(stringValue, culture)), // .Padding(...) not found
            // https://github.com/wieslawsoltes/AvaloniaBehaviors/issues/59
        };
    }
}
