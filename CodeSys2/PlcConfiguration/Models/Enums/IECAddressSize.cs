namespace CodeSys2.PlcConfiguration.Models.Enums
{
    /// <summary>
    /// Размер данных IEC адреса.
    /// </summary>
    public enum IECAddressSize
    {
        /// <summary>
        /// Бит.
        /// </summary>
        Bool = 'X',

        /// <summary>
        /// Байт (8 бит).
        /// </summary>
        Byte = 'B',

        /// <summary>
        /// Слово (2 байта | 16 бит).
        /// </summary>
        Word = 'W',

        /// <summary>
        /// Двойное слово (4 байта | 32 бита).
        /// </summary>
        DWord = 'D',
    }
}
