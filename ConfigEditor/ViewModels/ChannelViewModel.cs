using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Models.Enums;
using System.ComponentModel;

namespace ConfigEditor.ViewModels
{
    internal class ChannelViewModel : BaseViewModel<Channel>
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

        [ReadOnly(true)]
        [Category("Общие")]
        [DisplayName("Режим")]
        [Description("Режим работы канала")]
        public ChannelMode Mode
        {
            get => _model.Mode;
            set => ChangeProperty(nameof(Mode), value);
        }

        ///// <summary>
        ///// Битовые каналы.
        ///// </summary>
        //[Browsable(false)]
        //public List<BitChannel> BitChannels => _model.BitChannels;

        //[Category("Общие")]
        //[DisplayName("Комментарий")]
        //[Description("")]
        //public int IndexInParent
        //{
        //    get => _module.IndexInParent;
        //    set => _module.IndexInParent = value;
        //}

        [ReadOnly(true)]
        [Category("Общие")]
        [DisplayName("Адрес")]
        //[Description("")]
        public IECAddress? Address
        {
            get => _model.Address;
            set => ChangeProperty(nameof(Address), value);
        }


        public ChannelViewModel(Channel channel) : base(channel)
        {
        }
    }
}
