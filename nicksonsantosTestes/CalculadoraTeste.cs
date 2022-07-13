using nicksonsantos.Pages;

namespace nicksonsantosTests
{
    public class CalculadoraTeste
    {
        Calculadora calculadora;

        public CalculadoraTeste() => calculadora = new();

        [Fact]
        public void ValidaSomaUmMaisUmIgualADois()
        {
            // Arrange


            // Act
            calculadora.Escreve(1);
            calculadora.CliqueEmOperador('+');
            calculadora.Escreve(1);
            calculadora.Igual();
            
            // Assert
            Assert.Equal("2", calculadora.Visor);
        }

        [Fact]
        public void ValidaSubtracaoUmMenosUmIgualAZero()
        {
            // Arrange


            // Act
            calculadora.Escreve(1);
            calculadora.CliqueEmOperador('-');
            calculadora.Escreve(1);
            calculadora.Igual();

            // Assert
            Assert.Equal("0", calculadora.Visor);
        }

        [Fact]
        public void ValidaMultiplicacaoTresVezesTresIgualANove()
        {
            // Arrange


            // Act
            calculadora.Escreve(3);
            calculadora.CliqueEmOperador('x');
            calculadora.Escreve(3);
            calculadora.Igual();

            // Assert
            Assert.Equal("9", calculadora.Visor);
        }

        [Fact]
        public void ValidaDivisaoDozeDivididoPorTresIgualAQuatro()
        {
            // Arrange


            // Act
            calculadora.Escreve(12);
            calculadora.CliqueEmOperador('%');
            calculadora.Escreve(3);
            calculadora.Igual();

            // Assert
            Assert.Equal("4", calculadora.Visor);
        }

        [Fact]
        public void ValidaBotaoApagarEscreveCentoEVinteETresApagaEFicaDoze()
        {
            // Arrange


            // Act
            calculadora.Escreve(1);
            calculadora.Escreve(2);
            calculadora.Escreve(3);
            calculadora.Apaga();

            // Assert
            Assert.Equal("12", calculadora.Visor);
        }


        [Theory]
        [InlineData('+')]
        [InlineData('-')]
        [InlineData('x')]
        [InlineData('%')]
        public void AoApertarOperadorDuasVezesManterZeroEOperador(char operador)
        {
            // Arrange


            // Act
            calculadora.CliqueEmOperador(operador);
            calculadora.CliqueEmOperador(operador);

            // Assert
            Assert.Equal("0" + operador.ToString(), calculadora.VisorOperacao);
        }

        [Fact]
        public void ClicarZeroVariasVezesMantemZero()
        {
            // Arrange


            // Act
            calculadora.Escreve(0);
            calculadora.Escreve(0);
            calculadora.Escreve(0);

            // Assert
            Assert.Equal("0", calculadora.Visor);
        }

        [Fact]
        public void ClicarZeroDepoisVirgulaDepoisZeroMostraZeroVirgulaZero()
        {
            // Arrange


            // Act
            calculadora.Escreve(0);
            calculadora.Escreve(',');
            calculadora.Escreve(0);

            // Assert
            Assert.Equal("0,0", calculadora.Visor);
        }

        [Fact]
        public void ClicarEmNumeroDepoisMaisEDepoisIgualSomaONumeroAEleMesmo()
        {
            // Arrange


            // Act
            calculadora.Escreve(3);
            calculadora.CliqueEmOperador('+');
            calculadora.Igual();

            // Assert
            Assert.Equal("6", calculadora.Visor);
            Assert.Equal("3+3=", calculadora.VisorOperacao);
        }

        [Theory]
        [InlineData('+', '-')]
        [InlineData('-', 'x')]
        [InlineData('x', '%')]
        [InlineData('%', '+')]
        public void ClicarEmOperadorDepoisClicarEmOutroOperadorMudaOperador(char operadorUm, char operadorDois)
        {
            // Act
            calculadora.CliqueEmOperador(operadorUm);
            calculadora.CliqueEmOperador(operadorDois);

            // Assert
            Assert.Equal("0" + operadorDois, calculadora.VisorOperacao);
        }

        [Fact]
        public void ClicarUmMaisUmMaisUmCalculaSemClicarIgual()
        {
            // Act
            calculadora.Escreve(1);
            calculadora.CliqueEmOperador('+');
            calculadora.Escreve(1);
            calculadora.CliqueEmOperador('+');

            // Assert
            Assert.Equal("2+", calculadora.VisorOperacao);
            Assert.Equal("", calculadora.Visor);
        }

    }
}