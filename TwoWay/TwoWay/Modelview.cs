using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TwoWay
{
    public class Modelview : INotifyPropertyChanged
    {
        public string inputText;
        public string InpText
        {
            get { return inputText; }
            set
            {
                if (inputText != value)
                {
                    inputText = value;
                    onChangeProperty();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void onChangeProperty([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
