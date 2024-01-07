using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.domain.Enums;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{
    public class LuggageTestsFixture : IDisposable
    {   

        public Luggage CreateValidCarryOnLuggage(User user, Flight flight)
        {

            var faker = new Faker( "pt_BR" );
            return new Luggage( user , flight , Math.Round( faker.Random.Double( 10 , 100 ) , 2 ) , LuggageType.CarryOn ); 
        }

        public Luggage CreateValidCheckedLuggage( User user , Flight flight )
        {
            var faker = new Faker( "pt_BR" );
            return new Luggage( user , flight , Math.Round( faker.Random.Double( 10 , 100 ) , 2 ) , LuggageType.Checked );
        }


        public void Dispose()
        {
        }
    }
}
