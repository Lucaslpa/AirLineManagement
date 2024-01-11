

using AirLineManagement.domain.Services;
using Moq;
using Moq.AutoMock;
using System.Linq.Expressions;
using FluentAssertions;
using Testes.domain.Interfaces.Repositories;
using Testes.domain.Model;
using Testes.domain.tests.Fixtures;
using AirLineManagement.domain.Interfaces.Repositories;

namespace AirLineManagement.tests.Services
{
    [Collection( nameof( UserFixtureCollection ) )]
    public class UserServicesTests( UserTestsFixture userTestsFixture )
    {

        private readonly UserTestsFixture _userFixture = userTestsFixture;


        [Fact]
        public async Task Should_add_valid_user_correctly()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var mocker = new AutoMocker();
            var userService = mocker.CreateInstance<UserService>();

            //act
            var result = await userService.Add( user );

            //Assert
            mocker.GetMock<IUserRepository>().Verify( r => r.Add( user ) , Times.Once );
            result.Should().BeTrue();
        }


        [Fact]
        public async Task Should_not_add_invalid_user()
        {
            //Arrange
            var user = _userFixture.CreateInvalidUser();
            var mocker = new AutoMocker();

            var userService = mocker.CreateInstance<UserService>();

            //act
            var result = await userService.Add( user );

            //Assert
            mocker.GetMock<IUserRepository>().Verify( r => r.Add( user ) , Times.Never );
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Should_not_add_a_company_if_already_exists_another_with_the_same_email()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var mocker = new AutoMocker();

            var companyService = mocker.CreateInstance<UserService>();

            Mock.Get( mocker.Get<IUserRepository>() )
                .Setup( e => e.Search( It.IsAny<Expression<Func<User , bool>>>() ) )
                .ReturnsAsync( new User [] { user } );

            //act
            var result = await companyService.Add( user );

            //Assert
            mocker.GetMock<IUserRepository>().Verify( r => r.Add( user ) , Times.Never );
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Should_not_add_a_company_if_already_exists_another_with_the_same_phone()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var secondUser = new User(
                   user.Name ,
                   "user@gmail.com" ,
                   user.Password ,
                   user.Cpf ,
                   user.BirthDate ,
                   user.Phone ,
                   user.Country 
                ); 
            var mocker = new AutoMocker();

            var companyService = mocker.CreateInstance<UserService>();

            Mock.Get( mocker.Get<IUserRepository>() )
                .Setup( e => e.Search( It.IsAny<Expression<Func<User , bool>>>() ) )
                .ReturnsAsync( new User [] { user } );

            //act
            var result = await companyService.Add( user );

            //Assert
            mocker.GetMock<IUserRepository>().Verify( r => r.Add( secondUser ) , Times.Never );
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Should_update_valid_user_correctly()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var mocker = new AutoMocker();

            var userService = mocker.CreateInstance<UserService>();

            //act
            var result = await userService.Update( user );

            //Assert
            mocker.GetMock<IUserRepository>().Verify( r => r.Update( user ) , Times.Once );
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_update_invalid_user()
        {
            //Arrange
            var user = _userFixture.CreateInvalidUser();
            var mocker = new AutoMocker();

            var userService = mocker.CreateInstance<UserService>();

            //act
            var result = await userService.Update( user );

            //Assert
            mocker.GetMock<IUserRepository>().Verify( r => r.Update( user ) , Times.Never );
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Should_delete_valid_user()
        {
            //Arrange
            var user = _userFixture.CreateValidUser();
            var mocker = new AutoMocker();

            var userService = mocker.CreateInstance<UserService>();

            //act
            var result = await userService.Delete( user );
            var result2 = await userService.Delete( user.Id );


            //Assert
            mocker.GetMock<IUserRepository>().Verify( r => r.Delete( user ) , Times.Once );
            mocker.GetMock<IUserRepository>().Verify( r => r.Delete( user.Id ) , Times.Once );

            result.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Fact]
        public async Task Should_not_delete_a_invalid_user()
        {
            //Arrange
            var user = _userFixture.CreateInvalidUser();
            var mocker = new AutoMocker();

            var userService = mocker.CreateInstance<UserService>();

            //act
            var result = await userService.Delete( user );

            //Assert
            mocker.GetMock<IUserRepository>().Verify( r => r.Delete( user ) , Times.Never );
            result.Should().BeFalse();
        }

    }
}
