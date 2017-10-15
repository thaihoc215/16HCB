using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("x = ");
            string strX = Console.ReadLine();

            Console.Write("y = ");
            string strY = Console.ReadLine();

            int x = Convert.ToInt32(strX);
            int y = Convert.ToInt32(strY);

            var c = new SimpleServiceProxy.SimpleService();
            int s = c.Sum(x, y, 9);

            Console.WriteLine("s = {0}", s);
        }
    }
}
