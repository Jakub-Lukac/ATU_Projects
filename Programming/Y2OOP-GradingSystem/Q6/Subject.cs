using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q6
{
    public enum SubjectLevel
    {
        Higher,    // H stands for Higher
        Ordinary,  // O stands for Ordinary
        Null
    }
    public class Subject
    {
        private string _name;
        private int _percentage;
        private SubjectLevel _level; // H or O
        private int _points;
        private string _grade;

        private int[] _boundries;
        private int[] _pointsHigher;
        private int[] _pointsOrdinary;
        private string[] _gradeHigher;
        private string[] _gradeLower;

        public Subject() 
        {
            _boundries = new int[]{ 90, 80, 70, 60, 50, 40, 30, 0 };
            _pointsHigher = new int[]{ 100, 88, 77, 66, 56, 46, 37, 0 };
            _pointsOrdinary = new int[] { 56, 46, 37, 28, 20, 12, 0, 0 };
            _gradeHigher = new string[] { "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8" };
            _gradeLower = new string[] { "O1", "O2", "O3", "O4", "O5", "O6", "O7", "O8" };
        }

        public Subject(string name, int percentage, SubjectLevel level) : this()
        {
            _name = name;
            _percentage = percentage;
            _level = level;
            _points = this.ConvertPercentageToPoints();
            _grade = this.ConvertPercentageToGrade();
        }

        private bool IsHigher() 
        {
            return _level == SubjectLevel.Higher ? true : false;
        }

        private int ConvertPercentageToPoints()
        {
            int points = 0;
            for (int i = 0; i < _boundries.Length; i++)
            {
                if (_percentage >= _boundries[i])
                {
                    points = this.IsHigher() ? _pointsHigher[i] : _pointsOrdinary[i];
                    break;
                }
            }
            return points;
        }

        private string ConvertPercentageToGrade()
        {
            string grade = "";
            for (int i = 0; i < _boundries.Length; i++)
            {
                if (_percentage >= _boundries[i])
                {
                    grade = this.IsHigher() ? _gradeHigher[i] : _gradeLower [i];
                    break;
                }
            }
            return grade;
        }

        public string Name { get => _name; set => _name = value; }
        public int Percentage { get => _percentage; set => _percentage = value; }
        public SubjectLevel Level { get => _level; set => _level = value; }
        public int Points { get => _points; }
        public string Grade { get => _grade; }
    }
}
