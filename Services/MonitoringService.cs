using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_NET02_4.Repositories;

namespace Task_NET02_4
{
    class MonitoringService
    {
        private List<Monitor> _monitors = new();
        private MonitoringConfiguration _configuration = new MonitoringConfiguration();

        public void Start()
        {
            _configuration.GetMonitorSettings(new JsonRepository());

            using var watcher = new FileSystemWatcher(@"..\..\..\Configs");
            watcher.Filter = "MonitoringConfig.json";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += UpdateMonitors;


            foreach (var setting in _configuration.Settings)
            {
                Monitor monitor = new Monitor(setting);
                _monitors.Add(monitor);

                monitor.Start();
            }
        }

        private void UpdateMonitors(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            
            MonitoringConfiguration oldConfiguration = (MonitoringConfiguration)_configuration.Clone();
            _configuration.GetMonitorSettings(new JsonRepository());

            var newSettings = _configuration.Settings.Except(oldConfiguration.Settings);
            var usedMonitors = _monitors.Where(m => _configuration.Settings.All(c => c != m._setting));

            if (usedMonitors != null)
            {
                foreach (var usedMonitor in usedMonitors)
                {
                    usedMonitor._timer.Stop();
                    _monitors.Remove(usedMonitor);
                }
            }
            if (newSettings != null)
            {
                foreach (var setting in newSettings)
                {
                    Monitor newMonitor = new Monitor(setting);
                    _monitors.Add(newMonitor);
                    newMonitor.Start();
                }
                Console.WriteLine($"Changed:");
            }
        }
    }
}
