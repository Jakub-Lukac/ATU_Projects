using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingTemperature
{
    public class Cities
    {
        private List<City> _citiesList;
        private HashSet<City> _validCities;

        private readonly string[] _descriptions;

        public Cities(List<City> cities) 
        {
            _validCities = new HashSet<City>();
            _descriptions = new string[] { "It\'s hot!", "It\'s moderate.", "It\'s cold!" };
            _citiesList = cities;
        }

        public HashSet<City> GetValidCities()
        {
            foreach (City c in _citiesList)
            {
                _validCities.Add(c);  
            }

            return _validCities;
        }

        public string GetDescription(double value)
        {
            if(value > 25)
            {
                return _descriptions[0];
            }
            else if (value <= 25 && value >= 10)
            {
                return _descriptions[1];
            }
            else
            {
                return _descriptions[2];
            }
        }

        public void DisplayCityData(string cityName)
        {
            bool matchFound = false;
            City searchedCity = new City();
            _validCities = GetValidCities();
            foreach (City c in _validCities)
            {
                if(c.Name == cityName)
                {
                    searchedCity = c;
                    matchFound = true;
                }
            }

            if (matchFound)
            {
                Console.WriteLine($"{this.GetDescription(searchedCity.Temperature)} in {searchedCity.Name}.");
            }
            else
            {
                Console.WriteLine($"Sorry,no data available for {cityName}");
            }
        }

        public List<City> CitiesList { get => _citiesList; set => _citiesList = value; }
        public HashSet<City> ValidCities { get => _validCities; set => _validCities = value; }
    }
}
