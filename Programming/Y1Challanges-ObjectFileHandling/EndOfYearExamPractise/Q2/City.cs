using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    public class City
    {
        private int _id;
        private string _name;
        private double _temperature;

        public City()
        {

        }
        public City(int id, string name, double temperature)
        {
            Id = id;
            Name = name;
            Temperature = temperature;
        }

        public int Id { get => _id; private set => _id = value; }
        public string Name { get => _name; private set => _name = value; }
        public double Temperature { get => _temperature; private set => _temperature = value; }
    }
}
