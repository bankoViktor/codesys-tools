using CodeSys2.PlcConfiguration.Serialization.AST;
using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization
{
    /// <summary>
    /// Синтаксический анализатор файла конфигурации ПЛК.
    /// </summary>
    internal sealed class Syntaxer
    {
        private readonly IReadOnlyList<Lexem> _lexems;
        private int _lexemIndex;

        /// <summary>
        /// Корень абстрактного синтаксического дерева.
        /// </summary>
        public Node Root { get; private set; }


        public Syntaxer(IReadOnlyList<Lexem> lexems)
        {
            _lexems = lexems;

            Root = Analize();
        }

        private Node Analize()
        {
            var obj = Parse();

            throw new NotImplementedException();

            //return Attempt(ParseIdAssign)
            //   ?? Attempt(ParseMemberAssign)
            //   ?? Ensure(ParseIndexAssign, "Неизвестный тип выражения!");
        }

        private object? Parse()
        {
            switch (CurrentLexem.Kind)
            {
                case LexemKind.ConfigurationBegin:
                    Require(LexemKind.GlobalOptionsBegin);
                    break;
                case LexemKind.GlobalOptionsBegin:
                    Match(LexemKind.Version, LexemKind.AutoAddress, LexemKind.CheckAddress, LexemKind.SaveConfigFilesInProject);
                    break;
                case LexemKind.Version:
                case LexemKind.AutoAddress:
                case LexemKind.CheckAddress:
                case LexemKind.SaveConfigFilesInProject:
                    Require(LexemKind.Colon);
                    Require(LexemKind.Number);
                    break;
                case LexemKind.SectionName:
                    break;
                case LexemKind.IndexInParent:
                    break;
                case LexemKind.Comment:
                    break;
                case LexemKind.ModuleBegin:
                    break;
                case LexemKind.ModuleName:
                    break;
                case LexemKind.NodeId:
                    break;
                case LexemKind.IECIn:
                    break;
                case LexemKind.IECOut:
                    break;
                case LexemKind.IECDiag:
                    break;
                case LexemKind.Download:
                    break;
                case LexemKind.ExcludeFromAutoAddress:
                    break;
                case LexemKind.ModuleEnd:
                    break;
                case LexemKind.ChannelBegin:
                    break;
                case LexemKind.SymbolicName:
                    break;
                case LexemKind.ChannelMode:
                    break;
                case LexemKind.ChannelEnd:
                    break;
                case LexemKind.Comma:
                    break;
                case LexemKind.Colon:
                    break;
                case LexemKind.Semicolon:
                    break;
                case LexemKind.SingleQuote:
                    break;
                case LexemKind.Number:
                    break;
                case LexemKind.IECAddress:
                    break;
                case LexemKind.BitChannel:
                    break;
                case LexemKind.ParametersBegin:
                    break;
                case LexemKind.ParametersEnd:
                    break;
                case LexemKind.Parameter:
                    break;
                default:
                    break;
            }

            return null;
        }

        private Lexem CurrentLexem => _lexems[_lexemIndex];

        private Lexem? Match(params LexemKind[] expected)
        {
            if (expected.Length == 0)
                throw new ArgumentException("Список проверяемых лексем пуст", nameof(expected));

            if (InBounds())
            {
                var currentLexem = CurrentLexem;
                if (expected.Any(t => t == currentLexem.Kind))
                {
                    Skip();
                    return currentLexem;
                }
            }

            return null;
        }

        private void Skip(int count = 1) => _lexemIndex = Math.Min(_lexemIndex + count, _lexems.Count - 1);

        private bool InBounds() => _lexemIndex >= 0 && _lexemIndex < _lexems.Count;

        private bool Require(params LexemKind[] expected)
        {
            if (expected.Length == 0)
                throw new ArgumentException("Список ожидаемых лексем пуст", nameof(expected));

            var lexem = Match(expected);

            if (lexem is null)
                throw new InvalidOperationException($"На позиции {CurrentLexem.Offset + CurrentLexem.Length} ожидается {expected[0]}");

            return true;
        }

        private ConfigurationNode? ConfigurationDefine()
        {

            return null;
        }

        private ModuleNode? ModuleDefine()
        {

            return null;
        }

        private ChannelNode? ChannelDefine()
        {

            return null;
        }

        private ParametersNode? ParametersDefine()
        {

            return null;
        }

        private ParameterNode? ParameterDefine()
        {

            return null;
        }

        private T? Attempt<T>(Func<T> getter) where T : Lexem
        {
            var backup = _lexemIndex;

            var result = getter();
            if (result is null)
                _lexemIndex = backup;
        
            return result;
        }

        //private T Ensure<T>(Func<T> getter, string msg) where T : Lexem =>
        //    Bind(getter) ?? throw new InvalidOperationException(msg);

        //private T? Bind<T>(Func<T> getter) where T : Lexem
        //{
        //    var startId = _lexemIndex;
        //    var lexemStart = _lexems[_lexemIndex];

        //    var result = getter();
        //    if (result is not null)
        //    {
        //        result.StartLocation = start.StartLocation;

        //        var endId = _lexemIndex;
        //        if (endId > startId && endId > 0)
        //            result.EndLocation = _lexems[_lexemIndex - 1].EndLocation;
        //    }

        //    return result;
        //}
    }
}
