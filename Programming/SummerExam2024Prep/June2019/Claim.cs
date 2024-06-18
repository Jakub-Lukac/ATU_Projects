using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2019
{
    public class Claim
    {
        private const int MARGIN = -20;
        private readonly string[] _validClaims;

        private string _customerNumber;
        private DateOnly _date;
        private string _claimType;
        private double _amount;

        public Claim()
        {
            _validClaims = new string[] {"fire", "flood", "burglary" };
        }
        public Claim(string customerNumber, DateOnly date, string claimType, double amount) : this()
        {
            _customerNumber = customerNumber;
            _date = date;
            ClaimType = claimType;
            _amount = amount;
        }

        public override string ToString()
        {
            return $"{_customerNumber,MARGIN}{_date,MARGIN}{_claimType,MARGIN}{_amount,MARGIN}";
        }

        public string CustomerNumber 
        {
            get => _customerNumber; 
            set 
            {
                int number;
                if (!value.StartsWith("C") || !int.TryParse(value.Remove(0,1), out number))
                {
                    throw new ArgumentException("Invalid customer number. Check your values!");
                }
                _customerNumber = value;
            }
        }
        public DateOnly Date { get => _date; set => _date = value; }
        public string ClaimType 
        { 
            get => _claimType; 
            set
            {
                if(!_validClaims.Contains(value))
                {
                    throw new ArgumentException("Invalid type of claim was passed. Check your values!");
                }
                _claimType = value;
            }
        }
        public double Amount { get => _amount; set => _amount = value; }
    }
}
