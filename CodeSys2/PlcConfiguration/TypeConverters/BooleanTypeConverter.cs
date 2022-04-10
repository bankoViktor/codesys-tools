using System.ComponentModel;
using System.Globalization;

namespace CodeSys2.PlcConfiguration.TypeConverters
{
    public class BooleanTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(int) || sourceType == typeof(string);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is null)
            {
                return null;
            }
            else if (value is string valueString)
            {
                valueString = valueString.ToLower();

                if (valueString == "0" || valueString == "false")
                    return false;
                else if (valueString == "1" || valueString == "true")
                    return true;
                else
                    throw new InvalidOperationException();
            }
            else if (value is int valueInt)
            {
                return valueInt > 0;
            }
            else
                throw new NotSupportedException();
        }
    }
}
