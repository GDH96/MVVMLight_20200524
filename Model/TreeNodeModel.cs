using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MVVMLight_20200524.Model
{
    public class TreeNodeModel:ViewModelBase
    {
        public string NodeID { get; set; }
        public string NodeName { get; set; }
        public List<TreeNodeModel> Children { get; set; }
    }
}
