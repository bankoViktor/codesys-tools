using CodeSys2.PlcConfiguration.Models;
using System.ComponentModel;

namespace ConfigEditor.ViewModels
{
    internal class BitChannelViewModel : BaseViewModel<BitChannel>
    {
        [Browsable(false)]
        public string DisplayText => $"AT {_model.Address}: {_model.Address?.Size.ToString().ToUpper()}";



        public BitChannelViewModel(BitChannel bitChannel) : base(bitChannel)
        {
        }
    }
}
