using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q6
{
    public class SubjectInput
    {
        private const string INPUT_TABLE = "{0,-20}{1,1}";
        public static Subject CollectSubject(int count, int lowerPercentage, int upperPercentage)
        {
            string subjectName = GetSubjectName(count);
            int subjectPercentage = GetSubjectPercentage(count, lowerPercentage, upperPercentage);
            SubjectLevel subjectLevel = GetSubjectLevel(count);

            return new Subject(subjectName, subjectPercentage, subjectLevel);
        }
        private static string GetSubjectName(int count)
        {
            string subjectName;
            bool isValid;
            do
            {
                Console.Write(INPUT_TABLE, $"Please provide the {count + 1}. subject name", ": ");
                subjectName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(subjectName)) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please provided valid subject name.");
                    Console.ForegroundColor = ConsoleColor.White;
                    isValid = false;
                }
                else 
                {
                    isValid = true;
                }

            } while (!isValid);

            return subjectName;
        }

        private static int GetSubjectPercentage(int count, int lowerBoundary, int upperBoundary)
        {
            int subjectPercentage;
            string input;
            bool isValid;
            do
            {
                Console.Write(INPUT_TABLE, $"Please provide the {count + 1}. subject percentage (between {lowerBoundary} - {upperBoundary}, both inclusive)", ": ");
                input = Console.ReadLine().Trim();

                if (!int.TryParse(input, out subjectPercentage))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.ForegroundColor = ConsoleColor.White;
                    isValid = false;
                }
                else if (subjectPercentage < lowerBoundary || subjectPercentage > upperBoundary) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Input is out of range. Please enter a number between {lowerBoundary} and {upperBoundary}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    isValid = false;
                }
                else 
                {
                    isValid = true;
                }
            } while (!isValid);

            return subjectPercentage;
        }

        private static SubjectLevel GetSubjectLevel(int count)
        {
            SubjectLevel subjectLevel = SubjectLevel.Null; // default value
            bool isValid = false;
            do
            {
                Console.Write(INPUT_TABLE, $"Please provide the {count + 1}. subject level (H for Higher, O for Ordinary)", ": ");
                string input = Console.ReadLine().Trim().ToUpper();

                switch (input)
                {
                    case "H":
                        subjectLevel = SubjectLevel.Higher;
                        isValid = true;
                        break;
                    case "O":
                        subjectLevel = SubjectLevel.Ordinary;
                        isValid = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid level. Please enter H for Higher or O for Ordinary.");
                        Console.ForegroundColor = ConsoleColor.White;
                        isValid = false;
                        break;
                }
            } while (!isValid);

            return subjectLevel;
        }
    }
}
