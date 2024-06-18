/*
 * Author : Jakub Lukac
 * Date : 22/04/2024
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace June2019
{
    public class FileHandler
    {
        static public List<Claim> ReadClaimsData(string path)
        {
            List<Claim> claims = new List<Claim>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            string[] linesData = line.Split(",");
                            string customerNumber, claimType;
                            DateOnly date;
                            double amount;

                            if (linesData.Length == 4 && !string.IsNullOrEmpty(linesData[0]) && DateOnly.TryParse(linesData[1], out date)
                                && !string.IsNullOrEmpty(linesData[2]) && double.TryParse(linesData[3], CultureInfo.InvariantCulture, out amount))
                            {

                                customerNumber = linesData[0].Trim();
                                date = DateOnly.Parse(linesData[1]);
                                claimType = linesData[2].Trim();
                                amount = double.Parse(linesData[3].Trim(), CultureInfo.InvariantCulture);

                                claims.Add(new Claim(customerNumber, date, claimType, amount));
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error occurred in reading the file. Check all the values!");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error parsing line: {line}. Details: {e.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"An error occurred on line {line}: {ex.Message}");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception(ex.Message);
            }

            return claims;
        }

        static public void DisplayData(List<Claim> claims)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Table.InitTable(Table._headers);
            foreach (Claim c in claims)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
