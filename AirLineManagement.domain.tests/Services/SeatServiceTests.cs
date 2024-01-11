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
    [Collection( nameof( SeatFixtureCollection ) )]
    public class SeatServicesTests( SeatTestsFixture SeatTestsFixture, FlightTestsFixture FlightTestsFixture, CompanyTestsFixture CompanyTestsFixture, UserTestsFixture UserTestsFixture )
    {

        private readonly SeatTestsFixture _SeatFixture = SeatTestsFixture;
        private readonly FlightTestsFixture _FlightFixture = FlightTestsFixture;
        private readonly CompanyTestsFixture _companyFixture = CompanyTestsFixture;
        private readonly UserTestsFixture _userFixture = UserTestsFixture;


        [Fact]
        public async Task Should_add_valid_Seat_correctly()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Seat = _SeatFixture.CreateValidSeat( Flight, user );
            var mocker = new AutoMocker();
            var SeatService = mocker.CreateInstance<SeatService>();

            //act
            var result = await SeatService.Add( Seat );

            //Assert
            mocker.GetMock<ISeatRepository>().Verify( r => r.Add( Seat ) , Times.Once );
            result.Should().BeTrue();
        }


        [Fact]
        public async Task Should_not_add_invalid_Seat()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Seat = _SeatFixture.CreateInvalidSeat( Flight );
            var mocker = new AutoMocker();
            var SeatService = mocker.CreateInstance<SeatService>();

            //act
            var result = await SeatService.Add( Seat );

            //Assert
            mocker.GetMock<ISeatRepository>().Verify( r => r.Add( Seat ) , Times.Never );
            result.Should().BeFalse();
        }


        [Fact]
        public async Task Should_update_valid_Seat_correctly()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Seat = _SeatFixture.CreateValidSeat( Flight , user );
            var mocker = new AutoMocker();
            var SeatService = mocker.CreateInstance<SeatService>();

            //act
            var result = await SeatService.Update( Seat );

            //Assert
            mocker.GetMock<ISeatRepository>().Verify( r => r.Update( Seat ) , Times.Once );
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_update_invalid_Seat()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Seat = _SeatFixture.CreateInvalidSeat( Flight , user );
            var mocker = new AutoMocker();
            var SeatService = mocker.CreateInstance<SeatService>();

            //act
            var result = await SeatService.Update( Seat );

            //Assert
            mocker.GetMock<ISeatRepository>().Verify( r => r.Update( Seat ) , Times.Never );
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Should_delete_valid_Seat()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Seat = _SeatFixture.CreateValidSeat( Flight , user );
            var mocker = new AutoMocker();
            var SeatService = mocker.CreateInstance<SeatService>();

            //act
            var result = await SeatService.Delete( Seat );
            var result2 = await SeatService.Delete( Seat.Id );


            //Assert
            mocker.GetMock<ISeatRepository>().Verify( r => r.Delete( Seat ) , Times.Once );
            mocker.GetMock<ISeatRepository>().Verify( r => r.Delete( Seat.Id ) , Times.Once );

            result.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_delete_a_invalid_Seat()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Seat = _SeatFixture.CreateInvalidSeat( Flight , user );
            var mocker = new AutoMocker();
            var SeatService = mocker.CreateInstance<SeatService>();

            //act
            var result = await SeatService.Delete( Seat );

            //Assert
            mocker.GetMock<ISeatRepository>().Verify( r => r.Delete( Seat ) , Times.Never );
            result.Should().BeFalse();
        }

    }
}
