using Nasa.MarsRover.Domain.Enums;
using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Model;
using Nasa.MarsRover.Domain.Services;
using Xunit;

namespace Nasa.MarsRover.Test.Domain
{
    public class RoverServiceTest
    {
        IRoverService _roverService; 
        Rover _rover;

        #region Constructor
        public RoverServiceTest()
        {
            _roverService = new RoverService();
            PlateauInMemory.Plateau = new Plateau { Height = 5, Width = 5 };
            _rover = new Rover { Id = 1, PositionX = 1, PositionY = 2, Direction = Direction.N };
            PlateauInMemory.Plateau.AddRover(_rover);
        }
        #endregion

        #region Rover Move

        [Fact(DisplayName = "Mover para o norte com sucesso")]
        [Trait("Rover", "Domain - Rover Move")]
        public void Must_Move_North_Successfully()
        {
            // Arrange
            _rover.PositionY = 2;
            _rover.Direction = Direction.N;

            // Act
            _roverService.Move(_rover);

            // Assert
            Assert.Equal(3, _rover.PositionY);
        }

        [Fact(DisplayName = "Mover para o sul com sucesso")]
        [Trait("Rover", "Domain - Rover Moviment")]
        public void Must_Move_South_Successfully()
        {
            // Arrange
            _rover.PositionY = 2;
            _rover.Direction = Direction.S;

            // Act
            _roverService.Move(_rover);

            // Assert
            Assert.Equal(1, _rover.PositionY);
        }

        [Fact(DisplayName = "Mover para o lest com sucesso")]
        [Trait("Rover", "Domain - Rover Moviment")]
        public void Must_Move_East_Successfully()
        {
            // Arrange
            _rover.PositionX = 1;
            _rover.Direction = Direction.E;

            // Act
            _roverService.Move(_rover);

            // Assert
            Assert.Equal(2, _rover.PositionX);
        }

        [Fact(DisplayName = "Mover para o oeste com sucesso")]
        [Trait("Rover", "Domain - Rover Moviment")]
        public void Must_Move_West_Successfully()
        {
            // Arrange
            _rover.PositionX = 1;
            _rover.Direction = Direction.W;

            // Act
            _roverService.Move(_rover);

            // Assert
            Assert.Equal(0, _rover.PositionX);
        }

        #endregion

        #region Rover TurnLeft

        [Fact(DisplayName = "Virar à esquerda direção norte com sucesso")]
        [Trait("Rover", "Domain - Rover TurnLeft")]
        public void Must_TurnLeft_North_Successfully()
        {
            // Arrange
            _rover.Direction = Direction.N;

            // Act
            _roverService.TurnLeft(_rover);

            // Assert
            Assert.Equal(Direction.W, _rover.Direction);
        }

        [Fact(DisplayName = "Virar à esquerda direção sul com sucesso")]
        [Trait("Rover", "Domain - Rover TurnLeft")]
        public void Must_TurnLeft_South_Successfully()
        {
            // Arrange
            _rover.Direction = Direction.S;

            // Act
            _roverService.TurnLeft(_rover);

            // Assert
            Assert.Equal(Direction.E, _rover.Direction);
        }

        [Fact(DisplayName = "Virar à esquerda direção leste com sucesso")]
        [Trait("Rover", "Domain - Rover TurnLeft")]
        public void Must_TurnLeft_East_Successfully()
        {
            // Arrange
            _rover.Direction = Direction.E;

            // Act
            _roverService.TurnLeft(_rover);

            // Assert
            Assert.Equal(Direction.N, _rover.Direction);
        }

        [Fact(DisplayName = "Virar à esquerda direção oeste com sucesso")]
        [Trait("Rover", "Domain - Rover TurnLeft")]
        public void Must_TurnLeft_West_Successfully()
        {
            // Arrange
            _rover.Direction = Direction.W;

            // Act
            _roverService.TurnLeft(_rover);

            // Assert
            Assert.Equal(Direction.S, _rover.Direction);
        }
        #endregion

        #region Rover TurnRight

        [Fact(DisplayName = "Virar à direta direção norte com sucesso")]
        [Trait("Rover", "Domain - Rover TurnRight")]
        public void Must_TurnRight_North_Successfully()
        {
            // Arrange
            _rover.Direction = Direction.N;

            // Act
            _roverService.TurnRight(_rover);

            // Assert
            Assert.Equal(Direction.E, _rover.Direction);
        }

        [Fact(DisplayName = "Virar à esquerda direção sul com sucesso")]
        [Trait("Rover", "Domain - Rover TurnLeft")]
        public void Must_TurnRight_South_Successfully()
        {
            // Arrange
            _rover.Direction = Direction.S;

            // Act
            _roverService.TurnRight(_rover);

            // Assert
            Assert.Equal(Direction.W, _rover.Direction);
        }

        [Fact(DisplayName = "Virar à esquerda direção leste com sucesso")]
        [Trait("Rover", "Domain - Rover TurnLeft")]
        public void Must_TurnRight_East_Successfully()
        {
            // Arrange
            _rover.Direction = Direction.E;

            // Act
            _roverService.TurnRight(_rover);

            // Assert
            Assert.Equal(Direction.S, _rover.Direction);
        }

        [Fact(DisplayName = "Virar à esquerda direção oeste com sucesso")]
        [Trait("Rover", "Domain - Rover TurnLeft")]
        public void Must_TurnRight_West_Successfully()
        {
            // Arrange
            _rover.Direction = Direction.W;

            // Act
            _roverService.TurnRight(_rover);

            // Assert
            Assert.Equal(Direction.N, _rover.Direction);
        }
        #endregion
    }
}
