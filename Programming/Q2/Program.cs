/*
 * Author: Jakub Lukac
 * Date: 25/01/2023
 * Purpose: Revise
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Q2
{
    internal class Program
    {
        static Dictionary<string, int> PRODUCTS = new Dictionary<string, int>() 
        {
            {"Kids bike", 100 },
            {"Hybrid bike", 400 },
            {"Mountain bike", 400 },
            {"Racing bike", 750 },
            {"Electric bike", 1000 },
        };
        static string INPUT_TABLE = "{0,-30}{1,1}";
        static void Main(string[] args)
        {
            // declaration
            string customerName, productName;
            int quantity;
            double costOfPurchase;
            bool repeat;

            //formatting
            Console.OutputEncoding = Encoding.UTF8;

            // processibg
            do
            {
                customerName = InputCustomerName();

                productName = InputProductName();

                quantity = InputQuantity();

                costOfPurchase = CostOfPurchase(productName, quantity);

                OutputMessage(customerName, costOfPurchase);

                repeat = RepeatProgram();

            } while (repeat);

            Console.ReadKey();
        }
        static string InputCustomerName()
        {
            string name;
            Console.Write(INPUT_TABLE, "Please enter customer name", ": ");
            name = Console.ReadLine().Trim().ToLower();

            // making the first character of string upperCase
            name = $"{name.Substring(0, 1).ToUpper()}{name.Remove(0,1)}";
            return name;
        }
        static string InputProductName()
        {
            string productName;
            do
            {
                Console.Write(INPUT_TABLE, "Please enter prodcut name", ": ");
                productName = Console.ReadLine().Trim().ToLower();
                productName = $"{productName.Substring(0, 1).ToUpper()}{productName.Remove(0, 1)}";
            } while (!PRODUCTS.ContainsKey(productName));
            
            return productName;
        }
        static int InputQuantity()
        {
            int quantity;

            do
            {
                Console.Write(INPUT_TABLE, "Please enter quantity", ": ");

            } while ((!int.TryParse(Console.ReadLine().Trim(), out quantity)) || quantity <= 0);
            return quantity;
        }
        static double CostOfPurchase(string productName, int quantity)
        {
            double totalCost = 0;
            for (int i = 0; i < PRODUCTS.Count; i++)
            {
                totalCost = PRODUCTS[productName] * quantity;
            }
            return totalCost;
        }
        static void OutputMessage(string name, double cost)
        {
            Console.WriteLine($"{name} the cost of your purchase is {cost:c2}");
        }
        static bool RepeatProgram()
        {
            string decision;
            bool repeat;

            do
            {
                Console.Write(INPUT_TABLE, "Do you wish to buy another item (y/n)", ": ");
                decision = Console.ReadLine().Trim().ToLower();
            } while (decision != "y" && decision != "n");

            if(decision == "y")
            {
                repeat = true;
            }
            else
            {
                repeat = false;
            }
            return repeat;
        }
    }
}
