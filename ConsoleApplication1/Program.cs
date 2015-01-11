using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> dd = new List<double> { 7, 6, 7, 5, 5, 6, 6, 7, 6 };

            List<double> ddd = new List<double> { 5, 6, 6, 4, 5, 6, 6, 6, 4 };
            for (int i = 0; i < dd.Count; i++)
            {
                Console.WriteLine((dd[i] - ddd[i]) / dd[i]);
            }
        }
    }
}
