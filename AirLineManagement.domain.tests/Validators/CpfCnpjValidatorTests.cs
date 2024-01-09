

using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using Testes.domain.Validators;

namespace AirLineManagement.tests.Validators
{
    public class CpfCnpjValidatorTests
    {

        [Fact]
        public void Should_return_false_when_cpf_is_invalid()
        {
            //Arrange
            var cpf = "342535345";

            //Act
            var result = CpfCnpjValidator.CpfIsValid( cpf );

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Should_return_true_when_cpf_is_valid()
        {
            //Arrange
            var faker = new Faker( "pt_BR" );
            var cpf = faker.Person.Cpf();

            //Act
            var result = CpfCnpjValidator.CpfIsValid( cpf );

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Should_return_false_when_cnpj_is_invalid()
        {
            //Arrange
            var cnpj = "342535345";

            //Act
            var result = CpfCnpjValidator.CnpjIsValid( cnpj );

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Should_return_true_when_cnpj_is_valid()
        {
            //Arrange
            var faker = new Faker( "pt_BR" );
            var cnpj = faker.Company.Cnpj();

            //Act
            var result = CpfCnpjValidator.CnpjIsValid( cnpj );

            //Assert
            result.Should().BeTrue();
        }
    }
}
