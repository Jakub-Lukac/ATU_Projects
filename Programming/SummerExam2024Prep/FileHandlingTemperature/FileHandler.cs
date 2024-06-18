/*
 * Author : Jakub Lukac
 * Date : 22/04/2024
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using June2023;

namespace FileHandlingTemperature
{
    public class FileHandler
    {
        static public List<City> ReadCityData(string path)
        {
            List<City> cities = new List<City>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            string[] linesData = line.Split(",");
                            string id, name;
                            double temp;

                            if (linesData.Length == 3 && !string.IsNullOrEmpty(linesData[0]) && !string.IsNullOrEmpty(linesData[1])
                                && double.TryParse(linesData[2], CultureInfo.InvariantCulture, out temp))
                            {
                                
                                id = linesData[0].Trim();
                                // make first letter capital
                                name = linesData[1].Trim();
                                temp = double.Parse(linesData[2].Trim(), CultureInfo.InvariantCulture);

                                cities.Add(new City(id, name, temp));
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error occurred in reading the file. Check all the values!");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error parsing line: {line}. Details: {e.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"An error occurred on line {line}: {ex.Message}");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception(ex.Message);
            }

           return cities;
        }

        static public void DisplayData(List<City> cities)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Table.InitTable();
            foreach (City c in cities)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
