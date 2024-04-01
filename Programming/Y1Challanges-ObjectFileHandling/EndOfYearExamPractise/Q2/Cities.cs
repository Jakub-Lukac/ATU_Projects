using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    public class Cities
    {
        private const int margin = -25;
        private string[] _descriptions;
        List<City> _citiesList;

        public Cities(List<City> citiesList)
        {
            CitiesList = citiesList;
            _descriptions = new string[] { "It's hot" , "It's moderate", "It's cold" };
        }
        public void Search()
        {
            string enteredCity;
            bool matchFound = false;
            do
            {
                Console.Write($"{"Enter City Name : ",margin}");
                enteredCity = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(enteredCity));

            enteredCity = enteredCity.Substring(0, 1).ToUpper() + enteredCity.Remove(0, 1);

            City searchedCity = new City();
            foreach (City c in _citiesList)
            {
                if (c.Name == enteredCity)
                {
                    matchFound = true;
                    searchedCity = c;
                }
            }

            string description;
            if (matchFound)
            {
                if(searchedCity.Temperature > 25)
                {
                    description = _descriptions[0];
                }
                else if (searchedCity.Temperature <= 25 && searchedCity.Temperature >= 10)
                {
                    description = _descriptions[1];
                }
                else
                {
                    description = _descriptions[2];
                }

                Console.WriteLine($"{description} in {searchedCity.Name}");
            }
            else
            {
                Console.WriteLine($"Sorry, no data available for {enteredCity}");
            }
        }

        public string SearchAgain()
        {
            string[] validAnswers = { "yes", "no" };
            string answer;
            do
            {
                Console.Write("Search again (yes / no) : ");
                answer = Console.ReadLine().ToLower().Trim();
            } while (!validAnswers.Contains(answer));

            return answer;

        }
        public List<City> CitiesList { get => _citiesList; set => _citiesList = value; }
    }
}
