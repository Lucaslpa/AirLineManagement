
using Bogus;
using Bogus.Extensions.Brazil;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{
    public class CompanyTestsFixture : IDisposable
    {
        public  Company CreateValidCompany()
        {
            var faker = new Faker( "pt_BR" );
            return new Company( faker.Company.CompanyName(), 
                                faker.Company.Cnpj(), 
                                faker.Address.StreetAddress(),
                                 faker.Phone.PhoneNumber(),
                                 faker.Internet.Email()
                                 );
        }

        public void Dispose()
        {
        }
    }
   
}
