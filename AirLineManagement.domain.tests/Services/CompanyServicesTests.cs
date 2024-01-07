

using AirLineManagement.domain.Services;
using Moq;
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
       public async Task Should_add_company_correctly()
        {
            //Arrange
            var company = _companyFixture.CreateValidCompany();
            var mockCompanyRepository = new Mock<ICompanyRepository>();
            var mockNotifier = new Mock<INotifier>(); 
            var companyService = new CompanyService(mockCompanyRepository.Object, mockNotifier .Object);

            //act
            var result = await companyService.Add(company);

            //Assert
            mockCompanyRepository.Verify(r => r.Add(company), Times.Once);
            Assert.True(result);
        }

    }
}
