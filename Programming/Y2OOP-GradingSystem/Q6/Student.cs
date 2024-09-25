using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q6
{
    public class Student
    {
        private string _name;
        private string _id; // string, assuming its is like atu student number (combination of character and numbers)

        private List<Subject> _subjects;

        private int _totalPoints;

        public Student() 
        {
            _totalPoints = 0;
        }

        public Student(string name, string id, List<Subject> subjects) : this()
        {
            _name = name;
            _id = id;
            _subjects = subjects;
            _totalPoints = this.GetTotalPoints();
        }

        private int GetTotalPoints() 
        {
            foreach (Subject subject in _subjects) 
            {
                _totalPoints += subject.Points;
            }

            return _totalPoints;
        }

        public string Name { get => _name; set => _name = value; }
        public string Id { get => _id; set => _id = value; }
        public List<Subject> Subjects { get => _subjects; set => _subjects = value; }
        public int TotalPoints { get => _totalPoints; set => _totalPoints = value; }
    }
}
