using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SensorLibrary
{
    class JsonRepo : IRepository
    {
        public List<Sensor> LoadSensors()
        {
            List<Sensor> setting = null;
            using (StreamReader sr = new StreamReader(_path))
            {
                var str = sr.ReadToEnd();
                setting = JsonSerializer.Deserialize<List<Sensor>>(str);
            }
            return setting;
        }   

        public async void SaveSensors(List<Sensor> sensors)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<Sensor>>(fs, sensors, options);
            }
        }

        private string _path = @"..\..\..\Configs\SensorsConfig.json";
    }
}
