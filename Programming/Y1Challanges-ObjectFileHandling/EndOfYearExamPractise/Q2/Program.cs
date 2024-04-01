using System;
using System.Globalization;
namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Jakub\OneDrive - Atlantic TU\y1s2\Programming\Theory\cities.csv";
            const string continueInProgram = "yes";

            Cities cities = new Cities(WriteDataToConsole(path));

            string searchAgain;

            do
            {
                cities.Search();
                searchAgain = cities.SearchAgain();
            } while (searchAgain == continueInProgram);
        }
        static List<City> WriteDataToConsole(string path)
        {
            List<City> data = new List<City>();
            string[] linesData = new string[3];

            using (StreamReader sr = File.OpenText(path))
            {
                try
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        linesData = line.Split(",");
                        int id;
                        string cityName;
                        double temperature;
                        if (linesData.Length == 3 && int.TryParse(linesData[0], out id) && !string.IsNullOrEmpty(linesData[1]) && double.TryParse(linesData[2], CultureInfo.InvariantCulture, out temperature))
                        {
                            id = int.Parse(linesData[0]);
                            cityName = linesData[1].Trim();
                            temperature = double.Parse(linesData[2], CultureInfo.InvariantCulture);

                            data.Add(new City(id, cityName, temperature));
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input {linesData}");
                        }
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            return data;
        }
    }    
}
