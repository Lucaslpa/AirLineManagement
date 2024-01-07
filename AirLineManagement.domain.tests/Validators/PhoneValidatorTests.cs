using Bogus;
using Testes.domain.Validators;

namespace AirLineManagement.tests.Validators
{
    public class PhoneValidatorTests
    {
        [Fact]
        public void Should_Return_True_When_Phone_Is_Valid()
        {

            // Arrange
            var faker = new Faker( "pt_BR" );
            var phone = faker.Phone.PhoneNumberFormat();

            // Act
            var result = PhoneValidator.IsValid( phone );

            // Assert
            Assert.True( result );
        }

        [Fact]
        public void Should_Return_False_When_Phone_Is_Invalid()
        {
            // Arrange
            var phone = "11999999";

            // Act
            var result = PhoneValidator.IsValid( phone );

            // Assert
            Assert.False( result );
        }
    }
}
