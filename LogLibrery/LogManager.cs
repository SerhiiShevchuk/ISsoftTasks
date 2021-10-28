using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using Configuration;

namespace Log
{
    public class LogManager
    {
        public ILog GetLogger()
        {
            string str = Directory.GetCurrentDirectory();
            Console.WriteLine(str);

            var assemblyName = ConfigurationManager.AppSettings.Get("logAssemblyName");
            var assembly = LoadAssembly(assemblyName);

            LogConfiguration logConfig = new LogConfiguration();
            logConfig.GetSettings(new LogJsonRepo());

            Type type = assembly.GetType($"Log.Log");

            return (ILog)Activator.CreateInstance(type, logConfig.Settings);
        }
        private Assembly LoadAssembly(string assemblyName)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom($"{assemblyName}.dll");
                return assembly;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"{assemblyName}.dll was not found");
                return null;
            }
        }
    }
}
