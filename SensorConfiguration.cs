using System.Collections.Generic;

namespace SensorLibrary
{
    class SensorConfiguration
    {
        public List<Sensor> Sensors { get; set; }

        public void GetSensors(IRepository repo)
        {
            Sensors = repo.LoadSensors();
        }
    }
}