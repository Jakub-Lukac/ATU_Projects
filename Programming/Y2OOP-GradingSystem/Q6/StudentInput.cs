using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q6
{
    public class StudentInput
    {
        const string INPUT_TABLE = "{0,-20}{1,1}";
        public static string StudentDetailInput(int count, string question)
        {
            string answer;

            do
            {
                Console.Write(INPUT_TABLE, $"{count + 1}. {question}", ": ");
                answer = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(answer));

            return answer;
        }
    }
}
