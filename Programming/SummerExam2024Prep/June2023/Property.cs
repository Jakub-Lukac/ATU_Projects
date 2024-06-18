using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2023
{
    public class Property
    {
        private static int _counter = 0;
        protected const int MARGIN = -20;

        // To prevent using magic numbers inside calculations and if statements, etc.
        private const int RENT_LIMIT = 1000;
        private const int EIRCODE_LENGHT = 6;
        private const string EIRCODE_LETTER = "D";

        private int _id;
        private string _eircode;
        private double _rent;
        private int _numberOfBedSpaces;

        public Property()
        {
            _id = ++_counter;
        }

        public Property(string eircode, double rent, int numOfBedSpaces) : this()
        {
            Eircode = eircode;
            _rent = rent;
            _numberOfBedSpaces = numOfBedSpaces;
        }

        public virtual bool EligibleForGrant()
        {
            if(_rent <= RENT_LIMIT)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetPricePerBedSpace()
        {
            double pricePerBed;
            try
            {
                pricePerBed = _rent / _numberOfBedSpaces;
                if (double.IsInfinity(pricePerBed))
                {
                    return 0;
                }
                return pricePerBed;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("Can not divide by 0! Check if number of bedspaces is not 0.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string ToString()
        {
            return $"{_id,MARGIN}{_eircode,MARGIN}{_rent,MARGIN}{this.EligibleForGrant(),MARGIN}{_numberOfBedSpaces,MARGIN}{this.GetPricePerBedSpace(),MARGIN}";
        }

        public int Id { get => _id;}
        public string Eircode 
        { 
            get => _eircode; 
            set {
                if(value.Length != EIRCODE_LENGHT || !value.StartsWith(EIRCODE_LETTER))
                {
                    throw new ArgumentException("Invalid eircode, must be 6 characters long and start with letter D.");
                }
                
                _eircode = value;
            } 
            /*set
            {
                if (string.IsNullOrEmpty(value) || value.Remove(0,1).Length != EIRCODE_LENGHT || !value.StartsWith(EIRCODE_LETTER))
                {
                    throw new ArgumentException($"Invalid eircode on property with id {_id}, must be 6 characters long and start with letter D.");
                }
                _eircode = value;
            }*/
        }
        public double Rent { get => _rent; set => _rent = value; }
        public int NumberOfBedSpaces { get => _numberOfBedSpaces; set => _numberOfBedSpaces = value; }
    }
}
