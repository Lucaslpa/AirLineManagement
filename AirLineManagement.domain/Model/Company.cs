
namespace Testes.domain.Model
{
    public class Company( string name , string cnpj , string address , string phone , string email ) : Entity
    {
        public string Name { get; private set; } = name;
        public string Cnpj { get; private set; } = cnpj;
        public string Address { get; private set; } = address;
        public string Phone { get; private set; } = phone;
        public string Email { get; private set; } = email;

        public IEnumerable<Flight> Flights { get; private set; } = new List<Flight>();
    }
}
