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
    [Collection( nameof( LuggageFixtureCollection ) )]
    public class LuggageServicesTests( LuggageTestsFixture LuggageTestsFixture , FlightTestsFixture FlightTestsFixture , CompanyTestsFixture CompanyTestsFixture , UserTestsFixture UserTestsFixture )
    {

        private readonly LuggageTestsFixture _LuggageFixture = LuggageTestsFixture;
        private readonly FlightTestsFixture _FlightFixture = FlightTestsFixture;
        private readonly CompanyTestsFixture _companyFixture = CompanyTestsFixture;
        private readonly UserTestsFixture _userFixture = UserTestsFixture;


        [Fact]
        public async Task Should_add_valid_Luggage_correctly()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Luggage = _LuggageFixture.CreateValidCheckedLuggage( user , Flight );
            var mocker = new AutoMocker();
            var LuggageService = mocker.CreateInstance<LuggageService>();

            //act
            var result = await LuggageService.Add( Luggage );

            //Assert
            mocker.GetMock<ILuggageRepository>().Verify( r => r.Add( Luggage ) , Times.Once );
            result.Should().BeTrue();
        }


        [Fact]
        public async Task Should_not_add_invalid_Luggage()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Luggage = _LuggageFixture.CreateInvalidLuggage( user , Flight );
            var mocker = new AutoMocker();
            var LuggageService = mocker.CreateInstance<LuggageService>();

            //act
            var result = await LuggageService.Add( Luggage );

            //Assert
            mocker.GetMock<ILuggageRepository>().Verify( r => r.Add( Luggage ) , Times.Never );
            result.Should().BeFalse();
        }


        [Fact]
        public async Task Should_update_valid_Luggage_correctly()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Luggage = _LuggageFixture.CreateValidCheckedLuggage( user , Flight );
            var mocker = new AutoMocker();
            var LuggageService = mocker.CreateInstance<LuggageService>();

            //act
            var result = await LuggageService.Update( Luggage );

            //Assert
            mocker.GetMock<ILuggageRepository>().Verify( r => r.Update( Luggage ) , Times.Once );
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_update_invalid_Luggage()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Luggage = _LuggageFixture.CreateInvalidLuggage( user , Flight );
            var mocker = new AutoMocker();
            var LuggageService = mocker.CreateInstance<LuggageService>();

            //act
            var result = await LuggageService.Update( Luggage );

            //Assert
            mocker.GetMock<ILuggageRepository>().Verify( r => r.Update( Luggage ) , Times.Never );
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Should_delete_valid_Luggage()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Luggage = _LuggageFixture.CreateValidCarryOnLuggage( user , Flight );
            var mocker = new AutoMocker();
            var LuggageService = mocker.CreateInstance<LuggageService>();

            //act
            var result = await LuggageService.Delete( Luggage );
            var result2 = await LuggageService.Delete( Luggage.Id );


            //Assert
            mocker.GetMock<ILuggageRepository>().Verify( r => r.Delete( Luggage ) , Times.Once );
            mocker.GetMock<ILuggageRepository>().Verify( r => r.Delete( Luggage.Id ) , Times.Once );

            result.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_delete_a_invalid_Luggage()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var Company = _companyFixture.CreateValidCompany();
            var Flight = _FlightFixture.CreateValidFlight( Company );
            var Luggage = _LuggageFixture.CreateInvalidLuggage( user , Flight );
            var mocker = new AutoMocker();
            var LuggageService = mocker.CreateInstance<LuggageService>();

            //act
            var result = await LuggageService.Delete( Luggage );

            //Assert
            mocker.GetMock<ILuggageRepository>().Verify( r => r.Delete( Luggage ) , Times.Never );
            result.Should().BeFalse();
        }

    }
}
