using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{
    public class SeatTestsFixture : IDisposable
    {

        public Seat CreateValidSeat(Flight flight, User user)
        {
            var faker = new Faker( "pt_BR" );
            var seat = new Seat( faker.Random.Int( 1 , 50 ) , flight , user );
            return seat;
        }

        public void Dispose()
        {
        }
    }
}
