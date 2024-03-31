using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Challenge
{
    public class Menu
    {
        static private List<string> _defaultMenu;
        static private List<string> _productMenuHeaders;
        static private List<string> _basketHeaders;

        public Menu()
        {
            DefaultMenu = new List<string>() { "Menu", "Process sale transaction", "Restock product", "Print report", "Quit" };
            ProductMenuHeaders = new List<string>() { "", "Name", "Price", "Quantity" };
            BasketHeaders = new List<string>() { "ID", "Name", "Quantity", "Total Price" };
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

        public List<string> DefaultMenu { get => _defaultMenu; set => _defaultMenu = value; }
        public List<string> ProductMenuHeaders { get => _productMenuHeaders; set => _productMenuHeaders = value; }
        public List<string> BasketHeaders { get => _basketHeaders; set => _basketHeaders = value; }
    }
}
