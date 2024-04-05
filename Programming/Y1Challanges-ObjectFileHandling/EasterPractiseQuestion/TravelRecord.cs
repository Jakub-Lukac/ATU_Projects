using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterPractiseQuestion
{
    public class TravelRecord
    {
        public const int margin = -12;

        private string _lastName;
        private string _firstName;
        private int _age;
        private string _sexCode;
        private string _occupationCode;
        private string _nativeCountryCode;
        private string _destination;
        private string _passengerPortOfEmbarkationCode;
        private string _id;
        private DateOnly _arrivalDate;

        public TravelRecord(string lastName, string firstName, int age, string sexCode, string occupationCode, string nativeCountryCode, string destination, string passengerPortOfEmbarkationCode, string id, DateOnly arrivalDate)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            SexCode = sexCode;
            OccupationCode = occupationCode;
            NativeCountryCode = nativeCountryCode;
            Destination = destination;
            PassengerPortOfEmbarkationCode = passengerPortOfEmbarkationCode;
            Id = id;
            ArrivalDate = arrivalDate;
        }

        public string DisplayFullName()
        {
            return $"Last name : {LastName,margin}First name : {FirstName}";
        }

        public override string ToString()
        {
            return $"{LastName,margin}{FirstName,margin}{Age,margin}{SexCode,margin}{OccupationCode,margin}{NativeCountryCode,margin}{Destination,margin}{PassengerPortOfEmbarkationCode,margin}{Id,margin}{ArrivalDate,margin}";
        }

        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public int Age { get => _age; set => _age = value; }
        public string SexCode { get => _sexCode; set => _sexCode = value; }
        public string OccupationCode { get => _occupationCode; set => _occupationCode = value; }
        public string NativeCountryCode { get => _nativeCountryCode; set => _nativeCountryCode = value; }
        public string Destination { get => _destination; set => _destination = value; }
        public string PassengerPortOfEmbarkationCode { get => _passengerPortOfEmbarkationCode; set => _passengerPortOfEmbarkationCode = value; }
        public string Id { get => _id; set => _id = value; }
        public DateOnly ArrivalDate { get => _arrivalDate; set => _arrivalDate = value; }
    }
}
