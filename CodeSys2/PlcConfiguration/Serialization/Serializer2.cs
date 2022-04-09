using System.Text;

namespace CodeSys2
{
    public static class Serializer2
    {
        private const string _configuratuinBegin = "PLC_CONFIGURATION";
        private const string _configuratuinEnd = "PLC_END";
        private const string _globalBegin = "_GLOBAL";
        private const string _globalEnd = "_END_GLOBAL";
        private const string _version = "_VERSION";
        private const string _autoAddress = "_AUTOADR";
        private const string _checkAddress = "_CHECKADR";
        private const string _saveInConfigProject = "_SAVECONFIGFILESINPROJECT";
        private const string _moduleBegin = "_MODULE";
        private const string _moduleEnd = "_END_MODULE";
        private const string _channelBegin = "_CHANNEL";
        private const string _channelEnd = "_END_CHANNEL";
        private const string _param = "_PARAM";
        private const string _parameterBegin = "_PARAMETER";
        private const string _parameterEnd = "_END_PARAMETER";
        private const string _sectionName = "_SECTION_NAME";
        private const string _indexInParent = "_INDEX_IN_PARENT";
        private const string _moduleName = "_MODULE_NAME";
        private const string _nodeId = "_NODE_ID";
        private const string _iecIn = "_IECIN";
        private const string _iecOut = "_IECOUT";
        private const string _iecDiag = "_IECDIAG";
        private const string _download = "_DOWNLOAD";
        private const string _excludeFromAutoAdr = "_EXCLUDEFROMAUTOADR";
        private const string _comment = "_COMMENT";


        public static string Serialize(PLCConfiguration config)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(_configuratuinBegin);

            // Global
            strBuilder.AppendLine(_globalBegin);
            strBuilder.AppendLine(_version + ": " + config.Version.ToString());
            strBuilder.AppendLine(_autoAddress + ": " + (config.AutoAdress ? '1' : '0'));
            strBuilder.AppendLine(_checkAddress + ": " + (config.CheckAddress ? '1' : '0'));
            strBuilder.AppendLine(_saveInConfigProject + ": " + (config.SaveConfigInProject ? '1' : '0'));
            strBuilder.AppendLine(_globalEnd);

            // Modules

            WriteModule(strBuilder, config.RootModule);

            strBuilder.AppendLine(_configuratuinEnd);

            return strBuilder.ToString();
        }

        private static void WriteModule(StringBuilder builder, Module module)
        {

        }

        /*
        public static PLCConfiguration Deserialize(string text)
        {
            var lines = text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            PLCConfiguration? config = null;
            bool configClosed = false;
            bool isGlobal = false;

            foreach (var line in lines)
            {
                var _line_ = line.Trim();

                if (_line_.StartsWith(_configuratuinBegin))
                {
                    config = new PLCConfiguration();
                }
                else if (_line_.StartsWith(_configuratuinEnd))
                {
                    configClosed = true;
                }
                else if (_line_.StartsWith(_globalBegin))
                {
                    isGlobal = true;
                }
                else if (_line_.StartsWith(_globalEnd))
                {
                    isGlobal = false;
                }
                else if (_line_.StartsWith(_version))
                {
                    if (!isGlobal)
                        throw new InvalidOperationException();

                    config.Version = ReadInt2(_line_);
                }
            }

            if (!configClosed || isGlobal)
                throw new InvalidOperationException();

            return config ?? throw new InvalidOperationException();
        }

        private static int ReadInt2(string line)
        {
            var pos = line.IndexOf(':');
            if (pos == -1)
                throw new InvalidOperationException();

            var valueStr = line.Substring(pos + 1, line.Length - pos - 1);
            if (string.IsNullOrWhiteSpace(valueStr))
                throw new InvalidOperationException();

            if (!int.TryParse(valueStr, out int value))
                throw new InvalidOperationException();

            return value;
        }
        */

        public static PLCConfiguration Deserialize(string text)
        {
            TextReader textReader = new StringReader(text);


            var content = text.Trim();

            var configStart = content.IndexOf(_configuratuinBegin);
            if (configStart == -1)
                throw new InvalidOperationException("Файл не является ПЛК-конфигурацией.");

            var configEnd = content.IndexOf(_configuratuinEnd, configStart + _configuratuinBegin.Length);
            if (configEnd == -1)
                throw new InvalidOperationException("Файл не является ПЛК-конфигурацией.");

            var globalStart = content.IndexOf(_globalBegin, configStart);
            if (globalStart == -1)
                throw new InvalidOperationException($"Не найден секция '{_globalBegin}'.");

            var globalEnd = content.IndexOf(_globalEnd, globalStart + _globalBegin.Length);
            if (globalEnd == -1)
                throw new InvalidOperationException($"Не найден конец секции '{_globalBegin}'.");

            // Global Section

            var globalSection = new Range(globalStart, globalEnd);

            // Modules

            var other = new Range(globalEnd + _globalEnd.Length, configEnd);

            var rootModuleStart = content.IndexOf(_moduleBegin, globalEnd + _globalEnd.Length);
            if (rootModuleStart == -1)
                throw new InvalidOperationException();

            var rootModuleSection = new Range(rootModuleStart, configEnd);

            var rootModule = ReadModules(content, rootModuleSection).Single();

            return new PLCConfiguration()
            {
                Version = ReadInt(content, _version, globalSection),
                AutoAdress = ReadBool(content, _autoAddress, globalSection),
                CheckAddress = ReadBool(content, _checkAddress, globalSection),
                SaveConfigInProject = ReadBool(content, _saveInConfigProject, globalSection),
                RootModule = rootModule,
            };
        }

        private static List<Module> ReadModules(string content, Range section)
        {
            var position = section.Start.Value;

            var name = content.IndexOf(':', position);
            if (name == -1)
                throw new InvalidOperationException();

            var qBegin = content.IndexOf('\'', name);
            if (qBegin == -1)
                throw new InvalidOperationException();

            var qEnd = content.IndexOf('\'', qBegin + 1);
            if (qEnd == -1)
                throw new InvalidOperationException();

            var modules = new List<Module>();

            var module = new Module()
            {
                Name = content[qBegin..qEnd].Trim(),
                SectionName = ReadString(content, _sectionName, section),
                IndexInParent = ReadInt(content, _indexInParent, section),
                ModuleName = ReadString(content, _moduleName, section),
                NodeId = ReadInt(content, _nodeId, section),
                InAddress = new IECAddress(ReadString(content, _iecIn, section)),
                OutAddress = new IECAddress(ReadString(content, _iecOut, section)),
                DiagAddress = new IECAddress(ReadString(content, _iecDiag, section)),
                Download = ReadBool(content, _download, section),
                ExcludeFromAutoAddress = ReadBool(content, _excludeFromAutoAdr, section),
                Comment = ReadString(content, _comment, section),
                Modules = ReadModules(content, section),
            };

            modules.Add(module);

            return modules;
        }

        private static List<Parameter> ReadParameters(string content, Range section)
        {
            return new();
        }

        private static Parameter ReadParameter(string content, Range section)
        {
            return new();
        }

        private static bool ReadBool(string content, string name, Range section)
        {
            var val = ReadString(content, name, section);

            if (string.IsNullOrWhiteSpace(val) || val != "0" && val != "1")
                throw new InvalidOperationException("Не допустимое значение параметра '_AUTOADR' в секции '_GLOBAL'.");

            return val == "1";
        }

        private static int ReadInt(string content, string name, Range section)
        {
            var val = ReadString(content, name, section);

            if (!int.TryParse(val, out int version))
                throw new InvalidOperationException("Не допустимое значение параметра '_VERSION' в секции '_GLOBAL'.");

            return version;
        }

        private static string ReadString(string content, string name, Range section)
        {
            var paramStart = content.IndexOf(name, section.Start.Value);
            if (paramStart > -1 && paramStart < section.End.Value)
            {
                var sep = content.IndexOf(':', paramStart);
                if (sep > 0 && paramStart < section.End.Value)
                {
                    var val = content.IndexOfAny(new char[] { ' ' }, sep);
                    if (val > 0 && paramStart < section.End.Value)
                    {
                        var endLine = content.IndexOf('\n', val);
                        if (endLine > 0 && paramStart < section.End.Value)
                        {
                            var value = content[val..endLine].Trim();

                            if (value[0] == '\'')
                                value = value[1..];

                            if (value[^1] == '\'')
                                value = value[0..^1];

                            return value;
                        }
                    }
                }
            }

            throw new InvalidOperationException($"Не найден параметр '{name}'.");
        }
    }
}
