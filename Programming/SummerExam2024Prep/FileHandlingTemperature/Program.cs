using System;
namespace FileHandlingTemperature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string searchedCityName;
            string searchAgain;
            const string AGAIN = "yes";

            string path = @"C:\Users\Jakub\OneDrive - Atlantic TU\y1s2\Programming\SummerExamsPrep\FileHandlingTemperature\cities.csv";
            Cities cities = new Cities(FileHandler.ReadCityData(path));
            FileHandler.DisplayData(cities.CitiesList);

            do
            {
                // enter city name - call input hanlder
                searchedCityName = InputHandler.EnterCityName();
                // call cities DisplayCityData method
                cities.DisplayCityData(searchedCityName);
                // ask user if he wishes to continue - call input hanlder
                searchAgain = InputHandler.SearchAgain();
            } while (searchAgain == AGAIN);
        }
    }
}
