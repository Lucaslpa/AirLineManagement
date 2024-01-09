using Testes.domain.tests.Fixtures;
using FluentAssertions;

namespace Testes.domain.tests.Model
{
    [Collection( nameof( TicketFixtureCollection ) )]
    public class TicketTests(
        TicketTestsFixture ticketTestsFixture, 
        CompanyTestsFixture companyTestsFixture,
        FlightTestsFixture flightTestsFixture,
        UserTestsFixture userTestsFixture,
        SeatTestsFixture seatTestsFixture,
        LuggageTestsFixture luggageTestsFixture
        ) 
    {
      
        private readonly TicketTestsFixture _ticketTestsFixture = ticketTestsFixture;
        private readonly CompanyTestsFixture _companyTestsFixture = companyTestsFixture;
        private readonly FlightTestsFixture _flightTestsFixture = flightTestsFixture;
        private readonly UserTestsFixture _userTestsFixture = userTestsFixture;
        private readonly SeatTestsFixture _seatTestsFixture = seatTestsFixture;
        private readonly LuggageTestsFixture _luggageTestsFixture = luggageTestsFixture;


        [Fact]
        public void Should_calculate_ticket_total_price_with_CarryOnLuggage()
        {
            // Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateValidUser();
            var flight = _flightTestsFixture.CreateValidFlight( company );
            var seat = _seatTestsFixture.CreateValidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var luggage = _luggageTestsFixture.CreateValidCarryOnLuggage( user , flight );

            // Act
            ticket.AddLuggage( luggage );
         

            var totalPrice = Math.Round( flight.Price + flight.CarryOnLuggagePrice , 2);

            // Assert
            totalPrice.Should().Be( ticket.TotalPrice );
        }

        [Fact]
        public void Should_calculate_ticket_total_price_with_CheckedLuggage()
        {
            // Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateValidUser();
            var flight = _flightTestsFixture.CreateValidFlight( company );
            var seat = _seatTestsFixture.CreateValidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var luggage = _luggageTestsFixture.CreateValidCheckedLuggage( user , flight );

            // Act
            ticket.AddLuggage( luggage );
       

            var totalPrice = Math.Round( flight.Price + flight.CheckedLuggagePrice, 2 );

            // Assert
            totalPrice.Should().Be( ticket.TotalPrice );
        }

        [Fact]
        public void Should_calculate_ticket_total_price_with_One_CheckedLuggage_and_One_CarryOnLuggage()
        {
            // Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateValidUser();
            var flight = _flightTestsFixture.CreateValidFlight( company );
            var seat = _seatTestsFixture.CreateValidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var checkedLuggage = _luggageTestsFixture.CreateValidCheckedLuggage( user , flight );
            var carryOnLuggage = _luggageTestsFixture.CreateValidCarryOnLuggage( user , flight );

            // Act
            ticket.AddLuggage( checkedLuggage );
            ticket.AddLuggage( carryOnLuggage );

            var totalPrice = Math.Round( flight.Price + flight.CheckedLuggagePrice + flight.CarryOnLuggagePrice , 2);
            // Assert
            ticket.TotalPrice.Should().Be( totalPrice );
        }
    }
}
