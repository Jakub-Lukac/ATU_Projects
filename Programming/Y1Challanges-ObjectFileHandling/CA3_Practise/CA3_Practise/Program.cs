using System;
using System.Collections.Generic;
using System.Globalization;
namespace CA3_Practise
{
    internal class Program
    {
        const string INPUT_TABLE = "{0,-40}{1,1}";
        const int margin = -30;
        static void Main(string[] args)
        {

            // CultureInfo.InvariantCulture
            // make object called Report
            // containing 3 fields
            // list of report objects
            // set of report object, only unique country field
            // loop through each report object and inside report through set, find match (index), increment count and calculate new total

            const string SENTINEL_VALUE = "-999";
            string path = @"C:\Users\Jakub\OneDrive - Atlantic TU\y1s2\Programming\Theory\eurostat.csv";
            List<Record> statisticsData = new List<Record>();
            HashSet<string> countries = new HashSet<string>();
            string selectedCountry;

            statisticsData = WriteDataToConsole(path);
            countries = GetListOfValidCountries(statisticsData);

            double[] totalRiskPerCountry = new double[countries.Count];
            double[] averageRiskPerCountry = new double[countries.Count];
            int[] countOfCountry = new int[countries.Count];

            do
            {
                selectedCountry = ValidateCountry(countries, SENTINEL_VALUE);
                if(selectedCountry != SENTINEL_VALUE)
                {
                    CountryReport(statisticsData, selectedCountry);
                }
            } while (selectedCountry != SENTINEL_VALUE);

            totalRiskPerCountry = CalculateTotalRiskPerCountry(statisticsData, countries, ref countOfCountry);

            averageRiskPerCountry = CalculateAverageRiskPerCountry(totalRiskPerCountry, countOfCountry);

            DisplayAverage(countries, averageRiskPerCountry);
        }
        static void DisplayAverage(HashSet<string> countries, double[] averageRiskPerCountry)
        {
            for (int i = 0; i < averageRiskPerCountry.Length; i++)
            {
                Console.WriteLine($"{countries.ToList()[i],margin}{averageRiskPerCountry[i]}");
            }
        }
        static double[] CalculateAverageRiskPerCountry(double[] total, int[] count)
        {
            double[] average = new double[total.Length];
            for (int i = 0; i < average.Length; i++)
            {
                average[i] = total[i] / count[i];
            }
            return average;
        }
        static double[] CalculateTotalRiskPerCountry(List<Record> statisticsData, HashSet<string> countries, ref int[] count)
        {
            double[] total = new double[countries.Count];
            for (int i = 0; i < statisticsData.Count; i++)
            {
                for (int j = 0; j < countries.Count; j++)
                {
                    if (statisticsData[i].Country == countries.ToList()[j])
                    {
                        total[j] += statisticsData[i].RiskLevel;
                        count[j]++;
                    }
                }
            }
            return total;
        }
        static void CountryReport(List<Record> statisticsData, string selectedCountry)
        {
            foreach (Record record in statisticsData)
            {
                if(record.Country == selectedCountry)
                {
                    Console.WriteLine($"{record.Year,margin}{record.RiskLevel}");
                }
            }
        }
        static string ValidateCountry(HashSet<string> validCountries, string SENTINEL_VALUE)
        {
            string enteredCountry;
            do
            {
                do
                {
                    Console.Write(INPUT_TABLE, "Enter country", ": ");
                    enteredCountry = Console.ReadLine().Trim().ToLower();
                } while (string.IsNullOrEmpty(enteredCountry));

                if(enteredCountry == SENTINEL_VALUE)
                {
                    return SENTINEL_VALUE;
                }

                // capitalizing first letter and then checking
                enteredCountry = enteredCountry.Substring(0, 1).ToUpper() + enteredCountry.Remove(0, 1);
            } while (!validCountries.Contains(enteredCountry));

            return enteredCountry;
        }
        static HashSet<string> GetListOfValidCountries(List<Record> data)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var record in data)
            {
                set.Add(record.Country);
            }
            return set;
        }
        static List<Record> WriteDataToConsole(string path)
        {
            List<Record> data = new List<Record>();
            string[] linesData = new string[3];

            using (StreamReader sr = File.OpenText(path))
            {
                string line;
                int year;
                string country;
                double riskLevel;
                while ((line = sr.ReadLine()) != null)
                {
                    linesData = line.Split(",");

                    if(linesData.Length == 3 && int.TryParse(linesData[0], out year) 
                        && !string.IsNullOrWhiteSpace(linesData[1]) 
                        && double.TryParse(linesData[2], CultureInfo.InvariantCulture, out riskLevel)
                    ) 
                    {
                        year = int.Parse(linesData[0], CultureInfo.InvariantCulture);
                        country = linesData[1];
                        riskLevel = double.Parse(linesData[2], CultureInfo.InvariantCulture);

                        data.Add(new Record(year, country, riskLevel));
                    }
                    else
                    {
                        Console.WriteLine("Error occured in reading the file. Check values!");
                    }
                }
            }

            return data;
        }
    }
    public class Record
    {
        private int _year;
        private string _country;
        private double _riskLevel;

        public Record(int year, string country, double riskLevel)
        {
            Year = year;
            Country = country;
            RiskLevel = riskLevel;
        }

        public int Year { get => _year; set => _year = value; }
        public string Country { get => _country; set => _country = value; }
        public double RiskLevel { get => _riskLevel; set => _riskLevel = value; }
    }
}
