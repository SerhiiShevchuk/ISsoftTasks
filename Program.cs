using System;
using System.Threading;

namespace Task_NET02_4
{
    class Program
    {
        public static void RunProgram()
        {
            MonitoringService service = new MonitoringService();
            service.Start();

            Console.ReadKey();
        }
       
        static void Main(string[] args)
        {
            using (var mutex = new Mutex(false, "mainMutex"))
            {
                if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
                {
                    Console.WriteLine("Another instance is running");
                    Console.ReadKey();
                }
                Console.WriteLine("Running proces");

                RunProgram();
            }
        }
    }
}
