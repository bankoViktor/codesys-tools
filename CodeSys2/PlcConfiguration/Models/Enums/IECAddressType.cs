namespace CodeSys2.PlcConfiguration.Models.Enums
{
    /// <summary>
    /// Типы IEC адресов.
    /// </summary>
    public enum IECAddressType
    {
        /// <summary>
        /// IEC адрес в области памяти для входов.
        /// </summary>
        Input = 'I',

        /// <summary>
        /// IEC адрес в области памяти для выходов.
        /// </summary>
        Output = 'Q',

        /// <summary>
        /// IEC адрес в области памяти.
        /// </summary>
        Memory = 'M',
    }
}
