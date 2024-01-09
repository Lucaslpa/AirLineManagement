

using AirLineManagement.domain.Services;
using Moq;
using Moq.AutoMock;
using System.Linq.Expressions;
using Testes.domain.Interfaces;
using Testes.domain.Interfaces.Repositories;
using Testes.domain.Model;
using Testes.domain.tests.Fixtures;

namespace AirLineManagement.tests.Services
{
    [Collection(nameof( CompanyFixtureCollection ) )]
    public class CompanyServicesTests(CompanyTestsFixture companyTestsFixture)
    {

        private readonly CompanyTestsFixture _companyFixture = companyTestsFixture;


        [Fact]
       public async Task Should_add_valid_company_correctly()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var mocker = new AutoMocker();
            var companyService = mocker.CreateInstance<CompanyService>();

            //act
            var result = await companyService.Add(company);

            //Assert
            mocker.GetMock<ICompanyRepository>().Verify(r => r.Add(company), Times.Once);
            Assert.True(result);
        }


        [Fact]
        public async Task Should_not_add_invalid_company()
        {
            //Arrange
            var company = _companyFixture.CreateInvalidCompany();
            var mocker = new AutoMocker();

            var companyService = mocker.CreateInstance<CompanyService>();

            //act
            var result = await companyService.Add( company );

            //Assert
            mocker.GetMock<ICompanyRepository>().Verify( r => r.Add( company ) , Times.Never );
            Assert.False( result );
        }

        [Fact]
        public async Task Should_not_add_a_company_if_already_exists_another_the_same_cnpj()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var mocker = new AutoMocker();

            var companyService = mocker.CreateInstance<CompanyService>();

            Mock.Get( mocker.Get<ICompanyRepository>() )
                .Setup( e => e.Search( It.IsAny<Expression<Func<Company , bool>>>() ) )
                .ReturnsAsync( new Company [] { company } );

            //act
            var result = await companyService.Add( company );

            //Assert
            mocker.GetMock<ICompanyRepository>().Verify( r => r.Add( company ) , Times.Never );
            Assert.False( result );
        }

        [Fact]
        public async Task Should_update_valid_company_correctly()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var mocker = new AutoMocker();

            var companyService = mocker.CreateInstance<CompanyService>();

            //act
            var result = await companyService.Update( company );

            //Assert
            mocker.GetMock<ICompanyRepository>().Verify( r => r.Update( company ) , Times.Once );
            Assert.True( result );
        }

        [Fact]
        public async Task Should_not_update_invalid_company()
        {
            //Arrange
            var company = _companyFixture.CreateInvalidCompany();
            var mocker = new AutoMocker();

            var companyService = mocker.CreateInstance<CompanyService>();

            //act
            var result = await companyService.Update( company );

            //Assert
            mocker.GetMock<ICompanyRepository>().Verify( r => r.Update( company ) , Times.Never );
            Assert.False( result );
        }



        [Fact]
        public async Task Should_delete_valid_company()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var mocker = new AutoMocker();

            var companyService = mocker.CreateInstance<CompanyService>();

            //act
            var result = await companyService.Delete( company );
            var result2 = await companyService.Delete( company.Id );


            //Assert
            mocker.GetMock<ICompanyRepository>().Verify( r => r.Delete( company ) , Times.Once );
            mocker.GetMock<ICompanyRepository>().Verify( r => r.Delete( company.Id ) , Times.Once );

            Assert.True( result );
        }


    }
}
