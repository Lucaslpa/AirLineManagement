

using FluentAssertions;
using Testes.domain.tests.Fixtures;

namespace AirLineManagement.tests.Model
{

    [Collection( nameof( FlightTestsFixtureCollection ) )]
    public class FlightTests( FlightTestsFixture flightFixture , CompanyTestsFixture companyFixture )
    { 

        private readonly FlightTestsFixture _flightFixture = flightFixture;
        private readonly CompanyTestsFixture _companyFixture = companyFixture;


        [Fact]
        public void Should_create_seats_correctly()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();

            //Act
            var flight = _flightFixture.CreateValidFlight( company );

            //Assert
            flight.Seats.Count.Should().Be( flight.TotalSeats );
        }

    }
}
