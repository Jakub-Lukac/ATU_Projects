/*
 * Author: Jakub Lukac
 * Date: 07/03/2024
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    internal class Program
    {
        const string INPUT_TABLE = "{0,-40}{1,1}";
        const string OUTPUT_TABLE = "{0,-30}{1,-30}{2,-30}";
        const int margin = -30;
        static void Main(string[] args)
        {
            const string SENTINEL_VALUE = "-999";
            const int NUMBER_OF_ENTRIES = 2;
            int countOfEntries = 0;
            string bookId = "", ratingMessage, highestScoredBook;
            double enteredScore, averageScore;

            List<string> bookIds = new List<string>();
            List<double> bookScores = new List<double>();

            string[] ratingCategories = { "poor", "fair", "good", "very good", "excellent" };
            int[] categories = new int[ratingCategories.Length];
            double[] totalPerCategory = new double[categories.Length];
            double[] averagePerCategory = new double[categories.Length];

            do
            {
                try
                {
                    do
                    {
                        bookId = EnterBookId(SENTINEL_VALUE);
                    } while (bookId == "na");

                    if(bookId != "n")
                    {
                        enteredScore = EnterScore();

                        bookIds.Add(bookId);
                        bookScores.Add(enteredScore);

                        countOfEntries++;

                        ratingMessage = RatingMessage(enteredScore);

                        CountOfEntriesMessage(countOfEntries, NUMBER_OF_ENTRIES);

                        OutputMessage(ratingMessage, bookId);

                        categories = OccurenceInCategories(ratingCategories, categories, ratingMessage);

                        totalPerCategory = TotalPerCategory(ratingCategories, totalPerCategory, ratingMessage, enteredScore);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input");
                }

            } while(bookId != "n" && countOfEntries < NUMBER_OF_ENTRIES);

            // Displaying report after users has finished entering values

            averagePerCategory = AveragePerCategory(totalPerCategory, categories, averagePerCategory);
            averageScore = CalculateAverageRating(bookScores);
            highestScoredBook = HighestScoredBook(bookIds, bookScores);

            PrintReport(bookIds, bookScores, ratingCategories, categories, countOfEntries, averageScore, highestScoredBook, averagePerCategory);

            Console.ReadLine();
        }
        static void CountOfEntriesMessage(int count, int NUMBER_OF_ENTRIES)
        {
            if (count == NUMBER_OF_ENTRIES)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{NUMBER_OF_ENTRIES} books have already been added. Exiting program...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static string HighestScoredBook(List<string> bookIds, List<double> bookScores)
        {

            if (bookScores.Count <= 0)
            {
                return "";
            }
            else
            {
                double max = bookScores[0];
                int indexOfHighestScoredBook = 0;
                for (int i = 0; i < bookScores.Count; i++)
                {
                    if (bookScores[i] > max)
                    {
                        max = bookScores[i];
                        indexOfHighestScoredBook = i;
                    }
                }

                return bookIds[indexOfHighestScoredBook];
            }
        }
        static double CalculateAverageRating(List<double> scores)
        {
            double average, total = 0;
            try
            {
                // Calculating Total
                for (int i = 0; i < scores.Count; i++)
                {
                    total += scores[i];
                }

                // Calculating Average

                average = total / scores.Count;

                return average;
            }
            catch (DivideByZeroException e) // for dividing by zero ( count == 0 )
            {
                return 0;
            }
            catch (Exception e) // in case count < 0
            {
                return 0;
            }
        }
        static double[] AveragePerCategory(double[] totalPerCategory, int[] categories, double[] averagePerCategory)
        {
            for (int i = 0; i < averagePerCategory.Length; i++)
            {
                averagePerCategory[i] = totalPerCategory[i] / categories[i];
            }
            return averagePerCategory;
        }
        static double[] TotalPerCategory(string[] rating, double[] totalPerCategory, string ratingMessage, double bookScore)
        {
            int index = 0;
            for (int i = 0; i < rating.Length; i++)
            {
                if (rating[i] == ratingMessage)
                {
                    index = i;
                    totalPerCategory[index] += bookScore;
                }
            }
            return totalPerCategory;
        }
        static int[] OccurenceInCategories(string[] rating, int[] categories, string ratingMessage)
        {
            int index = 0;
            for (int i = 0; i < rating.Length; i++)
            {
                if (rating[i] == ratingMessage)
                {
                    index = i;
                    categories[index]++;
                }
            }
            return categories;
        }
        // Not sure if it is alright to have it in on method, due to the fact that there is lot
        // of input parameters
        // On the other hand I do not see point of creating 3 almost same report methods
        // as each report only takes few lines
        // so at this stage it is not that hard to trouble shoot
        // if the reports were to be longer, than definitely 3 separate methods.
        static void PrintReport(List<string> ids, List<double> scores, string[] ratingCategory, 
            int[] categories, int countOfEntries, double averageScore, string highestScoredBook,
            double[] averagePerCategory)
        {
            string[] firstReport = { "Book report", "Book ID", "Rating" };
            string[] secondReport = { "Rating report", "Rating", "Books in this rating" , "Average Rating"};

            if(ids.Count <= 0 || scores.Count <= 0)
            {
                Console.WriteLine("There is no data to do report with.");
            }
            else
            {
                // FIRST REPORT
                Console.WriteLine($"\n{firstReport[0]}");
                Console.WriteLine($"{firstReport[1], margin}{firstReport[2], margin}");
                for (int i = 0; i < ids.Count; i++)
                {
                    Console.WriteLine($"{ids[i], margin}{scores[i], margin}");
                }

                // SECOND REPORT
                Console.WriteLine($"\n{secondReport[0]}");
                Console.WriteLine(OUTPUT_TABLE, $"{secondReport[1]}", $"{secondReport[2]}", $"{secondReport[3]}");
                for (int i = 0; i < ratingCategory.Length; i++)
                {
                    if (double.IsNaN(averagePerCategory[i]))
                    {
                        averagePerCategory[i] = 0;  
                    }
                    Console.Write($"{ratingCategory[i], margin}{categories[i], margin} {averagePerCategory[i], margin}");
                    Console.WriteLine();
                }

                // THIRD REPORT 
                Console.WriteLine($"\nTotal reviews : {countOfEntries}");
                Console.WriteLine($"Overall averagae : {averageScore}");
                Console.WriteLine($"Highest scored book : {highestScoredBook}");
            }
        }
        static void OutputMessage(string ratingMessage, string bookId)
        {
            Console.WriteLine($"Book {bookId} is rated as {ratingMessage}");
        }
        static string RatingMessage(double score)
        {
            string message = "";
            if(score >= 0 && score <= 1)
            {
                message = "poor";
            }
            else if (score > 1 && score <= 2)
            {
                message = "fair";
            }
            else if( score > 2 && score <= 3)
            {
                message = "good";
            }
            else if (score > 3 && score <= 4)
            {
                message = "very good";
            }
            else if(score > 4 && score <= 5)
            {
                message = "excellent";
            }
            else
            {
                message = "not defined";
            }

            return message;
        }
        static double EnterScore()
        {
            double enteredScore;
            do
            {
                Console.Write(INPUT_TABLE, "Enter score", ": ");

                // not error message as I am using do while in this case
                // I want to make sure that there is no invalid score value in my code
                // to promt the message I would have to write if with the same conditions as in while clause
                // which will be redundant and not practicall
                // so I chose this approach instead
                
            } while (!double.TryParse(Console.ReadLine().Trim(), out enteredScore) || (string.IsNullOrEmpty(enteredScore.ToString())) || (enteredScore < 0 || enteredScore > 5));
            return enteredScore;
        }
        static string EnterBookId(string SENTINEL_VALUE)
        {
            Console.Write(INPUT_TABLE, "Enter book id", ": ");
            string bookId = Console.ReadLine().Trim();
            int bookNumberPortion;
            if(bookId != SENTINEL_VALUE)
            {
                if (string.IsNullOrWhiteSpace(bookId))
                {
                    Console.WriteLine("Invalid book id.");
                    return "na"; // as not valid, again = na
                }
                else if (!bookId.StartsWith("B"))
                {
                    Console.WriteLine("Does not start with B.");
                    return "na"; 
                }
                else if (bookId.Length != 9)
                {
                    Console.WriteLine("Invalid book id. Must be exactly of lenght 9.");
                    return "na"; 
                }
                else if (!int.TryParse(bookId.Substring(1, 8), out bookNumberPortion))
                {
                    Console.WriteLine("Invalid book id. Must contain exactly 8 digits after first character.");
                    return "na";
                }
                else
                {
                    return bookId;
                }
            }
            else
            {
                return "n"; // as not valid
            }
        }
    }
}
