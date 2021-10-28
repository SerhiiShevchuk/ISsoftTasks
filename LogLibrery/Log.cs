using System;
using System.Collections.Generic;
using Listener;

namespace Log
{
    public class Log : ILog
    {
        public string Name { get; set; }
       // public ILevel Threshold { get; set; }
        public List<IListener> Listener { get; set; } = new List<IListener>();

        public Log(LogSettings settings)
        {
            
        }

        public void LoadListeners()
        {

        }
    }
}
