using CodeSys2.PlcConfiguration.Serialization;

namespace CodeSys2.PlcConfiguration.Serialization
{
    internal interface IReader
    {
        void Read(ReadOnlySpan<Lexem> lexems);
    }

    internal class ConfigurationReader : IReader
    {
        public void Read(ReadOnlySpan<Lexem> lexems)
        {
        }
    }

    internal class ModuleReader : IReader
    {
        public void Read(ReadOnlySpan<Lexem> lexems)
        {
        }
    }

    internal class ChannelReader : IReader
    {
        public void Read(ReadOnlySpan<Lexem> lexems)
        {
        }
    }

    internal class ParametersReader : IReader
    {
        public void Read(ReadOnlySpan<Lexem> lexems)
        {
        }
    }

    internal class ParameterReader : IReader
    {
        public void Read(ReadOnlySpan<Lexem> lexems)
        {
        }
    }
}
