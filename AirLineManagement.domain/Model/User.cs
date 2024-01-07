

using Testes.domain.Enums;

namespace Testes.domain.Model
{
    public class User : Entity
    {


        public User( string name, string email, string password, string cpf, DateTime birthDate, string phone, string country)
        {
            Name = name;
            Email = email;
            Password = password;
            Cpf = cpf;
            BirthDate = birthDate;
            Phone = phone;
            Country = country;

            SetAgeGroup();
        }

        public string Name { get; private set; }
        public string Email { get; private set; } 
        public string Password { get; private set; } 
        public string Cpf { get; private set; }
        public string Phone { get; private set; }
        public string Country { get; private set; } 
        public DateTime BirthDate { get; private set; } 
        public int Age => DateTime.Now.Year - BirthDate.Year;
        
        public AgeGroup AgeGroup;

        public IEnumerable<Flight> Flights { get; private set; } = new List<Flight>();
        public IEnumerable<Luggage> Luggages { get; private set; } = new List<Luggage>();

        private void SetAgeGroup()
        {
            if ( Age < (int)AgeGroup.Kid ) AgeGroup = AgeGroup.Baby;
            else if ( Age < (int)AgeGroup.Teen ) AgeGroup = AgeGroup.Kid;
            else if ( Age < (int)AgeGroup.Adult ) AgeGroup = AgeGroup.Teen;
            else if (Age < (int)AgeGroup.Elder ) AgeGroup = AgeGroup.Adult;
            else if (Age >= (int)AgeGroup.Elder) AgeGroup = AgeGroup.Elder;
        }
    }
}
