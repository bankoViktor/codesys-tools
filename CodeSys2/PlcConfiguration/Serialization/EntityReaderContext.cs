using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Serialization.Enums;
using CodeSys2.PlcConfiguration.Serialization.Helpers;
using CodeSys2.PlcConfiguration.TypeConverters;
using CodeSys2.Utils;
using System.ComponentModel;

namespace CodeSys2.PlcConfiguration.Serialization
{
    internal class EntityReaderContext
    {
        public IReadOnlyList<Lexem> Lexems { get; }
        public int Position { get; set; }
        public Lexem Current => Lexems[Position];
        public bool InBounds => Position >= 0 && Position < Lexems.Count;
        public bool IsEnd => Position == Lexems.Count - 1;


        public EntityReaderContext(IReadOnlyList<Lexem> lexems)
        {
            Lexems = lexems;
            Position = 0;
        }

        public void Skip(int count = 1) => Position = Math.Min(Position + count, Lexems.Count - 1);

        public bool AnyOf(params LexemKind[] expected) => expected.Any(t => t == Current.Kind);

        public Lexem? Match(params LexemKind[] expected)
        {
            if (expected.Length == 0)
                throw new ArgumentException("Список проверяемых лексем пуст", nameof(expected));

            if (InBounds)
            {
                var currentLexem = Current;
                if (AnyOf(expected))
                {
                    Skip();
                    return currentLexem;
                }
            }

            return null;
        }

        public Lexem Require(params LexemKind[] expected)
        {
            if (expected.Length == 0)
                throw new ArgumentException("Список ожидаемых лексем пуст", nameof(expected));

            var lexem = Match(expected);

            if (lexem is null)
                throw new InvalidOperationException($"На позиции {Current.Offset + Current.Length} ожидается {LexemKindHelper.GetLexemText(expected[0])}");

            return lexem;
        }

        public T TryGetValue<T>(Lexem lexem)
        {
            if (lexem is null)
                throw new ArgumentNullException(nameof(lexem));

            if (lexem.Value is not null)
            {
                var value = lexem.Kind == LexemKind.String ? lexem.Value[1..^1] : lexem.Value;

                var targetType = typeof(T);

                if (targetType.IsEnum)
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        int enumVal;

                        if (value.Length == 1)
                        {
                            enumVal = value[0];
                        }
                        else if (value.Length > 1)
                        {
                            if (!int.TryParse(value, out enumVal))
                                throw new InvalidOperationException($"На позиции {lexem.Offset} недопустимое значение '{value}'");
                        }
                        else
                        {
                            throw new InvalidOperationException($"На позиции {lexem.Offset} недопустимое значение '{value}'");
                        }

                        if (EnumHelper.IsValid<T>(enumVal))
                        {
                            return (T)(object)enumVal;
                        }
                    }
                    throw new InvalidOperationException($"На позиции {lexem.Offset} недопустимое значение '{value}'");
                }
                else
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(T)); ;
                    if (typeof(T) == typeof(bool))
                    {
                        converter = new BooleanTypeConverter();
                    }
                    else if (typeof(T) == typeof(IECAddress))
                    {
                        converter = new IECAddressTypeConverter();
                    }

                    if (converter.CanConvertFrom(value.GetType()))
                    {
                        var convertedValue = converter.ConvertFrom(value);
                        if (convertedValue is not null)
                            return (T)convertedValue;
                    }
                }
            }

            throw new InvalidOperationException($"На позиции {lexem.Offset} недопустимое значение \"{lexem.Value}\" свойства");
        }
    }
}
