using Nasa.MarsRover.Domain.Enums;
using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Model;

namespace Nasa.MarsRover.Domain.Services
{
    public class RoverService : IRoverService
    {
        public void Move(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.PositionY += 1;
                    break;
                case Direction.S:
                    rover.PositionY -= 1;
                    break;
                case Direction.E:
                    rover.PositionX += 1;
                    break;
                case Direction.W:
                    rover.PositionX -= 1;
                    break;
                default:
                    break;
            }
        }

        public void TurnLeft(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.Direction = Direction.W;
                    break;
                case Direction.S:
                    rover.Direction = Direction.E;
                    break;
                case Direction.E:
                    rover.Direction = Direction.N;
                    break;
                case Direction.W:
                    rover.Direction = Direction.S;
                    break;
                default:
                    break;
            }
        }

        public void TurnRight(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.Direction = Direction.E;
                    break;
                case Direction.S:
                    rover.Direction = Direction.W;
                    break;
                case Direction.E:
                    rover.Direction = Direction.S;
                    break;
                case Direction.W:
                    rover.Direction = Direction.N;
                    break;
                default:
                    break;
            }
        }

        public string GetLocation(Rover rover)
        {
            return $"{rover.PositionX} {rover.PositionY} {rover.Direction}";
        }
    }
}
