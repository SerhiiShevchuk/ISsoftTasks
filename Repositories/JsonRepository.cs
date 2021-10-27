using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;

namespace Task_NET02_4.Repositories
{
    class JsonRepository : IRepo
    {
        public List<MonitorSetting> LoadMonitorsSettings()
        {
            List<MonitorSetting> setting = null;
            using (StreamReader sr = new StreamReader(_path))
            {
                var str = sr.ReadToEnd();
                setting =  JsonSerializer.Deserialize<List<MonitorSetting>>(str);
            }
            return setting;
        }

        public async void SaveMonitorSettings(List<MonitorSetting> settings)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<MonitorSetting>>(fs, settings, options);
            }
        }

        private string _path = @"..\..\..\Configs\MonitoringConfig.json";
    }
}
