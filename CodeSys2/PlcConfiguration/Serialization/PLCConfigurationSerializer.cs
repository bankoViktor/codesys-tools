using CodeSys2.PlcConfiguration.Serialization;

namespace CodeSys2.PlcConfiguration
{
    /// <summary>
    /// Сериализатор конфигурации ПЛК для <b>CodeSys 2</b>.
    /// </summary>
    public static class PlcConfigurationSerializer
    {
        public static string Serialize(PlcConfiguration config)
        {
            throw new NotImplementedException();
        }

        public static PlcConfiguration Deserialize(string text)
        {
            // Лексический анализ
            var lexer = new Lexer(text);

            // Синтаксический анализ
            var syntaxer = new Syntaxer(lexer.Lexems.ToArray());

            var root = syntaxer.Root;


            var config = new PlcConfiguration();


            throw new NotImplementedException();
        }
    }
}
