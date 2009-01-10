using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace A1
{
    class Program
    {
        static void Main(string[] args)
        {
            Lager lager = new Lager(50);
            lager.Run(); 

            Console.ReadLine();
        }
    }
}
