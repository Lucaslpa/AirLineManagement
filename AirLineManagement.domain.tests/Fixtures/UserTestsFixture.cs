using Bogus;
using Bogus.Extensions.Brazil;
using Testes.domain.Model;

namespace Testes.domain.tests.Fixtures
{
    public class UserTestsFixture : IDisposable
    {

        public User CreateValidUser()
        {
            var faker = new Faker( "pt_BR" );
            return new User( faker.Name.FullName() , faker.Internet.Email() , faker.Internet.Password() , faker.Person.Cpf() , faker.Date.Past() , faker.Phone.PhoneNumber() , faker.Address.CountryCode() );
        }

        void IDisposable.Dispose()
        {
        }
    }
}
