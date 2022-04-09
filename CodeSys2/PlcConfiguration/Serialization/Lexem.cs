using CodeSys2.PlcConfiguration.Serialization.Enums;
using System.Diagnostics;

namespace CodeSys2.PlcConfiguration.Serialization
{
    /// <summary>
    /// Лексема.
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    internal class Lexem
    {
        /// <summary>
        /// Смещение в источнике.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Длина.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Вид лексемы.
        /// </summary>
        public LexemKind Kind { get; }

        /// <summary>
        /// Значение лексемы. Если есть.
        /// </summary>
        public string? Value { get; }


        public Lexem(int offset, int length, LexemKind kind, string? value = default)
        {
            Offset = offset;
            Length = length;
            Kind = kind;
            Value = value;
        }

        private string GetDebuggerDisplay() => $"At {Offset:D5} Kind = {Kind}";
    }
}
