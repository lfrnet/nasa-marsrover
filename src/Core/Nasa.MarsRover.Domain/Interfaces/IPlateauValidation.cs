using Nasa.MarsRover.Domain.Model;

namespace Nasa.MarsRover.Domain.Interfaces
{
    public interface IPlateauValidation
    {
        IValidationResult Validate(Plateau plateau);
    }
}
