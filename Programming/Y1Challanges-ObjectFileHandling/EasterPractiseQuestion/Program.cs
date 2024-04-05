using System;
using System.Globalization;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace EasterPractiseQuestion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Jakub\OneDrive - Atlantic TU\y1s2\Programming\Theory\faminefile.csv";
            string[] headers = new string[10];
            Menu menu = new Menu();

            List<TravelRecord> records = new List<TravelRecord>();
            records = WriteFileDataToConsole(path, ref headers);

            HashSet<string> validShipsIDs = new HashSet<string>();
            validShipsIDs = ValidShipsIDs(records);

            int option;

            do
            {
                option = menu.DisplayMenu();
                switch (option)
                {
                    case 1:
                        ShipReport(records, headers, validShipsIDs);
                        break;
                    case 2:
                        OccupationReport(records, validShipsIDs);
                        break;
                    case 3:
                        AgeReport(records, validShipsIDs, Menu.AgeCategories.ToArray());
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        break;
                }
            } while (option != 4);

        }
        static HashSet<string> ValidShipsIDs(List<TravelRecord> records)
        {
            HashSet<string> validShipsIds = new HashSet<string>();
            foreach (TravelRecord record in records)
            {
                validShipsIds.Add(record.Id);
            }

            return validShipsIds;
        }
        static void ShipReport(List<TravelRecord> records, string[] headers, HashSet<string> validShipsIDs)
        {
            foreach (string header in headers) 
            {
                Console.Write($"{header, TravelRecord.margin}");
            }
            Console.WriteLine();
            foreach (TravelRecord tr in records)
            {
                Console.WriteLine(tr.ToString());
            }

            Console.WriteLine("\nThese are valid Ship IDS : ");
            foreach (string id in validShipsIDs.ToList())
            {
                Console.WriteLine(id);
            }
            Console.WriteLine();

            string selectedShipID;
            do
            {
                Console.Write("Enter Ship id from list above : ");
                selectedShipID = Console.ReadLine().Trim();
            } while (!validShipsIDs.Contains(selectedShipID));

            foreach (TravelRecord record in records)
            {
                if(record.Id == selectedShipID)
                {
                    Console.WriteLine(record.DisplayFullName());
                }   
            }
        }
        static void OccupationReport(List<TravelRecord> records, HashSet<string> validShipsIDs)
        {
            Console.WriteLine("\nThese are valid Ship IDS : ");
            foreach (string id in validShipsIDs.ToList())
            {
                Console.WriteLine(id);
            }
            Console.WriteLine();

            string selectedShipID;
            do
            {
                Console.Write("Enter Ship id from list above : ");
                selectedShipID = Console.ReadLine().Trim();
            } while (!validShipsIDs.Contains(selectedShipID));

            // if there would be more ships it does count for every one of them
            int[] countOfPassengersPerShip = new int[validShipsIDs.Count];
            foreach (TravelRecord record in records)
            {
                for (int i = 0; i < validShipsIDs.Count; i++)
                {
                    if(record.Id == validShipsIDs.ToList()[i])
                    {
                        countOfPassengersPerShip[i]++;
                    }
                }
            }

            for (int i = 0; i < validShipsIDs.Count; i++)
            {
                if(selectedShipID == validShipsIDs.ToList()[i])
                {
                    Console.WriteLine($"{selectedShipID} has this many passangers : {countOfPassengersPerShip[i]}");
                }
            }
        }
        static void AgeReport(List<TravelRecord> records, HashSet<string> validShipsIDs, string[] ageCategories)
        {
            Console.WriteLine("\nThese are valid Ship IDS : ");
            foreach (string id in validShipsIDs.ToList())
            {
                Console.WriteLine(id);
            }
            Console.WriteLine();

            string selectedShipID;
            do
            {
                Console.Write("Enter Ship id from list above : ");
                selectedShipID = Console.ReadLine().Trim();
            } while (!validShipsIDs.Contains(selectedShipID));

            // Initialize the list of age reports, each report containing 6 fields (no infants included, changed to children 0-12)
            List<int[]> ageReportPerShip = new List<int[]>();

            for (int i = 0; i < validShipsIDs.Count; i++)
            {
                ageReportPerShip.Add(new int[ageCategories.Length]);   
            }

            foreach (TravelRecord record in records)
            {
                for (int i = 0; i < validShipsIDs.Count; i++)
                {
                    if(record.Id == validShipsIDs.ToList()[i])
                    {
                        ageReportPerShip[i][GetAgeIndex(record.Age)]++;
                    }
                }
            }


            // Displaying age report:
            int[] totalCountPerShip = new int[validShipsIDs.Count];
            int indexOfSelectedShip = 0;
            for (int i = 0; i < validShipsIDs.Count; i++)
            {
                if(selectedShipID == validShipsIDs.ToList()[i])
                {
                    indexOfSelectedShip = i;
                    for(int j = 0; j < ageCategories.Length; j++)
                    {
                        Console.WriteLine($"{ageCategories[j],-30}{ageReportPerShip[i][j]}");
                        totalCountPerShip[i] += ageReportPerShip[i][j];
                    }
                }
            }
            Console.WriteLine($"{"Total count",-30}{totalCountPerShip[indexOfSelectedShip]}");
            Console.WriteLine();
        }
        static int GetAgeIndex(int age)
        {
            // no infants, changed to children 0 - 12
            switch (age)
            {
                case >= 0 and <= 12: return 0;
                case > 12 and <= 19: return 1;
                case > 19 and <= 29: return 2;
                case > 29 and <= 50: return 3;
                case > 50: return 4;
                case -1: return 5;
                default: return -1;
            }
        }
        static List<TravelRecord> WriteFileDataToConsole(string fileName, ref string[] headers)
        {
            string[] linesData = new string[headers.Length];
            List<TravelRecord> data = new List<TravelRecord>();
            int count = 0;

            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        linesData = line.Split(",");
                        if (count == 0)
                        {
                            headers = linesData;
                        }
                        else
                        {
                            string lastName, firstName, sexCode, occupationCode, nativeCountryCode, destination, passengerPortOfEmbarkationCode, id;
                            int age;
                            DateOnly arrivalDate;

                            if (linesData.Length == headers.Length && !string.IsNullOrEmpty(linesData[0]) && !string.IsNullOrEmpty(linesData[1])
                               && !string.IsNullOrEmpty(linesData[2]) && !string.IsNullOrEmpty(linesData[3]) && !string.IsNullOrEmpty(linesData[4])
                               && !string.IsNullOrEmpty(linesData[5]) && !string.IsNullOrEmpty(linesData[6]) && !string.IsNullOrEmpty(linesData[7])
                               && !string.IsNullOrEmpty(linesData[8])
                               && DateOnly.TryParse(linesData[9], CultureInfo.GetCultureInfo("us-EN"), DateTimeStyles.None, out arrivalDate))
                            {
                                lastName = linesData[0];
                                firstName = linesData[1];

                                if (int.TryParse(linesData[2].Remove(0, 4), out age)){ // age 24
                                    age = int.Parse(linesData[2].Remove(0, 4));
                                }
                                else // Unknown
                                {
                                    age = -1;
                                }
                               
                                sexCode = linesData[3];
                                occupationCode = linesData[4];
                                nativeCountryCode = linesData[5];
                                destination = linesData[6];
                                passengerPortOfEmbarkationCode = linesData[7];
                                id = linesData[8];
                                arrivalDate = DateOnly.Parse(linesData[9], CultureInfo.GetCultureInfo("us-EN"), DateTimeStyles.None);

                                data.Add(new TravelRecord(lastName, firstName, age, sexCode, occupationCode, nativeCountryCode, destination, passengerPortOfEmbarkationCode, id, arrivalDate));
                            }
                            else
                            {
                                Console.WriteLine($"Something went wrong, when reading a file : {linesData[0]} {linesData[1]}");
                            }
                        }
                        count++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Could not opne file. Check if file exists.");
            }
           
            return data;
        }
}
}
