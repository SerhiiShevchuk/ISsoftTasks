using System.Timers;

namespace SensorLibrary
{
    class CalibrationState : SensorState
    {
        public override void IncreaseMeasuredValue()
        {
            _sensor._timer.Dispose();

            int i = 0;
            _sensor._timer = new Timer(1000);
            _sensor._timer.Elapsed += (sender, e) => { _sensor.MeasuredValue += i++; };
            _sensor._timer.Start();
        }
        public override void ChangeMode()
        {
            _sensor.TransitionTo(new WorkState());
            _sensor.SequentialSwitching();
        }
    }
}