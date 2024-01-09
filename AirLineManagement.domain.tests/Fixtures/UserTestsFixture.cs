using Bogus;
using Bogus.Extensions.Brazil;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{
    [CollectionDefinition( nameof( UserFixtureCollection ) )]
    public class UserFixtureCollection : ICollectionFixture<UserTestsFixture>
    {
    }

    public class UserTestsFixture : IDisposable
    {

        public User CreateValidUser()
        {
            var faker = new Faker( "pt_BR" );
            return new User( faker.Name.FullName() , faker.Internet.Email() , faker.Internet.Password() , faker.Person.Cpf() , faker.Date.Past() , faker.Phone.PhoneNumberFormat() , faker.Address.CountryCode() );
        }

        public User CreateInvalidUser()
        {
            var faker = new Faker( "pt_BR" );
            return new User( "" , "FFF" , "ASD" , "43R3R" , faker.Date.Past() , "3423424" , "32" );
        }

        void IDisposable.Dispose()
        {
        }
    }
}
