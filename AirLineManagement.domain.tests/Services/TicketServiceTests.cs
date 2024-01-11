using AirLineManagement.domain.Services;
using Moq;
using Moq.AutoMock;
using FluentAssertions;
using Testes.domain.Interfaces.Repositories;
using Testes.domain.Model;
using Testes.domain.tests.Fixtures;
using AirLineManagement.domain.Interfaces.Repositories;

namespace AirLineManagement.tests.Services
{
    [Collection( nameof( TicketFixtureCollection ) )]
    public class TicketServicesTests( TicketTestsFixture ticketTestsFixture ,
        CompanyTestsFixture companyTestsFixture ,
        FlightTestsFixture flightTestsFixture ,
        UserTestsFixture userTestsFixture ,
        SeatTestsFixture seatTestsFixture ,
        LuggageTestsFixture luggageTestsFixture )
    {

        private readonly TicketTestsFixture _ticketTestsFixture = ticketTestsFixture;
        private readonly FlightTestsFixture _flightTestsFixture = flightTestsFixture;
        private readonly CompanyTestsFixture _companyTestsFixture = companyTestsFixture;
        private readonly UserTestsFixture _userTestsFixture = userTestsFixture;
        private readonly SeatTestsFixture _seatTestsFixture = seatTestsFixture;
        private readonly LuggageTestsFixture _luggageFixture = luggageTestsFixture;


        [Fact]
        public async Task Should_add_valid_Ticket_correctly()
        {
            //Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateValidUser();
            var flight = _flightTestsFixture.CreateValidFlight( company );
            var seat = _seatTestsFixture.CreateValidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var mocker = new AutoMocker();
            var TicketService = mocker.CreateInstance<TicketService>();

            //act
            var result = await TicketService.Add( ticket );

            //Assert
            mocker.GetMock<ITicketRepository>().Verify( r => r.Add( ticket ) , Times.Once );
            result.Should().BeTrue();
        }


        [Fact]
        public async Task Should_not_add_invalid_Ticket()
        {
            //Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateValidUser();
            var flight = _flightTestsFixture.CreateInvalidFlight( company );
            var seat = _seatTestsFixture.CreateValidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var mocker = new AutoMocker();
            var TicketService = mocker.CreateInstance<TicketService>();

            //act
            var result = await TicketService.Add( ticket );

            //Assert
            mocker.GetMock<ITicketRepository>().Verify( r => r.Add( ticket ) , Times.Never );
            result.Should().BeFalse();
        }


        [Fact]
        public async Task Should_update_valid_Ticket_correctly()
        {
            //Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateValidUser();
            var flight = _flightTestsFixture.CreateValidFlight( company );
            var seat = _seatTestsFixture.CreateValidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var mocker = new AutoMocker();
            var TicketService = mocker.CreateInstance<TicketService>();

            //act
            var result = await TicketService.Update( ticket );

            //Assert
            mocker.GetMock<ITicketRepository>().Verify( r => r.Update( ticket ) , Times.Once );
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_update_invalid_Ticket()
        {
            //Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateInvalidUser();
            var flight = _flightTestsFixture.CreateInvalidFlight( company );
            var seat = _seatTestsFixture.CreateInvalidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var mocker = new AutoMocker();
            var TicketService = mocker.CreateInstance<TicketService>();

            //act
            var result = await TicketService.Update( ticket );

            //Assert
            mocker.GetMock<ITicketRepository>().Verify( r => r.Update( ticket ) , Times.Never );
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Should_delete_valid_Ticket()
        {
            //Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateValidUser();
            var flight = _flightTestsFixture.CreateValidFlight( company );
            var seat = _seatTestsFixture.CreateValidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var mocker = new AutoMocker();
            var TicketService = mocker.CreateInstance<TicketService>();

            //act
            var result = await TicketService.Delete( ticket );
            var result2 = await TicketService.Delete( ticket.Id );


            //Assert
            mocker.GetMock<ITicketRepository>().Verify( r => r.Delete( ticket ) , Times.Once );
            mocker.GetMock<ITicketRepository>().Verify( r => r.Delete( ticket.Id ) , Times.Once );

            result.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_delete_a_invalid_Ticket()
        {
            //Arrange
            var company = _companyTestsFixture.CreateValidCompany();
            var user = _userTestsFixture.CreateValidUser();
            var flight = _flightTestsFixture.CreateInvalidFlight( company );
            var seat = _seatTestsFixture.CreateValidSeat( flight , user );
            var ticket = _ticketTestsFixture.CreateValidTicket( flight , user , seat );
            var mocker = new AutoMocker();
            var TicketService = mocker.CreateInstance<TicketService>();

            //act
            var result = await TicketService.Delete( ticket );

            //Assert
            mocker.GetMock<ITicketRepository>().Verify( r => r.Delete( ticket ) , Times.Never );
            result.Should().BeFalse();
        }

    }
}
