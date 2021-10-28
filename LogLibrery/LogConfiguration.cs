using System;
using Log;
using System.Collections.Generic;
using System.Reflection;

namespace Configuration
{
    public class LogConfiguration
    {
        public LogSettings Settings;
        
        public void GetSettings(ILogRepo repo)
        {
            Settings = repo.LoadSettings();
        }
    }
}
