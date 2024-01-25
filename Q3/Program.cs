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

namespace Q3
{
    internal class Program
    {
        static string INPUT_TABLE = "{0,-45}{1,1}";
        static string OUTPUT_TABLE = "{0,-50}{1,1}";
        static string OUTPUT_TABLE_STATUS = "{0,-15}{1,-15}{2,-15}";
        static void Main(string[] args)
        {
            // declaration
            int entryPoints;
            int numberOfStudents;
            List<Student> students = new List<Student>();
            double averageStudentScore;
            int highestScore;

            // processing
            try
            {
                entryPoints = InputEntryPoints();

                numberOfStudents = InputNumberOfStudents();

                students = InputStudentDetails(numberOfStudents);

                averageStudentScore = AverageScore(students);

                highestScore = HighestScore(students);

                OutputStudentStatus(students, entryPoints);

                StudentStatistics(averageStudentScore, highestScore);
            }
            catch
            {
                Console.WriteLine("OOPS something went wrong...");
            }
           
            Console.ReadKey();
        }
        static int InputEntryPoints()
        {
            int points;
            do
            {
                Console.Write(INPUT_TABLE, "Enter entry points for course", ": ");
            } while ((int.TryParse(Console.ReadLine().Trim(), out points)) && points < 0);
            return points;
        }
        static int InputNumberOfStudents()
        {
            // MAX 10 STUDENTS
            int numberOfStudents;
            Console.WriteLine();
            do
            {
                Console.Write(INPUT_TABLE, "Enter number of students", ": ");
            } while ((int.TryParse(Console.ReadLine().Trim(), out numberOfStudents)) && (numberOfStudents < 0 || numberOfStudents > 10));
            return numberOfStudents;
        }
        static List<Student> InputStudentDetails(int numberOfStudents)
        {
            string studentName;
            int numberOfPoints;
            List<Student> students = new List<Student>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine();
                Console.Write(INPUT_TABLE, $"Enter name of student {i + 1}", ": ");
                studentName = Console.ReadLine().Trim().ToLower();
                studentName = $"{studentName.Substring(0, 1).ToUpper()}{studentName.Remove(0,1)}";

                do
                {
                    Console.Write(INPUT_TABLE, $"Enter CAO points for student {i + 1}", ": ");
                } while (int.TryParse(Console.ReadLine().Trim(), out numberOfPoints) && numberOfPoints < 0);

                Student student = new Student(studentName, numberOfPoints);
                students.Add(student);
            }
            return students;
        }
        static double AverageScore(List<Student> students) 
        {
            int total = 0;
            double average;
            foreach (Student student in students)
            {
                total += student.NumberOfPoints;
            }
            average = total / students.Count;
            return average;
        }
        static int HighestScore(List<Student> students)
        {
            // Can be set to 0, because no number will be less then 0
            int max = 0;
            foreach (Student student in students)
            {
                if(student.NumberOfPoints > max)
                {
                    max = student.NumberOfPoints;
                }
            }
            return max;
        }
        static void OutputStudentStatus(List<Student> students, int requiredPoints)
        {
            string status;
            Console.WriteLine();
            Console.WriteLine(OUTPUT_TABLE_STATUS, "Student", "Points", "Status");
            foreach (Student student in students)
            {
                status = student.NumberOfPoints >= requiredPoints ? "Offer" : "No Offer";
                Console.WriteLine(OUTPUT_TABLE_STATUS, $"{student.Name}", $"{student.NumberOfPoints}", $"{status}");
            }
            Console.WriteLine();
        }
        static void StudentStatistics(double averageScore, int highestScore)
        {
            Console.WriteLine(OUTPUT_TABLE, "Average number of points", $"{averageScore}");
            Console.WriteLine();
            Console.WriteLine(OUTPUT_TABLE, "Highest number of points", $"{highestScore}");
        }
    }
    class Student
    {
        private string _name;
        private int _numberOfPoints;
        public Student(string name, int numberOfPoints)
        {
            _name = name;
            _numberOfPoints = numberOfPoints;
        }

        public string Name { get => _name; set => _name = value; }
        public int NumberOfPoints { get => _numberOfPoints; set => _numberOfPoints = value; }
    }
}
