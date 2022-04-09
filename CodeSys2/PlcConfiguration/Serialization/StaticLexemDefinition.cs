using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization
{
    internal class StaticLexemDefinition : LexemDefinition<string>
    {
        public bool IsKeyword;

        public StaticLexemDefinition(string rep, LexemKind kind, bool isKeyword = false)
            : base(rep, kind)
        {
            IsKeyword = isKeyword;
        }
    }
}
