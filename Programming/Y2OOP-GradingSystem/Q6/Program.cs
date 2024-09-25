/*
 * Name : Jakub Lukac
 * ID: S00255726
 * Date: 23/09/2024
 */
using System;
namespace Q6
{
    internal class Program
    {
        const string INPUT_TABLE = "{0,-20}{1,1}";
        static void Main(string[] args)
        {
            int numberOfStudents, numberOfSubjects;
            string[] student_detail_questions = { "student's name", "student's ID" };

            string studentName, studentID;
            HashSet<string> allowedLevel = new HashSet<string>() {"H", "O"};

            const int LOWER_BOUNDARY_STUDENTS = 1, UPPER_BOUNDARY_STUDENTS = 30;
            const string STUDENT_QUESTION = "How many students are in class";

            const string SUBJECT_QUESTION = "How many subject does student have";

            numberOfStudents = NumberOfElements(STUDENT_QUESTION, LOWER_BOUNDARY_STUDENTS, UPPER_BOUNDARY_STUDENTS);
            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                // for each studet for go through each question about their personal details

                studentName = StudentInput.StudentDetailInput(i, student_detail_questions[0]);
                studentID = StudentInput.StudentDetailInput(i, student_detail_questions[1]);

                numberOfSubjects = NumberOfElements(SUBJECT_QUESTION, SubjectBoundaries.LOWER_BOUNDARY_SUBJECT_COUNT, SubjectBoundaries.UPPER_BOUNDARY_SUBJECT_COUNT);

                List<Subject> studnetSubjects = new List<Subject>(); // with each iteration new List created

                for (int j = 0; j < numberOfSubjects; j++) 
                {
                    // add subject
                    Subject newSubject = SubjectInput.CollectSubject(j, SubjectBoundaries.LOWER_BOUNDARY_PERCENTAGE, SubjectBoundaries.UPPER_BOUNDARY_PERCENTAGE);
                    studnetSubjects.Add(newSubject);
                }

                // add student to students
                students.Add(new Student(studentName, studentID, studnetSubjects));

                Console.WriteLine();
            }

            FileHandler.WriteToFile(students);

        }
        static int NumberOfElements(string message, int lowerBoundary, int upperBoundary)
        {
            int numberOfElements;
            bool isValid;

            do
            {
                Console.Write(INPUT_TABLE, $"{message} (between {lowerBoundary} and {upperBoundary}, both inclusive)", ": ");
                string input = Console.ReadLine().Trim();

                if (!int.TryParse(input, out numberOfElements))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.ForegroundColor = ConsoleColor.White;
                    isValid = false;
                }
                else if (numberOfElements < lowerBoundary || numberOfElements > upperBoundary)
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

            return numberOfElements;
        }
    }
}
