using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q6
{
    static public class FileHandler
    {
        public const int MARGIN = -25;
        public static readonly string[] _headersStudent = { "Name", "ID" };
        public static readonly string[] _headersSubject = { "Subject", "Percentage", "Grade", "Points" };
        static public void WriteToFile(List<Student> students)
        {
            // if the file does not exist it will get created automatically
            using (StreamWriter sw = new StreamWriter("../../../output.txt", append: true))
            {
                foreach (Student student in students)
                {
                    foreach (string s in _headersStudent)
                    {
                        sw.Write($"{s,MARGIN}");
                    }

                    sw.WriteLine();

                    sw.WriteLine($"{student.Name,MARGIN}{student.Id,MARGIN}");

                    sw.WriteLine();

                    foreach (string s in _headersSubject) 
                    {
                        sw.Write($"{s,MARGIN}");
                    }

                    sw.WriteLine();

                    foreach (Subject subject in student.Subjects)
                    {
                        sw.WriteLine($"{subject.Name, MARGIN}{subject.Percentage, MARGIN}{subject.Grade, MARGIN}{subject.Points, MARGIN}");
                    }

                    sw.WriteLine($"\n{"Total Points", MARGIN}{"", MARGIN}{"",MARGIN}{student.TotalPoints, MARGIN}");
                    sw.WriteLine("**********************************************************************************");
                }
            }
        }
    }
}
