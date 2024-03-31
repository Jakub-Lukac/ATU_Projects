using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace French_Navy
{
    public class Vessel
    {
        private string _name;
        private int _type;
        private int _tonnage;
        private int _crew;
        private int _locationCode;

        public Vessel(string name, int type, int tonnage, int crew, int locationCode)
        {
            Name = name;
            Type = type;
            Tonnage = tonnage;
            Crew = crew;
            LocationCode = locationCode;
        }

        public string Name { get => _name; set => _name = value; }
        public int Type { get => _type; set => _type = value; }
        public int Tonnage { get => _tonnage; set => _tonnage = value; }
        public int Crew { get => _crew; set => _crew = value; }
        public int LocationCode { get => _locationCode; set => _locationCode = value; }
    }
}
