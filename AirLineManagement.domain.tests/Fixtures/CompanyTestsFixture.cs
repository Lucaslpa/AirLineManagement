
using Bogus;
using Bogus.Extensions.Brazil;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{

    [CollectionDefinition( nameof( CompanyFixtureCollection ) )]
    public class CompanyFixtureCollection : ICollectionFixture<CompanyTestsFixture>
    {
    }

    public class CompanyTestsFixture : IDisposable
    {
        public  Company CreateValidCompany()
        {
            var faker = new Faker( "pt_BR" );
            return new Company( faker.Company.CompanyName() + faker.Company.CompanySuffix() , 
                                faker.Company.Cnpj(), 
                                faker.Address.StreetAddress(),
                                 faker.Phone.PhoneNumberFormat(),
                                 faker.Internet.Email()
                                 );
        }

        public Company CreateInvalidCompany()
        {
            var faker = new Faker( "pt_BR" );
            return new Company( "sadad" ,
                                "334f2g" ,
                                "ff" ,
                                 "frt3432" ,
                                 "lsdla@"
                                 );
        }

        public void Dispose()
        {
        }
    }
   
}
