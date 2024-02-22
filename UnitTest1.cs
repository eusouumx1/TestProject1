
using ConsoleApp5;
using FluentValidation;
using FluentAssertions;

namespace TestProject1
    
{
    public class UnitTest1
    {
        [Fact]
        public void Motorista_String_StartWith()
        {
            //arrange
            var listaPessoas = new List<Pessoa>()
            {
                new Pessoa("Pedro", 20, true),
                new Pessoa("Lucas", 17, false),
                new Pessoa("Kaue", 20, true),
                new Pessoa("Fernando", 10, false),
                new Pessoa("Black", 5, false)
            };
            var Motorista = new Motorista();

            //act
            var result = Motorista.EncontrarMotoristas(listaPessoas);
            
            //assert
            result.Should().StartWith("Uhuu! Os motoristas são");

        }
        [Fact]
        public void Motorista_Exception_ShouldThrowExceptionWithMessage()
        {
            //arrange
            var listaPessoas = new List<Pessoa>()
            {
                new Pessoa("Pedro", 20, false),
                new Pessoa("Lucas", 17, true),
                new Pessoa("Kaue", 20, false),
                new Pessoa("Fernando", 10, true),
                new Pessoa("Black", 5, true)
            };
            var Motorista = new Motorista();

            //act
            var result = () => Motorista.EncontrarMotoristas(listaPessoas);


            //assert
            result.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");


        }
    }
}