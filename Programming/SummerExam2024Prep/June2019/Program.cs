using System;
using System.IO;
namespace June2019
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Jakub\OneDrive - Atlantic TU\y1s2\Programming\SummerExamsPrep\June2019\claims.csv";
            Claims claims = new Claims(FileHandler.ReadClaimsData(path));
            FileHandler.DisplayData(claims.ClaimsList);
            Console.WriteLine();
            claims.DisplayStatisticsTable();
        }
    }
}
