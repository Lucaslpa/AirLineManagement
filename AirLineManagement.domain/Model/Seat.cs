

using Testes.domain.Enums;

namespace Testes.domain.Model
{
    public class Seat( int number , Flight flight , User passenger = null , AgeGroup minAgeGroup = AgeGroup.Kid ) : Entity
    {

        public int Number { get; private set; } = number;
        public Flight Flight { get; private set; } = flight;
        public User? Passenger { get; private set; } = passenger;
        public AgeGroup MinAgeGroup { get; private set; } = minAgeGroup;
    }
}
