namespace CodeSys2.Utils
{
    internal static class EnumHelper
    {
        public static bool EnumValueInRange<T>(int value)
        {
            var enumValues = typeof(T).GetEnumValues().Cast<T>();
            return enumValues.Any(v => Convert.ToInt32(v) == value); ;
        }
    }
}
