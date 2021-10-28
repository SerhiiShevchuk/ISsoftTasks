using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_NET02_4
{
    interface IRepo
    {
        public List<MonitorSetting> LoadMonitorsSettings();
    }
}
