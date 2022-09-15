using Nasa.MarsRover.Domain.Model;

namespace Nasa.MarsRover.Domain.Interfaces
{
    public interface IRoverService
    {
        void TurnLeft(Rover rover);
        void TurnRight(Rover rover);
        void Move(Rover rover);
        string GetLocation(Rover rover);
    }
}
