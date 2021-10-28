using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Log;
namespace Task_NET02_3
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager l = new LogManager();
            l.GetLogger();
        }
    }
}
