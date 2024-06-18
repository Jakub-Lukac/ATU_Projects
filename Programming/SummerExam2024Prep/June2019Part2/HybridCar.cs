using June2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2019Part2
{
    public class HybridCar : Car
    {
        private int _batteryRange;

        public HybridCar(int fuelTankSize, double efficiency, int batteryRange) : base(fuelTankSize, efficiency)
        {
            _batteryRange = batteryRange;
        }

        public override double CalcRange()
        {
            _fuelTankSize += _batteryRange;
            return _fuelTankSize * _efficiency;
        }

        public override string ToString()
        {
            return $"{base.ToString(), Table.MARGIN}{_batteryRange,Table.MARGIN}";
        }

        public int BatteryRange { get => _batteryRange; set => _batteryRange = value; }
    }
}
