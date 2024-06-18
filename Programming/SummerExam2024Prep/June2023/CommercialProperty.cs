using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2023
{
    public class CommercialProperty : Property
    {
        private readonly string[] _validBands;

        private string _ratesBand;

        public CommercialProperty(string eircode, double rent, int numOfBedSpaces, string rateBand) : base(eircode, rent, numOfBedSpaces)
        {
            _validBands = new string[] { "A", "B", "C" };
            RatesBand = rateBand;
        }

        public override bool EligibleForGrant()
        {
            if(_ratesBand == "A")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString(), MARGIN}{_ratesBand, MARGIN}";
        }

        public string RatesBand 
        { 
            get => _ratesBand; 
            set
            {
                if(!_validBands.Contains(value))
                {
                    throw new ArgumentException("Invalid rate band selected! Please check again.");
                }
                _ratesBand = value;
            }
        }
    }
}
