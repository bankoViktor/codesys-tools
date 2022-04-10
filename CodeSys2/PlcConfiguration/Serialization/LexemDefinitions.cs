using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization
{
    internal static class LexemDefinitions
    {
        public static StaticLexemDefinition[] Statics = new[]
        {
            new StaticLexemDefinition(",", LexemKind.Comma),
            new StaticLexemDefinition(":", LexemKind.Colon),
            new StaticLexemDefinition(";", LexemKind.Semicolon),
            new StaticLexemDefinition("PLC_CONFIGURATION", LexemKind.ConfigurationBegin, true),
            new StaticLexemDefinition("PLC_END", LexemKind.ConfigurationEnd, true),
            new StaticLexemDefinition("_GLOBAL", LexemKind.GlobalOptionsBegin, true),
            new StaticLexemDefinition("_END_GLOBAL", LexemKind.GlobalOptionsEnd, true),
            new StaticLexemDefinition("_VERSION", LexemKind.Version, true),
            new StaticLexemDefinition("_AUTOADR", LexemKind.AutoAddress, true),
            new StaticLexemDefinition("_CHECKADR", LexemKind.CheckAddress, true),
            new StaticLexemDefinition("_SAVECONFIGFILESINPROJECT", LexemKind.SaveConfigFilesInProject, true),
            new StaticLexemDefinition("_SECTION_NAME", LexemKind.SectionName, true),
            new StaticLexemDefinition("_INDEX_IN_PARENT", LexemKind.IndexInParent, true),
            new StaticLexemDefinition("_COMMENT", LexemKind.Comment, true),
            new StaticLexemDefinition("_MODULE", LexemKind.ModuleBegin, true),
            new StaticLexemDefinition("_MODULE_NAME", LexemKind.ModuleName, true),
            new StaticLexemDefinition("_NODE_ID", LexemKind.NodeId, true),
            new StaticLexemDefinition("_IECIN", LexemKind.IECIn, true),
            new StaticLexemDefinition("_IECOUT", LexemKind.IECOut, true),
            new StaticLexemDefinition("_IECDIAG", LexemKind.IECDiag, true),
            new StaticLexemDefinition("_DOWNLOAD", LexemKind.Download, true),
            new StaticLexemDefinition("_EXCLUDEFROMAUTOADR", LexemKind.ExcludeFromAutoAddress, true),
            new StaticLexemDefinition("_END_MODULE", LexemKind.ModuleEnd, true),
            new StaticLexemDefinition("_CHANNEL", LexemKind.ChannelBegin, true),
            new StaticLexemDefinition("_SYMBOLIC_NAME", LexemKind.SymbolicName, true),
            new StaticLexemDefinition("_CHANNEL_MODE", LexemKind.ChannelMode, true),
            new StaticLexemDefinition("_IECADR", LexemKind.IECAddress, true),
            new StaticLexemDefinition("_BIT", LexemKind.BitChannel, true),
            new StaticLexemDefinition("_END_CHANNEL", LexemKind.ChannelEnd, true),
            new StaticLexemDefinition("_PARAMETER", LexemKind.ParametersBegin, true),
            new StaticLexemDefinition("_PARAM", LexemKind.Parameter, true),
            new StaticLexemDefinition("_END_PARAMETER", LexemKind.ParametersEnd, true),
        };

        public static DynamicLexemDefinition[] Dynamics = new[]
        {
            new DynamicLexemDefinition("(\\+|-)?\\d+", LexemKind.Number),
            new DynamicLexemDefinition("'.*'", LexemKind.String),
            new DynamicLexemDefinition("%(I|Q|M)(X|B|W|D)\\d*(\\.\\d+)*", LexemKind.IECAddress),
        };
    }
}
