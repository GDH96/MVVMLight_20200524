using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMLight_20200524.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
namespace MVVMLight_20200524.ViewModel
{
    public class ComplexInfoViewModel:ViewModelBase
    {
        public ComplexInfoViewModel()
        {
            InitCombbox();
            InitSingleRadio();
            InitCompRadio();

        }

        private ComplexInfoModel comboxItem;
        public ComplexInfoModel ComboxItem
        {
            get { return comboxItem; }
            set { comboxItem = value; RaisePropertyChanged(() => ComboxItem); }
        }

        private List<ComplexInfoModel> comboxList;
        public List<ComplexInfoModel> ComboxList
        {
            get { return comboxList; }
            set
            {
                comboxList = value;
                RaisePropertyChanged(() => ComboxList);
            }
        }

        #region 命令

        private RelayCommand radioCheckCommand;
        /// <summary>
        /// 单选框命令
        /// </summary>
        public RelayCommand RadioCheckCommand
        {
            get
            {
                if (radioCheckCommand == null)
                    radioCheckCommand = new RelayCommand(() => ExcuteRadioCommand());
                return radioCheckCommand;

            }
            set { radioCheckCommand = value; }
        }
        private void ExcuteRadioCommand()
        {
            RadioButton = RadioButtons.Where(p => p.IsCheck).First();
        }
        #endregion
        #region 单选框相关

        private String singleRadio;
        /// <summary>
        /// 单选框相关
        /// </summary>
        public String SingleRadio
        {
            get { return singleRadio; }
            set { singleRadio = value; RaisePropertyChanged(() => SingleRadio); }
        }


        private Boolean isSingleRadioCheck;
        /// <summary>
        /// 单选框是否选中
        /// </summary>
        public Boolean IsSingleRadioCheck
        {
            get { return isSingleRadioCheck; }
            set { isSingleRadioCheck = value; RaisePropertyChanged(() => IsSingleRadioCheck); }
        }

        #endregion

        #region 组合单选框

        private List<CompBottonModel> radioButtons;
        /// <summary>
        /// 组合单选框列表
        /// </summary>
        public List<CompBottonModel> RadioButtons
        {
            get { return radioButtons; }
            set
            {
                radioButtons = value; RaisePropertyChanged(() => RadioButtons);
            }
        }

        private CompBottonModel radioButton;
        /// <summary>
        /// 组合单选框 选中值
        /// </summary>
        public CompBottonModel RadioButton
        {
            get { return radioButton; }
            set { radioButton = value; RaisePropertyChanged(() => RadioButton); }
        }

        #endregion


        private void InitCombbox()
        {
              ComboxList = new List<ComplexInfoModel>() {
              new ComplexInfoModel(){ Key="1",Text="苹果" },
              new ComplexInfoModel(){ Key="2",Text="香蕉" },
              new ComplexInfoModel(){ Key="3",Text="梨" },
              new ComplexInfoModel(){ Key="4",Text="樱桃" },
            };
        }

        private void InitSingleRadio()
        {
            SingleRadio = "喜欢跑车？";
            IsSingleRadioCheck = false;
        }

        private void InitCompRadio()
        {
            RadioButtons = new List<CompBottonModel>()
            {
                 new CompBottonModel(){ Content="苹果", IsCheck = false },
                 new CompBottonModel(){ Content="香蕉", IsCheck = false },
                 new CompBottonModel(){ Content="梨", IsCheck = false },
                 new CompBottonModel(){ Content="樱桃", IsCheck = false },
            };
        }

    }
}
