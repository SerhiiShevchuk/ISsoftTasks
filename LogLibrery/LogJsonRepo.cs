using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Log
{
    class LogJsonRepo : ILogRepo
    {
        public LogSettings LoadSettings()
        {
            using (FileStream json = new FileStream(_path, FileMode.OpenOrCreate))
            {

                return JsonSerializer.DeserializeAsync<LogSettings>(json).Result;
            }
        }

        private string _path = @"..\..\..\Config\LogSettings.json";
    }
}
