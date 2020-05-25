using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMLight_20200524.Model;
using GalaSoft.MvvmLight;
namespace MVVMLight_20200524.ViewModel
{
    public class WelcomeViewModel:ViewModelBase
    {

        public WelcomeViewModel()
        {
            Welcome = new WelcomeModel() { Introduction = "Hello God!!" };
        }

        private WelcomeModel welcome;
        public WelcomeModel Welcome
        {
            get { return welcome; }
            set
            {
                welcome = value;
                RaisePropertyChanged(() => Welcome);
            }
        }
    }

    
}
