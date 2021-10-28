using System.Collections.Generic;

namespace SensorLibrary
{
    public interface IRepository
    {
        public List<Sensor> LoadSensors();
    }
}
