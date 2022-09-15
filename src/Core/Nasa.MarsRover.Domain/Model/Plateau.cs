using System.Collections.Generic;
using System.Linq;

namespace Nasa.MarsRover.Domain.Model
{
    public class Plateau
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Rover> Rovers { get; set; } = new List<Rover>();

        public void AddRover(Rover rover)
        {
            Rovers.Add(rover);
        }

        public void UpdateRover(Rover rover)
        {
            Rovers.Remove(Rovers.First(x => x.Id == rover.Id));
            Rovers.Add(rover);
        }
    }
}
