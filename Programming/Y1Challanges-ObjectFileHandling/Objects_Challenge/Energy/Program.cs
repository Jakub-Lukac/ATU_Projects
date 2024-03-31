using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Energy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Jakub\OneDrive - Atlantic TU\y1s2\Programming\Theory\energy.csv";

            List<string[]> listOfEnergyData = new List<string[]>();
            double[] totalEnergyPerYear = new double[22];
            double[] averageEnergyPerYear = new double[totalEnergyPerYear.Length];
            double[] totalPerCountry = new double[29];
            string[] headers = new string[22];

            listOfEnergyData = WriteFileDataToConsole(path, ref headers);
            totalEnergyPerYear = CalculateTotalPerYear(listOfEnergyData);
            averageEnergyPerYear = CalculateAveragePerYear(totalEnergyPerYear);
            totalPerCountry = CalculateTotalPerCountry(listOfEnergyData);

            DisplayAveragePerYear(headers, averageEnergyPerYear);
            DisplayTotalPerCountry(listOfEnergyData, totalPerCountry);

            MaxPerCountry(totalPerCountry, listOfEnergyData);
            LowestPerCountry(totalPerCountry, listOfEnergyData);

            LowestYearPerCountry(listOfEnergyData, headers);
        }
        static void LowestYearPerCountry(List<string[]> data, string[] headers)
        {
            Console.WriteLine("\nLowest Year Per Country : \n");
            double min = 0;
            for (int i = 0; i < data.Count; i++)
            {
                int index = 1;
                min = double.Parse(data[i][1]);
                for (int j = 1; j < data[i].Length; j++)
                {
                    double value = double.Parse(data[i][j]);
                    if (value < min)
                    {
                        min = value;
                        index = j;
                    }
                }
                Console.WriteLine($"{data[i][0], -70}{headers[index],-30}{min}");
            }
        }
        static void LowestPerCountry(double[] totalPerCountry, List<string[]> listOfEnergyData)
        {
            int index = 0;
            double min = totalPerCountry[0];
            for (int i = 0; i < totalPerCountry.Length; i++)
            {
                if (totalPerCountry[i] < min)
                {
                    min = totalPerCountry[i];
                    index = i;
                }
            }
            Console.WriteLine($"\nLowest Per Country : \n{listOfEnergyData[index][0],-70}{totalPerCountry[index]}");
        }
        static void MaxPerCountry(double[] totalPerCountry, List<string[]> listOfEnergyData)
        {
            int index = 0;
            double max = totalPerCountry[0];
            for (int i = 0; i < totalPerCountry.Length; i++)
            {
                if (totalPerCountry[i] > max)
                {
                    max = totalPerCountry[i];
                    index = i;
                }
            }
            Console.WriteLine($"\nMax Per Country : \n{listOfEnergyData[index][0],-70}{totalPerCountry[index]}");
        }

        static void DisplayTotalPerCountry(List<string[]> listOfEnergyData, double[] totalPerCountry)
        {
            Console.WriteLine("\n\n");
            for (int i = 0; i < totalPerCountry.Length; i++)
            {
                Console.WriteLine($"{listOfEnergyData[i][0],-70}{totalPerCountry[i]}");
            }
        }
        static double[] CalculateTotalPerCountry(List<string[]> data)
        {
            double[] totalPerCountry = new double[data.Count];
            for (int i = 0; i < totalPerCountry.Length; i++)
            {
                for (int j = 1; j < data[i].Length; j++)
                {
                    totalPerCountry[i] += double.Parse(data[i][j]);
                }
            }
            return totalPerCountry;
        }
        static void DisplayAveragePerYear(string[] headers, double[] averageEnergyPerYear)
        {
            for (int i = 1; i < averageEnergyPerYear.Length; i++)
            {
                Console.WriteLine($"{headers[i],- 30}{averageEnergyPerYear[i]}");
            }
        }
        static double[] CalculateAveragePerYear(double[] totalEnergyPerYear)
        {
            double[] averagePerYear = new double[totalEnergyPerYear.Length];
            for (int i = 0; i < averagePerYear.Length; i++)
            {
                averagePerYear[i] = totalEnergyPerYear[i] / totalEnergyPerYear.Length;
            }
            return averagePerYear;
        }
        static double[] CalculateTotalPerYear(List<string[]> data)
        {
            double[] totalPerYear = new double[data[0].Length];
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 1; j < data[i].Length; j++)
                {
                    totalPerYear[j] += double.Parse(data[i][j]);
                }
            }
            return totalPerYear;
        }
        static List<string[]> WriteFileDataToConsole(string fileName, ref string[] headers)
        {
            string[] linesData = new string[22];
            List<string[]> data = new List<string[]>();
            int count = 0;

            using (StreamReader sr = File.OpenText(fileName))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    linesData = line.Split(",");
                    if(count == 0)
                    {
                        headers = linesData;
                    }
                    else
                    {
                        data.Add(linesData);
                    }
                    count++;
                }
            }
            return data;
        }
    }
}
