using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingTemperature
{
    public class InputHandler
    {
        static public string EnterCityName()
        {
            string cityName;
            do
            {
                Console.Write("Please Enter city name : ");
                cityName = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(cityName));

            return cityName;
        }
        static public string SearchAgain()
        {
            string searchAgain;
            string[] validAnswers = { "yes", "no" };
            do
            {
                Console.Write("Do you wish to continue (yes/no) : ");
                searchAgain = Console.ReadLine().Trim().ToLower();
            } while (string.IsNullOrEmpty(searchAgain) || !validAnswers.Contains(searchAgain));

            return searchAgain;
        }
    }
}
