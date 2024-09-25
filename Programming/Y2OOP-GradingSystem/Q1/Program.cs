/*
 * Name : Jakub Lukac
 * ID: S00255726
 * Date: 23/09/2024
 */
using System;
namespace Q1 // and Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\results.txt"; // starting point for exec is bin/Debug/net8.0/.exe
            List<int> percentages = FileHandler.ReadPercentagesData(path);
            int totalPoints = 0;

            //  Q2 foreach loop
            foreach (int p in percentages)
            {
                totalPoints += PercentageToPoints(p);
            }

            FileHandler.WriteToFile(path, percentages.Count, totalPoints);
        }

        static int PercentageToPoints(int percentage)
        {
            // value higher than 100 or lower than 0 wont be passed into this method, hence no need to check this case
            if (percentage >= 90)
            {
                return 100;
            }
            else if (percentage >= 80)
            {
                return 88;
            }
            else if (percentage >= 70)
            {
                return 77;
            }
            else if (percentage >= 60)
            {
                return 66;
            }
            else if (percentage >= 50)
            {
                return 56;
            }
            else if (percentage >= 40)
            {
                return 46;
            }
            else if (percentage >= 30)
            {
                return 37;
            }
            else
            {
                return 0;
            }
        }
    }
}
