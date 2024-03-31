using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace French_Navy
{
    public class Fleet
    {
        private const int margin = -25;

        private List<Vessel> _vessels;
        private int[] _costPerCrewMember;
        private string[] _vesselFunction;
        private string[] _locationNames;

        public Fleet(List<Vessel> vessels)
        {
            _costPerCrewMember = new int[6] {2610, 2350, 2050, 999, 2550, 2510 };
            _vesselFunction = new string[6] { "Aircraft carrier", "Cruiser/Battleship", "Destroyer", "Frigate", 
                "Nuclear Submarine", "Minelayer/Sweeper" };
            Vessels = vessels;
            _locationNames = new string[5] { "The Pacific", "The Atlantic", "The Mediterranean", "The Indian Ocean", "The Other Seas +" };
        }

        public void VesselReport()
        {
            List<List<Vessel>> orderByLocationCode = new List<List<Vessel>>();
            int totalTonnage = 0,totalCrew = 0, totalMonthlyCost = 0;
            string[] headers = new string[6] {"Location", "Function", "Vessel Name", "Tonnage", "Crew", "Mnth Cost"};

            // Initialize the list with 5 empty lists
            for (int i = 0; i < 5; i++)
            {
                orderByLocationCode.Add(new List<Vessel>());
            }

            for (int i = 0; i < Vessels.Count; i++)
            {
                Vessel v = Vessels[i];
                switch (v.LocationCode)
                {
                    case 1:
                        orderByLocationCode[0].Add(v);
                        break;
                    case 2:
                        orderByLocationCode[1].Add(v);
                        break;
                    case 3:
                        orderByLocationCode[2].Add(v);
                        break;
                    case 4:
                        orderByLocationCode[3].Add(v);
                        break;
                    case 5:
                        orderByLocationCode[4].Add(v);
                        break;
                }
            }

            // Displaying each location
            for (int i = 0; i < orderByLocationCode.Count; i++)
            {
                Console.WriteLine($"Location {i + 1} : \n");

                for (int k = 0; k < headers.Length; k++)
                {
                    Console.Write($"{headers[k], margin}");
                }
                Console.WriteLine();

                for (int j = 0; j < orderByLocationCode[i].Count; j++)
                {
                    Vessel v = orderByLocationCode[i][j];

                    int monthlyCrewCost = v.Crew * _costPerCrewMember[v.Type - 1];
                    totalTonnage += v.Tonnage;
                    totalCrew += v.Crew;
                    totalMonthlyCost += monthlyCrewCost;
                    
                    Console.WriteLine($"{v.LocationCode, margin}{_vesselFunction[v.Type - 1], margin}{v.Name, margin}{v.Tonnage,margin}{v.Crew,margin}{monthlyCrewCost,margin}");
                }
                Console.WriteLine();
            }

            // Displaying total statistics
            Console.WriteLine($"\n{"Grand Totals", -75}{totalTonnage, margin}{totalCrew, margin}{totalMonthlyCost, margin}\n");
        }

        public void LocationAnalysisReport()
        {
            int[] countByLocation = new int[5];
            int totalCount = 0;
            string[] headers = new string[2] { "Location", "Vessel Count" };

            for (int i = 0; i < Vessels.Count; i++)
            {
                Vessel v = Vessels[i];
                switch (v.LocationCode)
                {
                    case 1:
                        countByLocation[0]++;
                        break;
                    case 2:
                        countByLocation[1]++;
                        break;
                    case 3:
                        countByLocation[2]++;
                        break;
                    case 4:
                        countByLocation[3]++;
                        break;
                    case 5:
                        countByLocation[4]++;
                        break;
                }
            }

            Console.WriteLine();
            for (int i = 0; i < headers.Length; i++)
            {
                Console.Write($"{headers[i],margin}");
            }
            Console.WriteLine();

            for (int i = 0; i < countByLocation.Length; i++)
            {
                Console.WriteLine($"{_locationNames[i],margin}{countByLocation[i],margin}");
                totalCount += countByLocation[i];
            }

            Console.WriteLine($"{"Totals", margin}{totalCount,margin}\n");
        }

        public void Search()
        {
            string vesselName;
            bool matchFound = false;
            string location = "";
            do
            {
                Console.Write($"{"Enter Vessel Name : ",margin}");
                vesselName = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(vesselName));

            foreach (Vessel v in Vessels)
            {
                if(v.Name == vesselName)
                {
                    matchFound = true;
                    location = _locationNames[v.LocationCode];
                }
            }

            if (matchFound)
            {
                Console.WriteLine($"{"Location", margin}{location}");
            }
            else
            {
                Console.WriteLine("No match found.");
            }
        }
        public List<Vessel> Vessels { get => _vessels; set => _vessels = value; }
    }
}
