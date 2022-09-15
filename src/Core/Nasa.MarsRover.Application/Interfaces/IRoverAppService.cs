using Nasa.MarsRover.Application.ViewModels;
using Nasa.MarsRover.Domain.Interfaces;

namespace Nasa.MarsRover.Application.Interfaces
{
    public interface IRoverAppService
    {
        IValidationResult Create(RoverViewModel request);
        IValidationResult Movement(RoverMovementViewModel request);
        IValidationResult GetLocation(int roverId);
    }
}
