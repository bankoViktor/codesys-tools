namespace CodeSys2.PlcConfiguration.Models.Enums
{
    /// <summary>
    /// Режим канала конфигурации ПЛК.
    /// </summary>
    public enum ChannelMode
    {
        /// <summary>
        /// Канал входа.
        /// </summary>
        Input = 'I',

        /// <summary>
        /// Канал выхода.
        /// </summary>
        Output = 'Q',

        /// <summary>
        /// Канал в памяти.
        /// </summary>
        Diag = 'M',
    }
}
