using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Model;
using Nasa.MarsRover.Domain.Validations;
using Xunit;

namespace Nasa.MarsRover.Test
{
    public class PlateauValidationTest
    {
        IPlateauValidation _plateauValidation;
        Plateau _plateau;

        #region Constructor
        public PlateauValidationTest()
        {
            _plateauValidation = new PlateauValidation(new ValidationResult());
            _plateau = new Plateau { Height = 5, Width = 5 };
        }
        #endregion

        #region Validate Plateau
        
        [Theory(DisplayName = "Valida com sucesso")]
        [InlineData(5, 5)]
        [InlineData(4, 10)]
        [InlineData(1, 4)]
        [InlineData(2, 5)]
        [Trait("Plateau", "Domain - Plateau Validation")]
        public void Must_Validate_Successfully(int height, int width)
        {
            // Arrange
            _plateau.Height = height;
            _plateau.Width = width;

            // Act
            var result = _plateauValidation.Validate(_plateau);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Theory(DisplayName = "Altura inválida")]
        [InlineData(0, 1)]
        [InlineData(-1, 2)]
        [InlineData(-3, 4)]
        [InlineData(-4, 5)]
        [Trait("Plateau", "Domain - Plateau Validation")]
        public void Must_Not_Validate_Invalid_Height(int height, int width)
        {
            // Arrange
            _plateau.Height = height;
            _plateau.Width = width;

            // Act
            var result = _plateauValidation.Validate(_plateau);

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains("Plateau height must be greater than zero", result.Errors);
            
        }

        [Theory(DisplayName = "Largura inválida")]
        [InlineData(5, 0)]
        [InlineData(4, -1)]
        [InlineData(1, -4)]
        [InlineData(2, -5)]
        [Trait("Plateau", "Domain - Plateau Validation")]
        public void Must_Not_Validate_Invalid_Width(int height, int width)
        {
            // Arrange
            _plateau.Height = height;
            _plateau.Width = width;

            // Act
            var result = _plateauValidation.Validate(_plateau);

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains("Plateau width must be greater than zero", result.Errors);
        }

        [Theory(DisplayName = "Altura e Largura inválidas")]
        [InlineData(0, 0)]
        [InlineData(-4, -1)]
        [InlineData(-1, -4)]
        [InlineData(-2, -5)]
        [Trait("Plateau", "Domain - Plateau Validation")]
        public void Must_Not_Validate_Invalid_Parameters(int height, int width)
        {
            // Arrange
            _plateau.Height = height;
            _plateau.Width = width;

            // Act
            var result = _plateauValidation.Validate(_plateau);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(2, result.Errors.Count);
            Assert.Contains("Plateau height must be greater than zero", result.Errors);
            Assert.Contains("Plateau width must be greater than zero", result.Errors);
        }
        #endregion
    }
}
