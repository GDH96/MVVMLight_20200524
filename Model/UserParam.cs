using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMLight_20200524.Model
{
    public class UserParam:FrameworkElement
    {
        public String UserName { get; set; }

        public String UserPhone { get; set; }

        public String UserAdd { get; set; }

        public String UserSex { get; set; }
    }
}
