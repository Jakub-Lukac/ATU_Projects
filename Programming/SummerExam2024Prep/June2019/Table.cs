using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2019
{
    public class Table
    {
        public const int MARGIN = -20;
        public static readonly string[] _headers = { "Customer Number", "Date", "Claim Type", "Amount" };
        public static readonly string[] _stats = { "Claim Type", "Total Claims", "Total Value"};
        static public void InitTable(string[] headers)
        {
            foreach (string h in headers)
            {
                Console.Write($"{h, MARGIN}");
            }
            Console.WriteLine();
        }
    }
}
