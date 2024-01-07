
using Bogus;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{
    [CollectionDefinition( nameof( FlightTestsFixtureCollection ) )]
    public class FlightTestsFixtureCollection : ICollectionFixture<FlightTestsFixture>, ICollectionFixture<CompanyTestsFixture>
    {
    }

    public class FlightTestsFixture : IDisposable
    {  

        public Flight CreateValidFlight(Company company)
        {   
            var faker = new Faker( "pt_BR" );

            return new Flight(
                faker.Address.State(),
                faker.Address.State(),
                Math.Round( faker.Random.Double( 200 , 20000 ) , 2 ),
                Math.Round( faker.Random.Double( 0 , 500 ) , 2 ) ,
                Math.Round( faker.Random.Double( 200 , 20000 ) , 2 ),
                company ,
                faker.Date.Future(),
                Math.Round( faker.Random.Double( 0 , 100 ) , 2 ) ,
                faker.Random.Int( 2 , 72),
                faker.Random.Int( 40 , 72)
                ); 
        }
        public void Dispose()
        {
        }
    }
}
