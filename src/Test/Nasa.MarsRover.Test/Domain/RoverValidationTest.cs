using Nasa.MarsRover.Domain.Enums;
using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Model;
using Nasa.MarsRover.Domain.Validations;
using System.Collections.Generic;
using Xunit;

namespace Nasa.MarsRover.Test
{
    public class RoverValidationTest
    {
        IRoverValidation _roverValidation;
        Rover _rover;

        #region Constructor
        public RoverValidationTest()
        {
            _roverValidation = new RoverValidation(new ValidationResult());
            PlateauInMemory.Plateau = new Plateau { Height = 5, Width = 5 };
            _rover = new Rover { Id = 1, PositionX = 1, PositionY = 2, Direction = Direction.N };
            PlateauInMemory.Plateau.AddRover(_rover);
        }
        #endregion

        #region Move

        [Theory(DisplayName = "Move com sucesso")]
        [InlineData(0, 1, "N")]
        [InlineData(1, 2, "S")]
        [InlineData(3, 4, "E")]
        [InlineData(4, 5, "W")]
        [Trait("Rover", "Domain - Rover Validation")]
        public void Must_Validate_Successfully(int positionX, int positionY, string direction)
        {
            //

            // Act
            var result = _roverValidation.Validate(positionX, positionY, direction);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Theory(DisplayName = "Posi��o x inv�lida")]
        [InlineData(-1, 2, "N")]
        [InlineData(-2, 2, "S")]
        [InlineData(-3, 4, "E")]
        [InlineData(-4, 5, "W")]
        [Trait("Rover", "Domain - Rover Validation")]
        public void Must_Not_Validate_Invalid_PositionX(int positionX, int positionY, string direction)
        {
            // Act
            var result = _roverValidation.Validate(positionX, positionY, direction);

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains("Rover positionX must be greater than or equal to zero", result.Errors);
        }

        [Theory(DisplayName = "Posi��o y inv�lida")]
        [InlineData(1, -2, "N")]
        [InlineData(2, -2, "S")]
        [InlineData(3, -4, "E")]
        [InlineData(4, -5, "W")]
        [Trait("Rover", "Domain - Rover Validation")]
        public void Must_Not_Validate_Invalid_PositionY(int positionX, int positionY, string direction)
        {
            // Act
            var result = _roverValidation.Validate(positionX, positionY, direction);

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains("Rover positionY must be greater than or equal to zero", result.Errors);
        }

        [Theory(DisplayName = "Dire��o inv�lida")]
        [InlineData(0, 1, "T")]
        [InlineData(1, 2, "F")]
        [InlineData(3, 4, "G")]
        [InlineData(4, 5, "A")]
        [Trait("Rover", "Domain - Rover Validation")]
        public void Must_Not_Validate_Invalid_Direction(int positionX, int positionY, string direction)
        {
            // Act
            var result = _roverValidation.Validate(positionX, positionY, direction);

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains("The allowed directions are N, S, E, W", result.Errors);
        }

        [Theory(DisplayName = "Posi��o X, posi��o Y e Dire��o inv�lidas")]
        [InlineData(-1, -2, "T")]
        [InlineData(-2, -2, "F")]
        [InlineData(-3, -4, "G")]
        [InlineData(-4, -5, "A")]
        [Trait("Rover", "Domain - Rover Validation")]
        public void Must_Not_Validate_Invalid_Parameters(int positionX, int positionY, string direction)
        {
            // Act
            var result = _roverValidation.Validate(positionX, positionY, direction);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(3, result.Errors.Count);
            Assert.Contains("Rover positionX must be greater than or equal to zero", result.Errors);
            Assert.Contains("Rover positionY must be greater than or equal to zero", result.Errors);
            Assert.Contains("The allowed directions are N, S, E, W", result.Errors);
        }
        #endregion

        #region Validate RoverId

        [Fact(DisplayName = "Valida roveId com sucesso")]
        [Trait("Rover", "Domain - Rover Validation")]
        public void Must_Validate_RoverId_Successfully()
        {
            // Act
            var result = _roverValidation.Validate(_rover.Id);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact(DisplayName = "Plat� n�o foi criado")]
        [Trait("Rover", "Domain - Rover Validation")]
        public void Must_Validate_RoverId_Plateau_NotFound()
        {
            // Arrange
            PlateauInMemory.Plateau = null;

            // Act
            var result = _roverValidation.Validate(_rover.Id);

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains("Please create plateau", result.Errors);
        }

        [Fact(DisplayName = "Rover n�o existe")]
        [Trait("Rover", "Domain - Rover Validation")]
        public void Must_Validate_RoverId_Rover_NotFound()
        {
            // Arrange
            PlateauInMemory.Plateau.Rovers = new List<Rover>();

            // Act
            var result = _roverValidation.Validate(_rover.Id);

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains("Rover does not exist! Please create rover", result.Errors);
        }
        #endregion
    }
}
