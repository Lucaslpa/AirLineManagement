using Bogus;
using Testes.domain.Enums;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{

    [CollectionDefinition( nameof( LuggageFixtureCollection ) )]
    public class LuggageFixtureCollection : ICollectionFixture<LuggageTestsFixture>, ICollectionFixture<UserTestsFixture>, ICollectionFixture<FlightTestsFixture>, ICollectionFixture<CompanyTestsFixture>
    {
    }


    public class LuggageTestsFixture : IDisposable
    {   

        public Luggage CreateValidCarryOnLuggage(User user, Flight flight)
        {

            var faker = new Faker( "pt_BR" );
            return new Luggage( user , flight , Math.Round( faker.Random.Double( 6 , 20 ) , 2 ) , LuggageType.CarryOn ); 
        }

        public Luggage CreateValidCheckedLuggage( User user , Flight flight )
        {
            var faker = new Faker( "pt_BR" );
            return new Luggage( user , flight , Math.Round( faker.Random.Double( 31 , 100 ) , 2 ) , LuggageType.Checked );
        }

        public Luggage CreateInvalidLuggage( User user , Flight flight )
        {
            return new Luggage( user , flight , 0 , LuggageType.Checked );
        }


        public void Dispose()
        {
        }
    }
}
