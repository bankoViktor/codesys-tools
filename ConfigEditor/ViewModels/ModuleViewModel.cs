using CodeSys2.PlcConfiguration.Models;
using System.ComponentModel;

namespace ConfigEditor.ViewModels
{
    internal class ModuleViewModel : BaseViewModel<Module>
    {
        [Browsable(false)]
        public string DisplayText => string.IsNullOrWhiteSpace(_model.ModuleName) ? $"[{SectionName}]" : _model.ModuleName;

        [Category("Общие")]
        [DisplayName("Имя модуля")]
        [Description("Отображаемое имя модуля в конфигурации, ни на что не влияет.")]
        public string? ModuleName
        {
            get => _model.ModuleName;
            set => ChangeProperty(nameof(ModuleName), value);
        }

        [ReadOnly(true)]
        [Category("Общие")]
        [DisplayName("Имя секции")]
        //[Description("")]
        public string SectionName
        {
            get => _model.SectionName;
            set => ChangeProperty(nameof(SectionName), value);
        }

        [Category("Общие")]
        [DisplayName("Комментарий")]
        [Description("Пользовательский комментарий элемента.")]
        //[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Comment
        {
            get => _model.Comment;
            set => ChangeProperty(nameof(Comment), value);
        }

        [Category("Общие")]
        //[DisplayName("Комментарий")]
        //[Description("")]
        //[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public bool IsDownload
        {
            get => _model.IsDownload;
            set => ChangeProperty(nameof(IsDownload), value);
        }

        //[Category("Общие")]
        //[DisplayName("Комментарий")]
        //[Description("")]
        //public int IndexInParent
        //{
        //    get => _model.IndexInParent;
        //    set => _model.IndexInParent = value;
        //}

        [ReadOnly(true)]
        [Category("Общие")]
        //[DisplayName("Комментарий")]
        //[Description("")]
        //[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public IECAddress? AddressIn
        {
            get => _model.AddressIn;
            set => ChangeProperty(nameof(AddressIn), value);
        }

        [ReadOnly(true)]
        [Category("Общие")]
        //[DisplayName("Комментарий")]
        //[Description("")]
        public IECAddress? AddressOut
        {
            get => _model.AddressOut;
            set => ChangeProperty(nameof(AddressOut), value);
        }

        [ReadOnly(true)]
        [Category("Общие")]
        //[DisplayName("Комментарий")]
        //[Description("")]
        public IECAddress? AddressDiag
        {
            get => _model.AddressDiag;
            set => ChangeProperty(nameof(AddressDiag), value);
        }


        public ModuleViewModel(Module module) : base(module)
        {
        }
    }
}
