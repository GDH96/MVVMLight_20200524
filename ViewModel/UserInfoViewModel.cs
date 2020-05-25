using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMLight_20200524.Model;
using GalaSoft.MvvmLight;
namespace MVVMLight_20200524.ViewModel
{
    public class UserInfoViewModel:ViewModelBase
    {
        public UserInfoViewModel()
        {
            UserInfo = new UserInfoModel();
        }

        private UserInfoModel userInfo;
        public UserInfoModel UserInfo
        {
            get
            {
                return userInfo;
            }
            set
            {
                userInfo = value;
                RaisePropertyChanged(() => UserInfo);
            }
        }
    }
}
