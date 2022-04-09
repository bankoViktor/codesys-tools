using CodeSys2.PlcConfiguration;

namespace ConfigEditor.Data
{
    public class DataContext
    {
        public string? SourceFilename { get; set; }
        public bool IsModified { get; set; } = false;
        public PlcConfiguration? Configuration { get; set; }
    }
}
