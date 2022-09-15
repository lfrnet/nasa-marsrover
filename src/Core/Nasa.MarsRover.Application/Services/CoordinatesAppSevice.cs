using Nasa.MarsRover.Application.Interfaces;
using Nasa.MarsRover.Application.ViewModels;
using Nasa.MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.MarsRover.Application.Services
{
    public class CoordinatesAppSevice : ICoordinatesAppSevice
    {
        private readonly IPlateauAppService _plateauAppService;
        private readonly IRoverAppService _roverAppService;
        private readonly IValidationResult _result;
        
        public CoordinatesAppSevice(IPlateauAppService plateauAppService, IRoverAppService roverAppService, IValidationResult result)
        {
            _plateauAppService = plateauAppService;
            _roverAppService = roverAppService;
            _result = result;
        }

        public IValidationResult Execute(string coordinates)
        {
            List<string> locations = new List<string>();

            try
            {
                var info = coordinates.Split(' ');
                var height = int.Parse(info[0]);
                var width = int.Parse(info[1]);

                //Cria o Platô
                var resultPlateau = _plateauAppService.Create(new PlateauViewModel { Height = height, Width = width });

                if (!resultPlateau.IsValid)
                    return resultPlateau;

                for (int i = 2; i < info.Length; i++)
                {
                    var roverPositionX = int.Parse(info[i++]);
                    var roverPositionY = int.Parse(info[i++]);
                    var roverDirection = info[i++];
                    var roverMovements = info[i];

                    var request = new RoverViewModel
                    {
                        PositionX = roverPositionX,
                        PositionY = roverPositionY,
                        Direction = roverDirection
                    };

                    //Cria o Rover
                    var resultRover = _roverAppService.Create(request);

                    if (!resultRover.IsValid)
                        return resultRover;

                    //Movimenta o rover
                    var resultMovement = _roverAppService.Movement(new RoverMovementViewModel { Movements = roverMovements, RoverId = resultRover.Data.Id });

                    if (!resultMovement.IsValid)
                        return resultMovement;

                    //Exibe a localização do rover
                    var resultLocation = _roverAppService.GetLocation(resultRover.Data.Id);

                    if (!resultLocation.IsValid)
                        return resultLocation;

                    locations.Add(resultLocation.Data);
                }

                _result.Data = locations;
            }
            catch (Exception ex)
            {
                _result.AddError($"Invalid coordinates! Error: {ex.Message}");
            }

            return _result;
        }
    }
}
