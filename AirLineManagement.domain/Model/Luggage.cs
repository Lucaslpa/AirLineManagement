
using Testes.domain.Enums;

namespace Testes.domain.Model
{
    public class Luggage( User owner , Flight flight , double weight , LuggageType luggageType ) : Entity
    {
        public  User Owner { get; private set; } = owner;
        public  Flight Flight { get; private set; } = flight;
        public  LuggageType LuggageType { get; private set; } = luggageType;
        public  double Weight { get; private set; } = weight;
    }
}
