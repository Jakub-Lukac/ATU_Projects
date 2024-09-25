using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    static public class FileHandler
    {
        static public List<int> ReadPercentagesData(string path)
        {
            List<int> percentages = new List<int>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            int percentage;

                            if (!string.IsNullOrEmpty(line) && (int.TryParse(line, out percentage) && (percentage >=0 && percentage <= 100)))
                            {
                                percentage = int.Parse(line);

                                percentages.Add(percentage);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Error occurred in reading the file on line {line}. Check all the values!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error parsing line: {line}. Details: {e.Message}");
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"An error occurred on line {line}: {ex.Message}");
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception(ex.Message);
            }

            return percentages;
        }
    }
}
