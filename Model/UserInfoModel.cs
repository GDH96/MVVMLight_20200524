using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MVVMLight_20200524.Model
{
    public class UserInfoModel:ViewModelBase
    {
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }


        private string userSex;
        public string UserSex
        {
            get
            {
                return userSex;
            }
            set
            {
                userSex = value;
                RaisePropertyChanged(() => UserSex);
            }
        }

        private string userPhone;
        public string UserPhone
        {
            get
            {
                return userPhone;
            }
            set
            {
                userPhone = value;
                RaisePropertyChanged(() => UserPhone);
            }
        }
    }
}
