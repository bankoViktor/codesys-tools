using CodeSys2.Extensions;

namespace CodeSys2.PlcConfiguration.Serialization
{
    /// <summary>
    /// Лексический анализатор файла конфигурации ПЛК.
    /// </summary>
    internal sealed class Lexer
    {
        private readonly char[] _spaceChars = new[] { ' ', '\n', '\r', '\t' };
        private readonly string _source;
        private int _offset;

        /// <summary>
        /// Список лексем.
        /// </summary>
        public IEnumerable<Lexem> Lexems { get; private set; }


        public Lexer(string text)
        {
            _source = text ?? throw new ArgumentNullException(nameof(text));
            _offset = 0;

            Lexems = Analize();
        }

        private bool InBounds() => _offset < _source.Length;

        private IEnumerable<Lexem> Analize()
        {
            while (InBounds())
            {
                SkipSpaces();

                if (!InBounds()) break;

                var lex = ProcessStatic() ?? ProcessDynamic();
                if (lex is null)
                    throw new InvalidOperationException($"Неизвестная лексема в позиции {_offset}");

                yield return lex;
            }
        }

        private void SkipSpaces()
        {
            while (InBounds() && _source[_offset].IsAnyOf(_spaceChars))
            {
                _offset++;
            }
        }

        private Lexem? ProcessStatic()
        {
            foreach (var def in LexemDefinitions.Statics)
            {
                var len = def.Representation.Length;

                if (_offset + len > _source.Length || _source.Substring(_offset, len) != def.Representation)
                {
                    continue;
                }

                if (_offset + len < _source.Length && def.IsKeyword)
                {
                    var nextChar = _source[_offset + len];
                    if (nextChar == '_' || char.IsLetterOrDigit(nextChar))
                        continue;
                }

                _offset += len;

                return new Lexem(_offset, len, def.Kind);
            }

            return null;
        }

        private Lexem? ProcessDynamic()
        {
            foreach (var def in LexemDefinitions.Dynamics)
            {
                var match = def.Representation.Match(_source, _offset);
                if (!match.Success)
                {
                    continue;
                }

                _offset += match.Length;

                return new Lexem(_offset, match.Length, def.Kind, match.Value);
            }

            return null;
        }
    }
}
