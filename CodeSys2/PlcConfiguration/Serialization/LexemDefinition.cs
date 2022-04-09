using CodeSys2.PlcConfiguration.Serialization.Enums;
using System.Diagnostics;

namespace CodeSys2.PlcConfiguration.Serialization
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    internal class LexemDefinition<T>
    {
        public T Representation { get; protected set; }
        public LexemKind Kind { get; protected set; }


        public LexemDefinition(T representation, LexemKind kind)
        {
            Representation = representation;
            Kind = kind;
        }

        private string GetDebuggerDisplay()
        {
            return $"{Kind}";
        }
    }
}
