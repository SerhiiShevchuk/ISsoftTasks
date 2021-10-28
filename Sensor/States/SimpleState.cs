namespace SensorLibrary
{
    class SimpleState : SensorState
    {
        public override void IncreaseMeasuredValue()
        {
            _sensor._timer.Dispose();
        }
        public override void ChangeMode()
        {
            _sensor.TransitionTo(new CalibrationState());
            _sensor.SequentialSwitching();
        }
    }
}
