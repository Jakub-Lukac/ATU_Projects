using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Challenge
{
    public class SalesItems
    {
        private List<Product> _saleItems;

        public SalesItems()
        {
            SaleItems = new List<Product>()
            {
                new Product(1,"Eggs", 3.50, 20),
                new Product(2,"Bread", 2.0, 20),
                new Product(3,"Jam", 3.70, 25),
                new Product(4,"Milk", 1.50, 40),
                new Product(5,"Apples", 0.50, 30),
                new Product(6,"Pens", 2.20, 10),
            };
        }

        public int ProductsMenu(List<string> productMenuHeaders)
        {
            const int margin = -30;
            int optionChosen;
            for (int i = 0; i < productMenuHeaders.Count; i++)
            {
                Console.Write($"{productMenuHeaders[i],margin}");
            }
            for (int i = 0; i < _saleItems.Count; i++)
            {
                Console.WriteLine($"{_saleItems[i].Id,margin}{_saleItems[i].Name,margin}{_saleItems[i].Price,margin}{_saleItems[i].Quantity,margin}");
            }
            do
            {
                Console.Write($"Choose option between 1 - {_saleItems.Count} : ");
            } while (!int.TryParse(Console.ReadLine(), out optionChosen) || (optionChosen <= 0 || optionChosen > _saleItems.Count));
            return optionChosen;
        }

        public int GetQuantity(int productId)
        {
            int quantityChosen;
            do
            {
                Console.Write($"Enter quantity of product {_saleItems[productId].Name}, quantity left is {_saleItems[productId].Quantity} : ");
            } while (!int.TryParse(Console.ReadLine(), out quantityChosen) || (quantityChosen <= 0 || quantityChosen > _saleItems[productId].Quantity));
            return quantityChosen;
        }
        public int RestockQuantity(int productId)
        {
            int quantity;
            do
            {
                Console.Write($"Enter a quantity you want to restock of the {_saleItems[productId].Name} product (0 - 100) : ");
            } while (!int.TryParse(Console.ReadLine(), out quantity) || (quantity <= 0 || quantity > 100));
            return quantity;
        }

        public List<Product> RestockProduct(int productId, int quantity)
        {
            _saleItems[productId].Quantity += quantity;
            return _saleItems;
        }

        public List<Product> SaleItems { get => _saleItems; set => _saleItems = value; }
    }
}
