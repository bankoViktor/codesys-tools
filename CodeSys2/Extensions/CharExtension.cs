namespace CodeSys2.Extensions
{
    internal static class CharExtension
    {
        public static bool IsAnyOf(this char self, params char[] chars)
        {
            foreach (var ch in chars)
            {
                if (self == ch)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
