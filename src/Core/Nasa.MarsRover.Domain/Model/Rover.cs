using Nasa.MarsRover.Domain.Enums;

namespace Nasa.MarsRover.Domain.Model
{
    public class Rover
    {
        public int Id { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Direction Direction { get; set; }
    }
}
