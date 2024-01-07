
using Testes.domain.Enums;

namespace Testes.domain.Model
{
    public class Flight : Entity   
    {
        public Flight( string origin , string destiny , double price , double maxCarryOnLuggageWeight, 
                double maxCheckedLuggageWeight , Company airline , DateTime departureTime,
                double carryOnLuggagePrice , int flightTimeInHours , int totalSeats )
        {
            Origin = origin;
            Destiny = destiny;
            Price = price;
            Departure = departureTime;
            FlightTimeInHours = flightTimeInHours;
            MaxCarryOnLuggageWeight = maxCarryOnLuggageWeight;
            MaxCheckedLuggageWeight = maxCheckedLuggageWeight;
            TotalSeats = totalSeats;
            MaxLuggageWeight = maxCarryOnLuggageWeight + maxCheckedLuggageWeight;
            CarryOnLuggagePrice = carryOnLuggagePrice;
            CheckedLuggagePrice = carryOnLuggagePrice * 2;
            AirLine = airline;
            Seats = new List<Seat>();
            Passengers = new List<User>();
            Luggages = new List<Luggage>();
            Arrive = departureTime.AddHours( flightTimeInHours );
            CreateSeats();
        }


        public string Origin { get; private set; }
        public string Destiny { get; private set; }
        public double Price { get; private set; }
        public DateTime Departure { get; private set; }
        public int FlightTimeInHours { get; private set; }
        public DateTime Arrive { get; private set; }
        public double MaxCarryOnLuggageWeight { get; private set; }
        public double MaxCheckedLuggageWeight { get; private set; }
        public double CurrentCarryOnLuggageWeight => Luggages.Where( l => l.LuggageType == LuggageType.CarryOn ).Sum( l => l.Weight );
        public double CurrentCheckedLuggageWeight => Luggages.Where( l => l.LuggageType == LuggageType.Checked ).Sum( l => l.Weight );
        public double CurrentLuggageWeight => CurrentCarryOnLuggageWeight + CurrentCheckedLuggageWeight;
       
        public int TotalSeats { get; private set; } 
        public double MaxLuggageWeight { get; private set; } 
        public double CarryOnLuggagePrice { get; private set; }
        public double CheckedLuggagePrice { get; private set; } 
        public Company AirLine { get; private set; } 
        public List<Seat> Seats { get; private set; } = new List<Seat>();
        public IEnumerable<User> Passengers { get; private set; } = new List<User>();
        public List<Luggage> Luggages { get; private set; } = new List<Luggage>();

        private void CreateSeats()
        {
            for (int i = 0; i < TotalSeats; i++)
            {
                Seats.Add( new Seat( i , this ) );
            }
        }

        public void AddLuggage( Luggage luggage )
        {
            Luggages.Add( luggage );
        }

        public void AddLuggage( IEnumerable<Luggage> luggages )
        {
            Luggages.AddRange( luggages );
        }
    }
}
