using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MVVMLight_20200524.Model
{
    public class ComplexInfoModel:ViewModelBase
    {
        private string key;
        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                RaisePropertyChanged(() => Key);
            }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                RaisePropertyChanged(() => Text);
            }
        }
    }
}
