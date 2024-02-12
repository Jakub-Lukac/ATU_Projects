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

namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int optionChosen;
            int numberOfSeatsOccupied = 0, ticketsSold = 0;
            string ticket, customer;
            decimal ticketPrice, ticketPriceAfterDiscount;
            decimal totalMoney = 0;

            const int BASE_PRICE = 10;
            const int NUMBER_OF_SEATS = 10;
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                optionChosen = Menu();
                
                switch (optionChosen)
                {
                    case 1:
                        if(numberOfSeatsOccupied >= 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Bus is full. Press 4 to quit.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            ticket = TypeOfTicket();
                            customer = TypeOfCustomer();
                            ticketPrice = CalculateTicketPrice(BASE_PRICE, ticket);
                            ticketPriceAfterDiscount = ApplyDiscount(ticketPrice, customer);

                            Console.WriteLine($"Ballin-Sligo : {customer} {ticket} : {ticketPriceAfterDiscount:c}");

                            numberOfSeatsOccupied++;
                            ticketsSold++;
                            totalMoney += ticketPriceAfterDiscount;
                        }
                        break;
                    case 2:
                        if(numberOfSeatsOccupied >= 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Bus is full. Press 4 to quit.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            numberOfSeatsOccupied++;
                            Console.WriteLine($"Remaining number of seats is : {NUMBER_OF_SEATS - numberOfSeatsOccupied}");
                        }
                        break;
                    case 3:
                        PrintJourneyReport(ticketsSold, totalMoney, numberOfSeatsOccupied);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                }
            } while (optionChosen != 4);
            Console.ReadKey();
        }
        static int Menu()
        {
            int optionChosen;
            Console.WriteLine("**************************************");
            Console.WriteLine("Ballin Buses Main Menu\n");
            Console.WriteLine("1. Buy ticket");
            Console.WriteLine("2. Check in return ticket");
            Console.WriteLine("3. Print journey report");
            Console.WriteLine("4. Exit");

            do
            {
                Console.Write("Please enter choice (1 - 4) : ");
            } while (!int.TryParse(Console.ReadLine(), out optionChosen) || (optionChosen <= 0 || optionChosen >= 5));

            return optionChosen;
        }
        static string TypeOfCustomer()
        {
            string[] typesOfCustomer = {"adult","child","student","oap"};
            string selectedTypeOfStudent;
         
            do
            {
                Console.Write("Please enter type of customer (adult/child/student/oap) : ");
                selectedTypeOfStudent = Console.ReadLine().ToLower().Trim();
            } while (!typesOfCustomer.Contains(selectedTypeOfStudent));
            return selectedTypeOfStudent;
           
        }
        static string TypeOfTicket()
        {
            string[] typesOfTicket = { "single", "return" };
            string selectedTypeOfTicket;
            do
            {
                Console.Write("Please enter type of ticket (single/return) : ");
                selectedTypeOfTicket = Console.ReadLine().ToLower().Trim();
            } while (!typesOfTicket.Contains(selectedTypeOfTicket));
            return selectedTypeOfTicket;
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
                if (ticketType == "" || ticketType.ToLower() == "single")
                {
                    price = basePrice;
                }
                else if (ticketType.ToLower() == "return")
                {
                    price = basePrice * 1.5m;
                }
            }
            return price;
        }
        static decimal ApplyDiscount(decimal price, string customerType)
        {
            decimal newPrice = 0;
            if (price < 0)
            {
                newPrice = -1;
                //throw new Exception("Invalid price");
            }
            else
            {
                if (customerType.ToLower() == "child")
                {
                    newPrice = price * 0.5m;
                }
                else if (customerType.ToLower() == "student")
                {
                    newPrice = price * 0.7m;
                }
                else if (customerType.ToLower() == "oap")
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
        static void PrintJourneyReport(int numberOfTicketsSold, decimal moneyTaken, int totalSeatsOccupied)
        {
            const string OUTPUT_TABLE = "{0,-35}{1,1}";
            Console.WriteLine(OUTPUT_TABLE, "Number of tickets sold", $"{numberOfTicketsSold}");
            Console.WriteLine(OUTPUT_TABLE, "Money taken", $"{moneyTaken:c}");
            Console.WriteLine(OUTPUT_TABLE, "Total seats occupied", $"{totalSeatsOccupied}");
        }
    }
}
