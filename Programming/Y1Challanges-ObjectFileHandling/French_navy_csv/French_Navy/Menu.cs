using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace French_Navy
{
    public class Menu
    {
        static private List<string> _defaultMenu;

        public Menu()
        {
            DefaultMenu = new List<string>() { "Menu", "Vessel Report", "Location Analysis Report", "Search for a Vessel", "Exit" };
        }

        public int DisplayMenu()
        {
            int optionChosen;
            Console.WriteLine($"{_defaultMenu[0]}");
            for (int i = 1; i < _defaultMenu.Count; i++)
            {
                Console.WriteLine($"{i}. {_defaultMenu[i]}");
            }

            do
            {
                Console.Write($"\nChoose option between 1 - {_defaultMenu.Count - 1} : ");
            } while (!int.TryParse(Console.ReadLine(), out optionChosen) || (optionChosen <= 0 || optionChosen >= _defaultMenu.Count));

            return optionChosen;
        }


        public static List<string> DefaultMenu { get => _defaultMenu; set => _defaultMenu = value; }
    }
}
