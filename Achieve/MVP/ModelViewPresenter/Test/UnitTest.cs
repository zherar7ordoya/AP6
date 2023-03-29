using Xunit;
using App.Core;

namespace Test
{
    public class UnitTest
    {
		[Fact]
		public void Suma2mas2()
		{
			// Inicializa los datos
			var vista = new CEmulador();
			var sut = new CPresentador(vista);

			// Ejecuta el método a probar (SUT: System Under Test)
			sut.PresionaBotonNumero("2");
			sut.PresionaBotonOperacion("+ / =");
			sut.PresionaBotonNumero("2");
			sut.PresionaBotonOperacion("+ / =");

			// Comprueba el resultado
			Assert.Equal("4", vista.TextoPantalla);
		}

		[Fact]
		public void Multiplica3x3()
		{
			// Arrange: inicializa
			var view = new CEmulador();
			var sut = new CPresentador(view);

			// Act: ejecuta
			sut.PresionaBotonNumero("3");
			sut.PresionaBotonOperacion("x");
			sut.PresionaBotonNumero("3");
			sut.PresionaBotonOperacion("+ / =");

			// Assert: comprueba
			Assert.Equal("9", view.TextoPantalla);
		}

		[Fact]
		public void Suma3Numeros()
		{
			// Arrange
			var view = new CEmulador();
			var sut = new CPresentador(view);

			// Act
			sut.PresionaBotonNumero("2");
			sut.PresionaBotonOperacion("+ / =");
			sut.PresionaBotonNumero("3");
			sut.PresionaBotonOperacion("+ / =");
			sut.PresionaBotonNumero("4");
			sut.PresionaBotonOperacion("+ / =");

			// Assert
			Assert.Equal("9", view.TextoPantalla);
		}
	}
}
