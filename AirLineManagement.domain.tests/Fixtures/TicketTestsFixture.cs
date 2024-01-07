using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{

    [CollectionDefinition( nameof( TicketFixtureCollection ) )]
    public class TicketFixtureCollection : ICollectionFixture<FlightTestsFixture>, ICollectionFixture<CompanyTestsFixture>, ICollectionFixture<SeatTestsFixture>, ICollectionFixture<UserTestsFixture>, ICollectionFixture<TicketTestsFixture>, ICollectionFixture<LuggageTestsFixture>
    {
    }
     

    public class TicketTestsFixture : IDisposable
    { 

        public Ticket CreateValidTicket (Flight flight, User user, Seat seat)
        {
            return new Ticket( user , flight ,seat );
        }

        public void Dispose()
        {
        }
    }   
   
}
