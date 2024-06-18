using June2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2019Part2
{
    public class Car
    {
        static private int _counter;

        private int _id;
        protected int _fuelTankSize;
        protected double _efficiency; // (number of kilometres per litre)

        public Car()
        {
            _id = ++_counter;
        }

        public Car(int fuelTankSize, double efficiency) : this()
        {
            FuelTankSize = fuelTankSize;
            Efficiency = efficiency;
        }

        public virtual double CalcRange()
        {
            return _fuelTankSize * _efficiency;
        }

        public override string ToString()
        {
            return $"{_id, Table.MARGIN}{_fuelTankSize,Table.MARGIN}{_efficiency,Table.MARGIN}{this.CalcRange(), Table.MARGIN}";
        }

        public int Id { get => _id;}
        public int FuelTankSize 
        { 
            get => _fuelTankSize; 
            set 
            {
                if(value < 0)
                {
                    throw new ArgumentException("Value can not be less than zero.");
                }
                _fuelTankSize = value;
            } 
        }
        public double Efficiency 
        { 
            get => _efficiency; 
            set
            {
                if (_efficiency < 0)
                {
                    throw new ArgumentException("Value can not be less than zero.");
                }
                _efficiency = value;
            }
        }
    }
}
