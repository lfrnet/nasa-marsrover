using Nasa.MarsRover.Application.ViewModels;
using Nasa.MarsRover.Domain.Interfaces;

namespace Nasa.MarsRover.Application.Interfaces
{
    public interface IPlateauAppService
    {
        IValidationResult Create(PlateauViewModel request);
    }
}
