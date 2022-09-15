using Nasa.MarsRover.Domain.Enums;
using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Model;
using System;
using System.Linq;

namespace Nasa.MarsRover.Domain.Validations
{
    public class RoverValidation : IRoverValidation
    {
        private readonly IValidationResult _validationResult;

        public RoverValidation(IValidationResult validationResult) =>
            _validationResult = validationResult;

        public IValidationResult Validate(int positionX, int positionY, string direction)
        {
            if (positionX < 0)
                _validationResult.AddError("Rover positionX must be greater than or equal to zero");

            if (positionY < 0)
                _validationResult.AddError("Rover positionY must be greater than or equal to zero");

            if(!Enum.TryParse(typeof(Direction), direction, out object result))
                _validationResult.AddError("The allowed directions are N, S, E, W");

            return _validationResult;
        }

        public IValidationResult Validate(int roverId)
        {
            //valida se o platô foi criado
            if (PlateauInMemory.Plateau is null)
            {
                _validationResult.AddError("Please create plateau");
                return _validationResult;
            }

            //Valida se o rover existe
            if (!PlateauInMemory.Plateau.Rovers.Any(x => x.Id == roverId))
                _validationResult.AddError("Rover does not exist! Please create rover");

            return _validationResult;
        }
    }
}
