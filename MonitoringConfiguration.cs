using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_NET02_4
{
    class MonitoringConfiguration : ICloneable
    {
        public List<MonitorSetting> Settings { get; set; }

        public  void GetMonitorSettings(IRepo repo)
        {
            Settings =  repo.LoadMonitorsSettings();
        }
        public object Clone()
        {
            return new MonitoringConfiguration()
            {
                Settings = this.Settings.Select(s => (MonitorSetting)s.Clone()).ToList()
            };
        }
    }
}
