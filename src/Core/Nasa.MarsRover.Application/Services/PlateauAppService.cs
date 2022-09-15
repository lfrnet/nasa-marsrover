using Nasa.MarsRover.Application.Interfaces;
using Nasa.MarsRover.Application.ViewModels;
using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Model;

namespace Nasa.MarsRover.Application.Services
{   
    public class PlateauAppService : IPlateauAppService
    {
        private readonly IPlateauValidation _plateauValidation;

        public PlateauAppService(IPlateauValidation plateauValidation)
        {
            _plateauValidation = plateauValidation;
        }

        /// <summary>
        /// Cria o Platô
        /// </summary>
        /// <param name="request">Dimensões do platô</param>
        /// <returns></returns>
        public IValidationResult Create(PlateauViewModel request)
        {
            var plateau = new Plateau
            {
                Height = request.Height,
                Width = request.Width
            };

            //Valida Platô
            var result = _plateauValidation.Validate(plateau);

            if(result.IsValid)
                PlateauInMemory.Plateau = plateau;

            result.Data = plateau;
            return result;
        }
    }
}
