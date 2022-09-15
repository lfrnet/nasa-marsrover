using Nasa.MarsRover.Domain.Interfaces;
using System.Collections.Generic;

namespace Nasa.MarsRover.Application.Interfaces
{
    public interface ICoordinatesAppSevice
    {
        IValidationResult Execute(string coordinates);
    }
}
