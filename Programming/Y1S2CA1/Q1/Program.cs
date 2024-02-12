/*
 * Auhtor: Jakub Lukac
 * Date: 12/02/2024
 * Purpose: Get 100 marks :)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a:");
            Console.WriteLine(CalculateTicketPrice(10, "Single") == 10);
            Console.WriteLine(CalculateTicketPrice(11, "Return") == 16.5m);
            Console.WriteLine(CalculateTicketPrice(-9, "Single") == -1);
            Console.WriteLine(CalculateTicketPrice(10, "") == 10);
            Console.WriteLine(CalculateTicketPrice(12, "return") == 18);

            Console.WriteLine("b:");
            Console.WriteLine(ApplyDiscount(10, "Adult") == 10);
            Console.WriteLine(ApplyDiscount(11, "Child") == 5.5m);
            Console.WriteLine(ApplyDiscount(12, "Student") == 8.4m);
            Console.WriteLine(ApplyDiscount(10, "OAP") == 0);
            Console.WriteLine(ApplyDiscount(10, "oap") == 0);
            Console.WriteLine(ApplyDiscount(10, "travelcard") == 10);
            Console.WriteLine(ApplyDiscount(-11, "OAP") == -1);
            Console.WriteLine(ApplyDiscount(10, "") == 10);


            Console.ReadKey();

        }
        static decimal CalculateTicketPrice(decimal basePrice, string ticketType)
        {
            //case insenstive - toLower
            decimal price = 0;

            if (basePrice < 0)
            {
                price = -1;
            }
            else
            {
                if (ticketType == "" || ticketType.ToLower().Trim() == "single")
                {
                    price = basePrice;
                }
                else if (ticketType.ToLower().Trim() == "return")
                {
                    price = basePrice * 1.5m;
                }
            }
            return price;
        }
        static decimal ApplyDiscount(decimal price, string customerType)
        {
            decimal newPrice = 0;
            if(price < 0)
            {
                newPrice = -1;
                //throw new Exception("Invalid price");
            }
            else
            {
                if(customerType.ToLower().Trim() == "child")
                {
                    newPrice = price * 0.5m;
                }
                else if(customerType.ToLower().Trim() == "student")
                {
                    newPrice = price * 0.7m;
                }
                else if(customerType.ToLower().Trim() == "oap")
                {
                    newPrice = 0;
                }
                else
                {
                    // if ticket type is adult or anything else then we return original price
                    newPrice = price;
                }
            }

            return newPrice;
        }


    }
}
