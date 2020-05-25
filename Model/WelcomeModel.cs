using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MVVMLight_20200524.Model
{
    public class WelcomeModel: ObservableObject
    {
        private string introduction;

        public string Introduction
        {
            get
            {
                return introduction;
            }
            set
            {
                introduction = value;
                RaisePropertyChanged(() => Introduction);
            }
        }
    }
}
