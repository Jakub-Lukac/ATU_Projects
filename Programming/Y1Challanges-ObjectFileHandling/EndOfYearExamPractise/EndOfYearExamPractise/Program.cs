using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace EndOfYearExamPractise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Property p = new Property("D06K3C2", 1500, 3);
            Console.WriteLine(p.ToString());
            CommercialProperty commercial = new CommercialProperty("D06K555", 1500, 3, 'A');
            Console.WriteLine(commercial.ToString());

            List<Property> properties = new List<Property>();
            
            properties = FillWithData(properties);

            DisplayData(properties);
        }
        static void DisplayData(List<Property> properties)
        {
            foreach (Property p in properties)
            {
                Console.WriteLine(p.ToString());
            }
        }
        static List<Property> FillWithData(List<Property> properties)
        {
            Property p1 = new Property("D06K32", 1500, 3);
            Property p2 = new Property("D06K67", 2500, 2);
            Property p3 = new Property("D06K88", 800, 1);
            CommercialProperty c1 = new CommercialProperty("D06K55", 4000, 0, 'A');

            properties.Add(p1);
            properties.Add(p2);
            properties.Add(p3);
            properties.Add(c1);

            return properties;
        }
    }
    public class CommercialProperty : Property
    {
        private char _ratesBand;
        private char[] _validRateBands = new char[] { 'A', 'B', 'C' };

        public CommercialProperty(string eircode, double propertyValue, int numberOfBedSpaces, char rating) : base(eircode, propertyValue, numberOfBedSpaces)
        {
            RatesBand = rating;
        }

        public bool EligibleForGrant(double propertyValue, char rateBand)
        {
            if (rateBand == 'A' && propertyValue <= limit)
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
            return $"{PropertyNumber,margin}{EirCode,margin}{PropertyValue,margin}{this.EligibleForGrant(PropertyValue, RatesBand),margin}{NumberOfBedSpaces,margin}{base.GetPricePerBedSpace(PropertyValue, NumberOfBedSpaces),margin}{RatesBand,margin}";
        }
            
        public char RatesBand
        {

            get
            {
                return _ratesBand;
            }
            set
            {
                if (_validRateBands.Contains(value))
                {
                    _ratesBand = value;
                }
                else
                {
                    throw new ArgumentException("Invalid rate band!");
                }
            }
        }

    }
    public class Property 
    {
        protected const int limit = 1000;
        protected const int margin = -25;
        static private int counterValue = 0;

        private int _propertyNumber;
        private string _eirCode;
        private double _propertyValue;
        private int _numberOfBedSpaces;

        public Property()
        {
            PropertyNumber = ++counterValue;
        }

        public Property(string eirCode, double propertyValue, int numberOfBedSpaces) : this()
        {
            EirCode = eirCode;
            PropertyValue = propertyValue;
            NumberOfBedSpaces = numberOfBedSpaces;
        }

        public bool EligibleForGrant(double propertyValue)
        {
            if(propertyValue <= limit)
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
            return $"{PropertyNumber, margin}{EirCode, margin}{PropertyValue, margin}{this.EligibleForGrant(PropertyValue), margin}{NumberOfBedSpaces, margin}{this.GetPricePerBedSpace(PropertyValue, NumberOfBedSpaces), margin}";
        }

        public double GetPricePerBedSpace(double rent, int beds)
        {
            double price = rent / beds;
            if (double.IsInfinity(price))
            {
                return 0;
            }
            else
            {
                return price;
            }
        }

        public int PropertyNumber { get => _propertyNumber; private set => _propertyNumber = value; }
        public string EirCode
        {
            get
            {
                return _eirCode;
            }
            set
            {
                if (value.Length != 6 && !value.StartsWith("D"))
                {
                    throw new ArgumentException("Invalid value for Eircode!");
                }
                else
                {
                    _eirCode = value;
                }
            }
        }

        public double PropertyValue { get => _propertyValue; set => _propertyValue = value; }
        public int NumberOfBedSpaces { get => _numberOfBedSpaces; set => _numberOfBedSpaces = value; }
    }

}
