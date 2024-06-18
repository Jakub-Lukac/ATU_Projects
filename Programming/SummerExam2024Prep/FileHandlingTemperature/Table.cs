using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2023
{
    public class Table
    {
        private const int MARGIN = -20;
        private static readonly string[] _headers = { "#", "Name", "Temperature" };
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
