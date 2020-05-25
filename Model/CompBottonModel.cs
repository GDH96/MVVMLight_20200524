using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
namespace MVVMLight_20200524.Model
{
    public class CompBottonModel : ObservableObject
    {
        public CompBottonModel()
        {
            //构造函数
        }

        private String content;
        /// <summary>
        /// 单选框相关
        /// </summary>
        public String Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(() => Content); }
        }


        private Boolean isCheck;
        /// <summary>
        /// 单选框是否选中
        /// </summary>
        public Boolean IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; RaisePropertyChanged(() => IsCheck); }
        }
    }
}
