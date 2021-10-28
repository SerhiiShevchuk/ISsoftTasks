using System;
using System.Timers;

namespace SensorLibrary
{
    class WorkState : SensorState
    {
        public override void IncreaseMeasuredValue()
        {
            _sensor._timer.Dispose();

            _sensor._timer = new Timer(_sensor.Interval);
            _sensor._timer.Elapsed += (sender, e) => { _sensor.MeasuredValue += new Random().Next(0, 10); };
            _sensor._timer.Start();
        }
        public override void ChangeMode()
        {
            _sensor.TransitionTo(new SimpleState());
        }
    }
}