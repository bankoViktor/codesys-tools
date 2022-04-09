namespace CodeSys2.PlcConfiguration.Serialization.Enums
{
    /// <summary>
    /// Типы лексем.
    /// </summary>
    internal enum LexemKind
    {
        /// <summary>
        /// Начало конфигурации.
        /// </summary>
        ConfigurationBegin,

        /// <summary>
        /// Конец конфигурации.
        /// </summary>
        ConfigurationEnd,

        /// <summary>
        /// Начало глобальных параметров.
        /// </summary>
        GlobalOptionsBegin,

        /// <summary>
        /// Конец глобальных параметров.
        /// </summary>
        GlobalOptionsEnd,

        /// <summary>
        /// Версия конфигурационного файла.
        /// </summary>
        Version,

        /// <summary>
        /// Автоматическое назначение IEC адреса.
        /// </summary>
        AutoAddress,

        /// <summary>
        /// Проверять пересечение IEC адресов.
        /// </summary>
        CheckAddress,

        /// <summary>
        /// Сохранять конфигурационный файл в проекте.
        /// </summary>
        SaveConfigFilesInProject,

        /// <summary>
        /// Название секции.
        /// </summary>
        SectionName,

        /// <summary>
        /// Индекс в родительском элементе.
        /// </summary>
        IndexInParent,

        /// <summary>
        /// Комментарий.
        /// </summary>
        Comment,

        /// <summary>
        /// Начало модуля.
        /// </summary>
        ModuleBegin,

        /// <summary>
        /// Имя модуля.
        /// </summary>
        ModuleName,

        /// <summary>
        /// Id узла в дереве конфигурации.
        /// </summary>
        NodeId,

        /// <summary>
        /// IEC адрес входа.
        /// </summary>
        IECIn,

        /// <summary>
        /// IEC адрес выхода.
        /// </summary>
        IECOut,

        /// <summary>
        /// IEC адрес ?.
        /// </summary>
        IECDiag,

        /// <summary>
        /// ?
        /// </summary>
        Download,

        /// <summary>
        /// Исключить из автоматического назначения адреса.
        /// </summary>
        ExcludeFromAutoAddress,

        /// <summary>
        /// Конец модуля.
        /// </summary>
        ModuleEnd,

        /// <summary>
        /// Начало канала.
        /// </summary>
        ChannelBegin,

        /// <summary>
        /// Символическое имя.
        /// </summary>
        SymbolicName,

        /// <summary>
        /// Имя канала.
        /// </summary>
        ChannelMode,

        /// <summary>
        /// Конец канала.
        /// </summary>
        ChannelEnd,

        /// <summary>
        /// Запятая.
        /// </summary>
        Comma,

        /// <summary>
        /// Двоеточие.
        /// </summary>
        Colon,

        /// <summary>
        /// Точка с запятой.
        /// </summary>
        Semicolon,

        /// <summary>
        /// Одиночная кавычка.
        /// </summary>
        SingleQuote,

        /// <summary>
        /// Число.
        /// </summary>
        Number,

        /// <summary>
        /// IEC адрес.
        /// </summary>
        IECAddress,

        /// <summary>
        /// Битовый канал.
        /// </summary>
        BitChannel,

        /// <summary>
        /// Начало списка параметров.
        /// </summary>
        ParametersBegin,

        /// <summary>
        /// Конец списка параметров.
        /// </summary>
        ParametersEnd,

        /// <summary>
        /// Параметер.
        /// </summary>
        Parameter,
    }
}
