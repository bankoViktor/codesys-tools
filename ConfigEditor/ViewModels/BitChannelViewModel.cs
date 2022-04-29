using CodeSys2.PlcConfiguration.Models;
using System.ComponentModel;

namespace ConfigEditor.ViewModels
{
    internal class BitChannelViewModel : BaseViewModel<BitChannel>
    {
        [Browsable(false)]
        public string DisplayText => $"AT {_model.Address}: {_model.Address?.Size.ToString().ToUpper()}";


        [Category("Общие")]
        [DisplayName("Символьная метка")]
        [Description("Имя ассоциированной глобавльной переменной.")]
        public string SymbolicName
        {
            get => _model.SymbolicName;
            set => ChangeProperty(nameof(SymbolicName), value);
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

        [ReadOnly(true)]
        [Category("Общие")]
        [DisplayName("Адрес")]
        //[Description("")]
        public IECAddress? Address
        {
            get => _model.Address;
            set => ChangeProperty(nameof(Address), value);
        }


        public BitChannelViewModel(BitChannel bitChannel) : base(bitChannel)
        {
        }
    }
}
