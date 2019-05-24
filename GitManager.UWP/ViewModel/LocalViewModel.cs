using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitManager.UWP.ViewModel
{
    public class LocalViewModel
    {
        private Action _Action1 { get; set; }
        public Action Action1
        {
            get
            {
                return _Action1;
            }
            set
            {
                Debug.WriteLine("Updated LocalViewModel with new action Action1");
                _Action1 = value;
            }
        }
    }
}
