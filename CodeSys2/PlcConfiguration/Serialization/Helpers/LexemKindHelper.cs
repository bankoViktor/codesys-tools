using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization.Helpers
{
    internal static class LexemKindHelper
    {
        public static string GetLexemText(LexemKind lexemKind)
        {
            var def = LexemDefinitions.Statics.FirstOrDefault(x => x.Kind == lexemKind);
            return def is not null ? def.Representation : lexemKind.ToString();
        }
    }
}
