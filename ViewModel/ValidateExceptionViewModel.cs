using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
namespace MVVMLight_20200524.ViewModel
{
    /// <summary>
    /// Exception 验证
    /// </summary>
    public class ValidateExceptionViewModel:ViewModelBase
    {
        public ValidateExceptionViewModel()
        {
        }

        private String userNameEx;
        /// <summary>
        /// 用户名称（不为空）
        /// </summary>
        public string UserNameEx
        {
            get
            {
                return userNameEx;
            }
            set
            {
                userNameEx = value;
                RaisePropertyChanged(() => UserNameEx);
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("该字段不能为空！");
                }
            }
        }
     }

    
}
