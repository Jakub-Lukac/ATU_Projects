using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
namespace Objects_Challenge
{
    internal class Program
    {
        const int margin = -30;
        static void Main(string[] args)
        {
            int optionMenu, optionProduct, quantity, indexOfProduct;
            double totalPrice;
            /*List<Product> products = new List<Product>() 
            {
                new Product(1,"Eggs", 3.50, 20),
                new Product(2,"Bread", 2.0, 20),
                new Product(3,"Jam", 3.70, 25),
                new Product(4,"Milk", 1.50, 40),
                new Product(5,"Apples", 0.50, 30),
                new Product(6,"Pens", 2.20, 10),
            };*/

            Basket basket = new Basket();
            SalesItems salesItems = new SalesItems();
            Menu menu = new Menu();

            //List<Product> shoppingBasket = new List<Product>();

            do
            {
                optionMenu = menu.DisplayMenu();
                switch (optionMenu)
                {
                    case 1:

                        // getting the product information (id)
                        // getting the quantity of purchase
                        optionProduct = salesItems.ProductsMenu(menu.ProductMenuHeaders);
                        indexOfProduct = optionProduct - 1;

                        quantity = salesItems.GetQuantity(indexOfProduct);
                        //FillInBasket(ref products, ref shoppingBasket, optionProduct);

                        basket.AddItem(new Product(indexOfProduct, salesItems.SaleItems[indexOfProduct].Name, salesItems.SaleItems[indexOfProduct].Price, quantity));
                        salesItems.SaleItems[indexOfProduct].Quantity -= quantity;
                        break;
                    case 2:

                        optionProduct = salesItems.ProductsMenu(menu.ProductMenuHeaders);
                        indexOfProduct = optionProduct - 1;

                        quantity = salesItems.RestockQuantity(indexOfProduct);
                        salesItems.RestockProduct(indexOfProduct, quantity);
                        break;
                    case 3:

                        basket.DisplayReport(menu.BasketHeaders);
                        break;
                    case 4:

                        totalPrice = basket.CalculateTotal();
                        Console.WriteLine($"Total Price is : {totalPrice}");
                        Console.WriteLine("Exiting program...");
                        break;
                }
            } while (optionMenu != 4);


        }
        /*static void FillInBasket(ref List<Product> products, ref List<Product> shoppingBasket, int optionChosen)
        {
            
            bool contains = false;
            int productBaksetIndex = 0, productIndex = 0;
            for (int i = 0; i < products.Count; i++) 
            {
                for(int j = 0; j < shoppingBasket.Count; j++)
                {
                    if (products[i].Name == shoppingBasket[j].Name)
                    {
                        contains = true;
                        productIndex = i;
                        productBaksetIndex = j;
                    }
                }
            }

            // if the product is in the list then access its id, and increment the quantity
            if (contains)
            {
                shoppingBasket[productBaksetIndex].Quantity++;
                products[productIndex].Quantity--;
            }
            // if the product is not yet in the shopping basket append it to the list
            else
            {
                shoppingBasket.Add(new Product(products[optionChosen].Name, products[optionChosen].Price, 1));
                products[productIndex].Quantity--;
            }

        }*/
    }
}
