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

            // Синтаксический анализ и заполнение объекта конфигурации
            var syntaxer = new Syntaxer(lexer.Lexems.ToArray());
            var config = syntaxer.ParseConfiguration();
            if (config is null)
                throw new InvalidOperationException("Не удалось десериализовать конфигурацию ПЛК");

            return config;
        }
    }
}
