/*
 * Name : Jakub Lukac
 * ID: S00255726
 * Date: 23/09/2024
 */
using System;
namespace Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\results.txt"; // starting point for exec is bin/Debug/net8.0/.exe
            List<int> percentages = FileHandler.ReadPercentagesData(path);
            int totalPoints = 0;

            // Q3 part

            int[] boundries = { 90, 80, 70, 60, 50, 40, 30, 0 }; // maybe no need for 0?
            int[] points = { 100, 88, 77, 66, 56, 46, 37, 0 }; // maybe no need for 0?

            totalPoints = CalculateTotalPoints(percentages, boundries, points);

            Console.WriteLine($"Total number of points for {percentages.Count} subjects is : {totalPoints}");
        }
        static int CalculateTotalPoints(List<int> percentages, int[] boundries, int[] points) 
        {
            int totalPoints = 0;
            //  Q2 foreach loop
            foreach (int p in percentages)
            {
                for (int i = 0; i < boundries.Length; i++) 
                {
                    if (p >= boundries[i]) 
                    {
                        totalPoints += points[i];
                        break; // once we find the first match we exit the loop - ask lecturer about it (if it is a good practise?)
                    }
                }
            }
            return totalPoints;
        }
    }
}
