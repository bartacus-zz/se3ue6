using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    class Logger
    {
        public void Log(object o, WorkerEventArgs e)
        {
            Console.WriteLine("[{0}]: {1}", e.Name, e.Message);
        }
    }
}
