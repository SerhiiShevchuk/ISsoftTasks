namespace SensorLibrary
{
    public abstract class SensorState
    {
        protected Sensor _sensor;
        public void SetSensor(Sensor sensor)
        {
            _sensor = sensor;
        }

        public abstract void IncreaseMeasuredValue();
        public abstract void ChangeMode();
    }
}