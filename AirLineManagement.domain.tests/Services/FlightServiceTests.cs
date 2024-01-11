using AirLineManagement.domain.Services;
using Moq;
using Moq.AutoMock;
using FluentAssertions;
using Testes.domain.Interfaces.Repositories;
using Testes.domain.Model;
using Testes.domain.tests.Fixtures;

namespace AirLineManagement.tests.Services
{
    [Collection( nameof( FlightFixtureCollection ) )]
    public class FlightServicesTests( FlightTestsFixture FlightTestsFixture, CompanyTestsFixture CompanyTestsFixture )
    {

        private readonly FlightTestsFixture _FlightFixture = FlightTestsFixture;
        private readonly CompanyTestsFixture _companyFixture = CompanyTestsFixture;


        [Fact]
        public async Task Should_add_valid_Flight_correctly()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( company );
            var mocker = new AutoMocker();
            var FlightService = mocker.CreateInstance<FlightService>();

            //act
            var result = await FlightService.Add( Flight );

            //Assert
            mocker.GetMock<IFlightRepository>().Verify( r => r.Add( Flight ) , Times.Once );
            result.Should().BeTrue();
        }


        [Fact]
        public async Task Should_not_add_invalid_Flight()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateInvalidFlight( company );
            var mocker = new AutoMocker();

            var FlightService = mocker.CreateInstance<FlightService>();

            //act
            var result = await FlightService.Add( Flight );

            //Assert
            mocker.GetMock<IFlightRepository>().Verify( r => r.Add( Flight ) , Times.Never );
            result.Should().BeFalse();
        }


        [Fact]
        public async Task Should_update_valid_Flight_correctly()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( company );
            var mocker = new AutoMocker();

            var FlightService = mocker.CreateInstance<FlightService>();

            //act
            var result = await FlightService.Update( Flight );

            //Assert
            mocker.GetMock<IFlightRepository>().Verify( r => r.Update( Flight ) , Times.Once );
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_update_invalid_Flight()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateInvalidFlight( company );
            var mocker = new AutoMocker();

            var FlightService = mocker.CreateInstance<FlightService>();

            //act
            var result = await FlightService.Update( Flight );

            //Assert
            mocker.GetMock<IFlightRepository>().Verify( r => r.Update( Flight ) , Times.Never );
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Should_delete_valid_Flight()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( company );
            var mocker = new AutoMocker();

            var FlightService = mocker.CreateInstance<FlightService>();

            //act
            var result = await FlightService.Delete( Flight );
            var result2 = await FlightService.Delete( Flight.Id );


            //Assert
            mocker.GetMock<IFlightRepository>().Verify( r => r.Delete( Flight ) , Times.Once );
            mocker.GetMock<IFlightRepository>().Verify( r => r.Delete( Flight.Id ) , Times.Once );

            result.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_delete_a_invalid_Flight()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateInvalidFlight( company );
            var mocker = new AutoMocker();

            var FlightService = mocker.CreateInstance<FlightService>();

            //act
            var result = await FlightService.Delete( Flight );

            //Assert
            mocker.GetMock<IFlightRepository>().Verify( r => r.Delete( Flight ) , Times.Never );
            result.Should().BeFalse();
        }

    }
}
