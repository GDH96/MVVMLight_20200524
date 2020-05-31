using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using MVVMLight_20200524.Model;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Controls;
namespace MVVMLight_20200524.ViewModel
{
    public class CommandViewModel : ViewModelBase
    {
        public CommandViewModel()
        {
            //构造函数
            ValidateUI = new ValidateUserInfo();
            List = new ObservableCollection<ValidateUserInfo>();
            ResType = new ResTypeModel()
            {
                SelectIndex = 0,
                List = new List<ComplexInfoModel>() {
                    new ComplexInfoModel() { Key="0", Text="请选择..." },
                    new ComplexInfoModel() { Key="1", Text="苹果" },
                    new ComplexInfoModel() { Key="2", Text="香蕉" },
                    new ComplexInfoModel() { Key="3", Text="樱桃"} }
            };
        }

        #region 全局属性
        private ObservableCollection<ValidateUserInfo> list;
        /// <summary>
        /// 用户数据列表
        /// </summary>
        public ObservableCollection<ValidateUserInfo> List
        {
            get { return list; }
            set { list = value; }
        }

        private ValidateUserInfo validateUI;
        /// <summary>
        /// 当前操作的用户信息
        /// </summary>
        public ValidateUserInfo ValidateUI
        {
            get { return validateUI; }
            set
            {
                validateUI = value;
                RaisePropertyChanged(() => ValidateUI);
            }
        }

        private String argStrTo;
         //目标参数
        public String ArgStrTo
        {
            get { return argStrTo; }
            set { argStrTo = value; RaisePropertyChanged(() => ArgStrTo);}
        }

        
        private UserParam objParam;
        public UserParam ObjParam
        {
            get { return objParam; }
            set { objParam = value; RaisePropertyChanged(() => ObjParam); }
        }

        private UserParam argsTo;
        /// <summary>
        /// 动态参数传递
        /// </summary>
        public UserParam ArgsTo
        {
            get { return argsTo; }
            set { argsTo = value; RaisePropertyChanged(() => ArgsTo); }
        }
        #endregion

        #region 全局命令
        private RelayCommand submitCommand;
        /// <summary>
        /// 执行提交命令的方法
        /// </summary>
        public RelayCommand SubmitCommand
        {
            get
            {
                if (submitCommand == null) return new RelayCommand(() => ExcuteValidForm(), CanExcute);
                return submitCommand;
            }
            set { submitCommand = value; }
        }

        private RelayCommand<string> passArgStrCommand;
        /// <summary>
        /// 执行提交命令的方法
        /// </summary>
        public RelayCommand<string> PassArgStrCommand
        {
            get
            {
                if (passArgStrCommand == null) 
                    return new RelayCommand<string>((p) => ExcutePassArgsStr(p));
                return passArgStrCommand;
            }
            set { passArgStrCommand = value; }
        }
        
            private RelayCommand<UserParam> passArgObjCmd;
        /// <summary>
        /// 执行提交命令的方法
        /// </summary>
        public RelayCommand<UserParam> PassArgObjCmd
        {
            get
            {
                if (passArgObjCmd == null)
                    return new RelayCommand<UserParam>((p) => ExcutePassArgObj(p));
                return passArgObjCmd;
            }
            set { passArgObjCmd = value; }
        }


        private RelayCommand<UserParam> dynamicParamCmd;
        /// <summary>
        /// 动态参数传递
        /// </summary>
        public RelayCommand<UserParam> DynamicParamCmd
        {
            get
            {
                if (dynamicParamCmd == null)
                    dynamicParamCmd = new RelayCommand<UserParam>(p => ExecuteDynPar(p));
                return dynamicParamCmd;
            }
            set
            {

                dynamicParamCmd = value;
            }
        }

        private RelayCommand<DragEventArgs> dropCommand;
        /// <summary>
        /// 传递原事件参数
        /// </summary>
        public RelayCommand<DragEventArgs> DropCommand
        {
            get
            {
                if (dropCommand == null)
                    dropCommand = new RelayCommand<DragEventArgs>(e => ExecuteDrop(e));
                return dropCommand;
            }
            set { dropCommand = value; }
        }

        private void ExecuteDrop(DragEventArgs e)
        {
            FileAdd = ((System.Array)e.Data.GetData(System.Windows.DataFormats.FileDrop)).GetValue(0).ToString();
        }

        private RelayCommand selectCommand;
        /// <summary>
        /// 事件转命令执行
        /// </summary>
        public RelayCommand SelectCommand
        {
            get
            {
                if (selectCommand == null)
                    selectCommand = new RelayCommand(() => ExecuteSelect());
                return selectCommand;
            }
            set { selectCommand = value; }
        }
        private void ExecuteSelect()
        {
            if (ResType != null && ResType.SelectIndex > 0)
            {
                SelectInfo = ResType.List[ResType.SelectIndex].Text;
            }
        }

        #region 事件转命令执行

        private String selectInfo;
        /// <summary>
        /// 选中信息
        /// </summary>
        public String SelectInfo
        {
            get { return selectInfo; }
            set { selectInfo = value; RaisePropertyChanged(() => SelectInfo); }
        }
        private ResTypeModel resType;
        /// <summary>
        /// 资源类型列表
        /// </summary>
        public ResTypeModel ResType
        {
            get { return resType; }
            set { resType = value; RaisePropertyChanged(() => ResType); }
        }

        #endregion
        #endregion

        private String fileAdd;
        /// <summary>
        /// 原事件参数
        /// </summary>
        public String FileAdd
        {
            get { return fileAdd; }
            set { fileAdd = value; RaisePropertyChanged(() => FileAdd); }
        }
        #region 附属方法
        /// <summary>
        /// 执行提交方法
        /// </summary>
        private void ExcuteValidForm()
        {
            List.Add(new ValidateUserInfo() { UserEmail = ValidateUI.UserEmail, UserName = ValidateUI.UserName, UserPhone = ValidateUI.UserPhone });
        }

        /// <summary>
        /// 是否可执行（这边用表单是否验证通过来判断命令是否执行）
        /// </summary>
        /// <returns></returns>
        private bool CanExcute()
        {
            return ValidateUI.IsValidated;
        }

        private void ExcutePassArgsStr(string p)
        {
            ArgStrTo = p;
        }

        private void ExcutePassArgObj(UserParam p)
        {
            ObjParam = p;
        }
        
        private void ExecuteDynPar(UserParam p)
        {
            ArgsTo = p;
        }

        #endregion

    }
}
