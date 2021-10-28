using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SensorLibrary
{
    class XmlRepo : IRepository
    {
        public List<Sensor> LoadSensors()
        {
            XDocument xdoc = LoadFile();

            var c = xdoc.Element("config").Elements("sensor")
                    .Select(u => new Sensor(GetSensorState(u.Element("state").Value))
                    {
                        Guid = IdGenerator.GenerateId(),
                        Interval = int.Parse(u.Element("interval").Value),
                        SensorType = GetSensorType(u.Element("type").Value)
                    });

            return c.ToList();
        }
        private XDocument LoadFile()
        {
            try
            {
                return XDocument.Load(_path);
            }
            catch (Exception)
            {
                Console.WriteLine($"{_path} was not found");
                return null;
            }
        }
        private SensorType GetSensorType(string str)
        {
            SensorType.Magnetic.ToString();
            switch (str)
            {
                case "Magnetic":
                    return SensorType.Magnetic;
                case "Pressure":
                    return SensorType.Pressure;
                case "Temperature":
                    return SensorType.Temperature;
                default:
                    throw new Exception("Repository type is invalid");
            }
        }
        private SensorState GetSensorState(string state)
        {
            switch (state)
            {
                case "Work":
                    return new WorkState();
                case "Simple":
                    return new SimpleState();
                case "Calibration":
                    return new CalibrationState();
                default:
                    throw new Exception("Repository type is invalid");
            }
        }

        private string _path = @"..\..\..\Configs\SensorsConfig.xml";
    }
}
