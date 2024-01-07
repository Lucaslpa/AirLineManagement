
using Testes.domain.Enums;

namespace Testes.domain.Model
{
    public class Ticket( User passenger , Flight flight , Seat seat ) : Entity
    {
        public User Passenger { get; private set; } = passenger;
        public Flight Flight { get; private set; } = flight;
        public Seat Seat { get; private set; } = seat;
        public List<Luggage> Luggages { get; private set; } = [];
        public double TotalPrice { get; private set; }

        private void CalculateTotalPrice()
        {
            TotalPrice = 0;
            foreach (var luggage in Luggages)
            {
                if(luggage.LuggageType == LuggageType.CarryOn)
                {
                    TotalPrice += Flight.CarryOnLuggagePrice;
                } else
                {
                    TotalPrice += Flight.CheckedLuggagePrice;
                }
            }
            TotalPrice += Flight.Price;
        }

        public void AddLuggage(Luggage luggage)
        {
            Luggages.Add(luggage);
            CalculateTotalPrice(); 
        }

        public void AddLuggage( IEnumerable<Luggage> luggages )
        {
            Luggages.AddRange(luggages);
            CalculateTotalPrice();
        }

    }
}
