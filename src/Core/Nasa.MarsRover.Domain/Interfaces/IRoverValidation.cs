
namespace Nasa.MarsRover.Domain.Interfaces
{
    public interface IRoverValidation
    {
        IValidationResult Validate(int positionX, int positionY, string direction);
        IValidationResult Validate(int roverId);
    }
}
