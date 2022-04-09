using CodeSys2.PlcConfiguration.Serialization.Enums;
using System.Text.RegularExpressions;

namespace CodeSys2.PlcConfiguration.Serialization
{
    internal class DynamicLexemDefinition : LexemDefinition<Regex>
    {
        public DynamicLexemDefinition(string regex, LexemKind kind)
           : base(new Regex(@"\G" + regex, RegexOptions.Compiled), kind)
        {
        }
    }
}
