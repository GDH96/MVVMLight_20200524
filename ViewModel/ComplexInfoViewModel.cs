using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMLight_20200524.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections;
using System.Collections.ObjectModel;

namespace MVVMLight_20200524.ViewModel
{
    public class ComplexInfoViewModel:ViewModelBase
    {
        public ComplexInfoViewModel()
        {
            InitCombbox();
            InitSingleRadio();
            InitCompRadio();
            InitTreeInfo();
            InitListBoxList();
            InitUCList();

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

        #region 树
        private List<TreeNodeModel> treeInfo;
        public List<TreeNodeModel> TreeInfo
        {
            get
            {
                return treeInfo;
            }
            set
            {
                treeInfo = value;
                RaisePropertyChanged(() => TreeInfo);
            }
        }
        #endregion

        #region ListBox 模板

        private IEnumerable listBoxData;
        /// <summary>
        /// LisBox数据模板
        /// </summary>
        public IEnumerable ListBoxData
        {
            get { return listBoxData; }
            set { listBoxData = value; RaisePropertyChanged(() => ListBoxData); }
        }

        #endregion

        #region 用户控件信息列表

        private ObservableCollection<FruitInfoModel> fiList;
        /// <summary>
        /// 用户控件模板列表
        /// </summary>
        public ObservableCollection<FruitInfoModel> FiList
        {
            get { return fiList; }
            set { fiList = value; RaisePropertyChanged(() => FiList); }
        }

        #endregion

        #region 初始化
        private void InitCombbox()
        {
            ComboxList = new List<ComplexInfoModel>() {
              new ComplexInfoModel(){ Key="1",Text="苹果" },
              new ComplexInfoModel(){ Key="2",Text="香蕉" },
              new ComplexInfoModel(){ Key="3",Text="梨" },
              new ComplexInfoModel(){ Key="4",Text="樱桃" }
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
        private void InitTreeInfo()
        {
            TreeInfo = new List<TreeNodeModel>()
            {
                new TreeNodeModel()
                { 
                    NodeID = "1",NodeName="汽车",Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel()
                        { 
                            NodeID = "1.1",NodeName="宝马",Children = new List<TreeNodeModel>()
                            {
                                new TreeNodeModel(){ NodeID = "1.1.1",NodeName="M4"},
                                new TreeNodeModel(){ NodeID = "1.1.2",NodeName="X1"},
                                new TreeNodeModel(){ NodeID = "1.1.3",NodeName="X5"} 
                            } 
                        },
                        new TreeNodeModel()
                        {
                            NodeID = "1.2",NodeName="奥迪",Children = new List<TreeNodeModel>()
                            {
                                new TreeNodeModel(){ NodeID = "1.2.1",NodeName="Q5"},
                                new TreeNodeModel(){ NodeID = "1.2.2",NodeName="A4L"},
                                new TreeNodeModel(){ NodeID = "1.2.3",NodeName="E级"}
                            }
                        }
                    }
                },
                new TreeNodeModel()
                {
                    NodeID = "2",NodeName="城市",Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel()
                        {
                            NodeID = "2.1",NodeName="广东",Children = new List<TreeNodeModel>()
                            {
                                new TreeNodeModel(){ NodeID = "2.1.1",NodeName="中山"},
                                new TreeNodeModel(){ NodeID = "2.1.2",NodeName="珠海"},
                                new TreeNodeModel(){ NodeID = "2.1.3",NodeName="广州"}
                            }
                        }
                    }
                }
            };
        }

        private void InitListBoxList()
        {
            ListBoxData = new ObservableCollection<dynamic>(){
              new { Img="/MVVMLight_20200524;component/Images/1.jpg",Info="樱桃" },
              new { Img="/MVVMLight_20200524;component/Images/2.jpg",Info="葡萄" },
              new { Img="/MVVMLight_20200524;component/Images/3.jpg",Info="苹果" },
              new { Img="/MVVMLight_20200524;component/Images/4.jpg",Info="猕猴桃" },
              new { Img="/MVVMLight_20200524;component/Images/5.jpg",Info="柠檬" },
           };
        }

        private void InitUCList()
        {
            FiList = new ObservableCollection<FruitInfoModel>() {
                 new FruitInfoModel{ Img = "/MVVMLight_20200524;component/Images/1.jpg", Info= "樱桃"},
              new FruitInfoModel{ Img = "/MVVMLight_20200524;component/Images/2.jpg", Info = "葡萄"}
            };
        }
        #endregion


    }
}
