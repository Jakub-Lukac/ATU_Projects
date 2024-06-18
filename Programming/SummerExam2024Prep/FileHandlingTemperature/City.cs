using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingTemperature
{
    public class City
    {
        private const int MARGIN = -20;

        private string _id;
        private string _name;
        private double _temperature;


        public City()
        {

        }
        public City(string id, string name, double temperature)
        {
            _id = id;
            _name = name;
            _temperature = temperature;
        }

        public override string ToString()
        {
            return $"{_id,MARGIN}{_name,MARGIN}{_temperature,MARGIN}";
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public double Temperature { get => _temperature; set => _temperature = value; }
    }
}
