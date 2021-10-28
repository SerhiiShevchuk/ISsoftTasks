using System;
using System.Timers;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace SensorLibrary
{
    public class Sensor : ISubject
    {
        public SensorType SensorType { get; set; }
        public int Interval { get; set; }
        private SensorState _sensorState;

        [JsonIgnore]
        private List<IObserver> _observers = new List<IObserver>();
        [JsonIgnore]
        public Timer _timer;
        [JsonIgnore]
        private int _measuredValue;
        [JsonIgnore]
        public int MeasuredValue 
        {
            get
            {
                return _measuredValue;
            }
            set
            {
                _measuredValue = value;
                Notify();
            }
        }
        [JsonIgnore]
        private Guid _guid;
        [JsonIgnore]
        public Guid Guid 
        { 
            get 
            { 
                return _guid; 
            } 
            set 
            {
                _guid = value;
            }
        }
        public Sensor(SensorState state)
        {
            _sensorState = state;
        }
        public void TransitionTo(SensorState type)
        {
            _sensorState = type;
            _sensorState.SetSensor(this);
            _sensorState.IncreaseMeasuredValue();
        }
        public void Start()
        {
            _sensorState.IncreaseMeasuredValue();
        }
        public void SequentialSwitching()
        {
            _sensorState.ChangeMode();
        }
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            };
        }
    }
}