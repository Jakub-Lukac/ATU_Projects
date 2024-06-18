using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2019
{
    static public class Table
    {
        public const int MARGIN = -20;
        public static readonly string[] _headers = { "ID", "Fuel Tank Size", "Efficiency", "Calc Range", "Battery Range" };
        static public void InitTable()
        {
            foreach (string h in _headers)
            {
                Console.Write($"{h, MARGIN}");
            }
            Console.WriteLine();
        }
    }
}
