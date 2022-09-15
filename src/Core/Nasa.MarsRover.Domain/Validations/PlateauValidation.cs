using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Model;

namespace Nasa.MarsRover.Domain.Validations
{
    public class PlateauValidation : IPlateauValidation
    {
        private readonly IValidationResult _validationResult;

        public PlateauValidation(IValidationResult validationResult) =>
            _validationResult = validationResult;

        /// <summary>
        /// Valida o platô
        /// </summary>
        /// <param name="plateau">Platô a ser validado</param>
        /// <returns></returns>
        public IValidationResult Validate(Plateau plateau)
        {
            if (plateau.Height < 1)
                _validationResult.AddError("Plateau height must be greater than zero");

            if (plateau.Width < 1)
                _validationResult.AddError("Plateau width must be greater than zero");

            return _validationResult;
        }
    }
}
