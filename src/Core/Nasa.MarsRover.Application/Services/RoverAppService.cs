using Nasa.MarsRover.Application.Interfaces;
using Nasa.MarsRover.Application.ViewModels;
using Nasa.MarsRover.Domain.Enums;
using Nasa.MarsRover.Domain.Interfaces;
using Nasa.MarsRover.Domain.Model;
using System;
using System.Linq;

namespace Nasa.MarsRover.Application.Services
{
    public class RoverAppService : IRoverAppService
    {
        private readonly IRoverService _roverService;
        private readonly IRoverValidation _roverValidation;
       
        public RoverAppService(IRoverService roverService, IRoverValidation roverValidation)
        {
            _roverService = roverService;
            _roverValidation = roverValidation;
        }

        /// <summary>
        /// Cria o Rover
        /// </summary>
        /// <param name="request">Dados da posição e direção do rover</param>
        /// <returns></returns>
        public IValidationResult Create(RoverViewModel request)
        {
            var result = _roverValidation.Validate(request.PositionX, request.PositionY, request.Direction);

            //valida se o platô foi criado
            if (PlateauInMemory.Plateau is null)
                result.AddError("Please create plateau");

            if (result.IsValid)
            {
                var rover = new Rover
                {
                    PositionX = request.PositionX,
                    PositionY = request.PositionY,
                    Direction = (Direction)Enum.Parse(typeof(Direction), request.Direction)
                };

                rover.Id = PlateauInMemory.Plateau.Rovers.Count + 1;
                PlateauInMemory.Plateau.AddRover(rover);
                result.Data = rover;
            }
            
            return result;
        }

        /// <summary>
        /// Movimenta o Rover
        /// </summary>
        /// <param name="request">Coordenadas</param>
        /// <returns></returns>
        public IValidationResult Movement(RoverMovementViewModel request)
        {
            var result = _roverValidation.Validate(request.RoverId);

            if (!result.IsValid)
                return result;

            var rover = PlateauInMemory.Plateau.Rovers.First(x => x.Id == request.RoverId);
            var movements = request.Movements.ToCharArray();

            foreach (var movement in movements)
            {
                switch (movement)
                {
                    case 'L':
                        _roverService.TurnLeft(rover);
                        break;
                    case 'R':
                        _roverService.TurnRight(rover);
                        break;
                    case 'M':
                        _roverService.Move(rover);
                        break;
                    default:
                        result.AddError("Invalid coordinates");
                        return result;
                }
            }

            PlateauInMemory.Plateau.UpdateRover(rover);
            result.Data = rover;
            return result;
        }

        /// <summary>
        /// Retorna a localização do rover
        /// </summary>
        /// <param name="roverId">Identificação do rover</param>
        /// <returns></returns>
        public IValidationResult GetLocation(int roverId)
        {
            var result = _roverValidation.Validate(roverId);

            if (!result.IsValid)
                return result;

            var rover = PlateauInMemory.Plateau.Rovers.First(x => x.Id == roverId);

            result.Data = _roverService.GetLocation(rover);
            return result;
        }
    }
}
