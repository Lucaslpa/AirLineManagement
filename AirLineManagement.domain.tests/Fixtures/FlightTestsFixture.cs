
using Bogus;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{
    [CollectionDefinition( nameof( FlightFixtureCollection ) )]
    public class FlightFixtureCollection : ICollectionFixture<FlightTestsFixture>, ICollectionFixture<CompanyTestsFixture>
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
                Math.Round( faker.Random.Double( 101 , 500 ) , 2 ) ,
                Math.Round( faker.Random.Double( 200 , 20000 ) , 2 ),
                company ,
                faker.Date.Future(),
                Math.Round( faker.Random.Double( 11 , 100 ) , 2 ) ,
                faker.Random.Int( 2 , 72),
                faker.Random.Int( 40 , 72)
                ); 
        }

        public Flight CreateInvalidFlight( Company company )
        {
            var faker = new Faker( "pt_BR" );

            return new Flight(
                "" ,
                "" ,
                3 ,
                3 ,
                5 ,
                company ,
                faker.Date.Future() ,
                3 ,
                5,
                0
                );
        }


        public void Dispose()
        {
        }
    }
}
