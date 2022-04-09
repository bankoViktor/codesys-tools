using CodeSys2.PlcConfiguration.Models.Enums;
using CodeSys2.PlcConfiguration.TypeConverters;
using CodeSys2.Utils;
using System.ComponentModel;
using System.Diagnostics;

namespace CodeSys2.PlcConfiguration.Models
{
    /// <summary>
    /// IEC адрес.
    /// </summary>
    [TypeConverter(typeof(IECAddressTypeConverter))]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class IECAddress : ICloneable
    {
        private IECAddressType _type = IECAddressType.Input;
        private IECAddressSize _size = IECAddressSize.Bit;

        /// <summary>
        /// Тип IEC адреса.
        /// </summary>
        public IECAddressType Type
        {
            get => IsRalative && Parent is not null ? Parent.Type : _type;
            set
            {
                if (IsRalative && Parent is not null)
                    throw new InvalidOperationException("Недопустимо изменять тип IEC адреса родительского элемента");
                else
                    _type = value;
            }
        }

        /// <summary>
        /// Размер IEC адреса.
        /// </summary>
        public IECAddressSize Size
        {
            get => IsRalative && Parent is not null ? Parent.Size : _size;
            set
            {
                if (IsRalative && Parent is not null)
                    throw new InvalidOperationException("Недопустимо изменять размер IEC адреса родительского элемента");
                else
                    _size = value;
            }
        }

        /// <summary>
        /// Компоненты IEC адреса.
        /// <para/>
        /// Компоненты разреляются '.' (точкой), например: <i>%QB0.1.4</i>
        /// </summary>
        public List<int> Components { get; } = new List<int> { 0 };

        /// <summary>
        /// Родительский экземпляр IEC адреса.
        /// </summary>
        public IECAddress? Parent { get; }

        /// <summary>
        /// Флаг относительного экземпляра IEC адреса.
        /// </summary>
        public bool IsRalative => Parent is not null;

        /// <summary>
        /// Глубина, количество компонентов IEC адреса.
        /// </summary>
        public int Deep => Components.Count;

        /// <summary>
        /// Получение и установка компонентов IEC адреса.
        /// </summary>
        /// <param name="levent">Уровень компонента IEC адреса.</param>
        /// <returns>Компонент IEC адреса указанного уровня.</returns>
        public int this[int levet]
        {
            get { return GetComponent(levet); }
            set { SetComponent(value, levet); }
        }


        public IECAddress()
        {
        }

        public IECAddress(string strAddress)
        {
            if (strAddress is null)
                throw new ArgumentNullException(nameof(strAddress));

            Parse(strAddress);
        }

        public IECAddress(IECAddressType type, IECAddressSize size, params int[] components)
        {
            Type = type;
            Size = size;
            Components = new List<int>();

            if (components.Length > 0)
                Components.AddRange(components);
            else
                Components.Add(0);
        }

        public IECAddress(IECAddress parent)
        {
            Parent = parent;
        }

        public IECAddress(IECAddress parent, params int[] components)
        {
            Parent = parent;

            if (components.Length == 0)
                throw new ArgumentException("Список компонентов IEC адреса пуст", nameof(components));

            Components.Clear();
            Components.AddRange(components);
        }

        public override string ToString()
        {
            string result;

            if (IsRalative && Parent is not null)
            {
                if (Parent.Deep == 0)
                    return "Invalid Address";

                result = Parent.ToString();
            }
            else
            {
                if (Deep == 0)
                    return "Invalid Address";

                result = "%" + (char)Type + (char)Size;
            }

            for (var i = 0; i < Components.Count; i++)
            {
                if (i == 0 && IsRalative ||
                    i > 0 && i < Components.Count)
                {
                    result += ".";
                }

                result += Components[i];
            }

            return result;
        }

        private string GetDebuggerDisplay() => '{' + ToString() + '}';

        /// <summary>
        /// Инициализирует IEC адрес значением из строки.
        /// </summary>
        /// <param name="strAddress"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public void Parse(string strAddress)
        {
            if (IsRalative)
                throw new InvalidOperationException("Данный экземплял IEC адреса является относильным");

            if (strAddress is null)
                throw new ArgumentNullException(nameof(strAddress));

            var addr = strAddress.Trim();

            if (string.IsNullOrWhiteSpace(strAddress) || addr[0] != '%')
                throw new InvalidOperationException($"Значение \"{strAddress}\" не является IEC адресом");

            // Type

            if (!EnumHelper.EnumValueInRange<IECAddressType>(addr[1]))
                throw new NotSupportedException($"Литера \"{addr[1]}\" типа IEC адреса не поддерживается");

            Type = (IECAddressType)addr[1];

            // Size

            if (!EnumHelper.EnumValueInRange<IECAddressSize>(addr[2]))
                throw new NotSupportedException($"Литера \"{addr[2]}\" размера IEC адреса не поддерживается");

            Size = (IECAddressSize)addr[2];

            // Components

            var componentValues = addr[3..].Split('.');

            if (componentValues.Length == 0)
                throw new InvalidOperationException("Не задано ни одного компонента IEC адреса");

            var components = new List<int>();

            foreach (var componentValue in componentValues)
            {
                if (!int.TryParse(componentValue, out var component) || component < 0)
                    throw new InvalidOperationException($"Недопустымый компонент IEC адреса: {(componentValue == string.Empty ? "<пусто>" : componentValue)}");

                components.Add(component);
            }

            Components.Clear();
            Components.AddRange(components);
        }

        /// <summary>
        /// Устанавливает новое значения указанного компонента IEC адреса.
        /// <para/>
        /// Если компонента IEC адреса с указанным уровнем не существует и уровень является последним,
        /// то добавляется новый компонент IEC адреса.
        /// </summary>
        /// <param name="value">Новое значение компонента IEC адреса.</param>
        /// <param name="level">Уровень компонента IEC адреса. Начинается с 0.</param>
        /// <returns>Старое значение компонента IEC адреса.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int SetComponent(int value, int level = 0)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (level < 0)
                throw new ArgumentOutOfRangeException(nameof(level));

            var localLevel = level;

            // Parent

            if (IsRalative && Parent is not null)
            {
                if (level < Parent.Deep)
                {
                    // parent
                    throw new InvalidOperationException($"Недопустимо изменять компоненты IEC адреса родителя");
                }
                else
                {
                    // parent + child
                    localLevel = level - Parent.Deep;
                }
            }

            // Local

            if (localLevel < Deep)
            {
                var oldValue = Components[localLevel];
                Components[localLevel] = value;
                return oldValue;
            }
            else
            {
                throw new InvalidOperationException($"Компонента IEC адреса с уровнем \"{level}\" не существует");
            }
        }

        /// <summary>
        /// Возвращает компонент IEC адреса указанного уровня.
        /// </summary>
        /// <param name="level"></param>
        /// <returns>Компонент IEC адреса указанного уровня.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public int GetComponent(int level = 0)
        {
            if (level < 0)
                throw new ArgumentOutOfRangeException(nameof(level));

            var localLevel = level;

            // Parent

            if (IsRalative && Parent is not null)
            {
                if (level < Parent.Deep)
                {
                    // parent
                    return Parent.GetComponent(level);
                }
                else
                {
                    // parent + child
                    localLevel = level - Parent.Deep;

                }
            }

            // Local

            if (localLevel < Deep)
            {
                return Components[level];
            }
            else
            {
                throw new InvalidOperationException($"Компонента IEC адреса с уровнем \"{level}\" не существует");
            }
        }

        /// <summary>
        /// Добавляет новые компоненты IEC адреса.
        /// </summary>
        /// <param name="components"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddComponents(params int[] components)
        {
            if (components.Length == 0)
                throw new ArgumentException("Список компонентов IEC адреса пуст", nameof(components));

            Components.AddRange(components);
        }

        public static IECAddress operator +(IECAddress addr)
        {
            addr.Components[^1]++;
            return addr;
        }

        public static IECAddress operator -(IECAddress addr)
        {
            if (addr.Components[^1] <= 0)
                throw new InvalidOperationException("Компонент IEC адреса должен быть положительным числом");
            addr.Components[^1]--;
            return addr;
        }

        #region ICloneable

        /// <summary>
        /// Клонирует экземпляр IEC адреса.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            if (IsRalative && Parent is not null)
            {
                return new IECAddress(Parent, Components.ToArray());
            }
            else
            {
                return new IECAddress(Type, Size, Components.ToArray());
            }
        }

        #endregion
    }
}
