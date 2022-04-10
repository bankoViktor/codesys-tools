using CodeSys2.PlcConfiguration.Models;
using System.ComponentModel;
using System.Globalization;

namespace CodeSys2.PlcConfiguration.TypeConverters
{
    public class IECAddressTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is null)
            {
                return null;
            }
            else if (value is string valueString)
            {
                return new IECAddress(valueString);
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
