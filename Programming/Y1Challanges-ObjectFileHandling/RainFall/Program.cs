using System;
using System.Globalization;
namespace RainFall
{
    internal class Program
    {
        const int margin = -45;
        static void Main(string[] args)
        {
            string path = @"C:\Users\Jakub\OneDrive - Atlantic TU\y1s2\Programming\Theory\sligoRainfall.csv";
            List<string[]> rainData = new List<string[]>();
            string[] labelsRange = { "0-3", "3-7", "7-10", "10+" };
            int[] range = new int[labelsRange.Length];
            int[] rangeOfRain = new int[labelsRange.Length];    

            rainData = WriteDataToConsole(path, ref range);
            DisplayData(rainData);  

            rangeOfRain = Range(rainData, ref rangeOfRain);
            DisplayRange(labelsRange, rangeOfRain);
        }
        static void DisplayRange(string[] labels, int[] range)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < labels.Length; i++)
            {
                Console.WriteLine($"{labels[i],margin}{range[i]}");
            }
        }
        static int[] Range(List<string[]> data, ref int[] range) 
        {
            double value;
            for (int i = 0; i < data.Count; i++)
            {
                    value = double.Parse(data[i][1], CultureInfo.InvariantCulture);
                    if(value >= 0 && value <= 3)
                    {
                        range[0]++;
                    }
                    else if(value > 3 && value <= 7)
                    {
                        range[1]++;
                    }
                    else if(value > 7 && value <= 10)
                    {
                        range[2]++;
                    }
                    else
                    {
                        range[3]++;
                    }
            }
            return range;
        }
        /*static int DetermineRangeIndex(double rain)
        {
            switch (rain)
            {
                case double r when r >= 0 && r <= 3: return 0;
                case double r when r > 3 && r <= 7: return 1;
                case double r when r > 7 && r <= 10: return 2;
                case double r when r > 10 : return 3;
                default: return -1;
            }
        }*/
        static void DisplayData(List<string[]> rainData)
        {
            for (int i = 0; i < rainData.Count; i++)
            {
                for (int j = 0; j < rainData[i].Length; j++)
                {
                    Console.Write($"{rainData[i][j], margin}");
                }
                Console.WriteLine();
            }
        }
        static List<string[]> WriteDataToConsole(string path, ref int[] range)
        {
            List<string[]> data = new List<string[]>();
            string[] linesData = new string[2];

            using (StreamReader sr = File.OpenText(path))
            {
                string line;
                int index;
                while ((line = sr.ReadLine()) != null)
                {
                    linesData = line.Split(",");
                    DateOnly date;
                    double rainValue;
                    if(linesData.Length == 2 && DateOnly.TryParse(linesData[0], out date) && double.TryParse(linesData[1], CultureInfo.InvariantCulture, out rainValue) && double.Parse(linesData[1], CultureInfo.InvariantCulture) >= 0) 
                    {
                        data.Add(linesData);
                        /*index = DetermineRangeIndex(double.Parse(linesData[1], CultureInfo.InvariantCulture));
                        range[index]++;*/
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input {linesData}");
                    }
                }
            }
            return data;
        }
    }
}
