using System;
namespace French_Navy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for correct outputing of names
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string path = @"C:\Users\Jakub\OneDrive - Atlantic TU\y1s2\Programming\Theory\FrenchMF.txt";

            List<Vessel> vessels = new List<Vessel>();
            Menu menu = new Menu();

            int selectedChoice;

            vessels = WriteDataIntoConsole(path);
            Fleet fleet = new Fleet(vessels);

            do
            {
                selectedChoice = menu.DisplayMenu();
                switch (selectedChoice)
                {
                    case 1:
                        fleet.VesselReport();
                        break;
                    case 2:
                        fleet.LocationAnalysisReport();
                        break;
                    case 3:
                        fleet.Search();
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        break;
                }
            } while (selectedChoice != 4);
        }
        static List<Vessel> WriteDataIntoConsole(string path)
        {
            List<Vessel> data = new List<Vessel>();

            using (StreamReader sr = File.OpenText(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        string[] linesData = line.Split(",");

                        if (linesData.Length == 5 && !string.IsNullOrEmpty(linesData[0]))
                        {
                            string vesselName = linesData[0];
                            int vesselType = int.Parse(linesData[1]);
                            int vesselTonage = int.Parse(linesData[2]);
                            int vesselCrew = int.Parse(linesData[3]);
                            int vesselLocationCode = int.Parse(linesData[4]);

                            data.Add(new Vessel(vesselName, vesselType, vesselTonage, vesselCrew, vesselLocationCode));
                        }
                        else
                        {
                            Console.WriteLine("Error occurred in reading the file. Check all the values!");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Error parsing line: {line}. Details: {e.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }

            return data;
        }
    }
}
