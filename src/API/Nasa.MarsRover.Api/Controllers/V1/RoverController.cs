using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nasa.MarsRover.Application.Interfaces;
using Nasa.MarsRover.Application.ViewModels;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Nasa.MarsRover.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RoverController : MainController
    {
        private readonly IRoverAppService _roverAppService;
        
        public RoverController(IRoverAppService roverAppService)
        {
            _roverAppService = roverAppService;
        }

        [HttpPost]
        [SwaggerOperation("Cria o Rover")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitação inválida.")]
        public async Task<IActionResult> Post([FromBody] RoverViewModel request)
        {
            var result = _roverAppService.Create(request);
            return CustomResponse(result);
        }


        [HttpPut]
        [SwaggerOperation("Movimenta o Rover")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitação inválida.")]
        public async Task<IActionResult> Put([FromBody] RoverMovementViewModel request)
        {
            var result = _roverAppService.Movement(request);
            return CustomResponse(result);
        }

        [HttpGet]
        [SwaggerOperation("Obter localização do Rover")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna as coordenadas do Rover")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitação inválida.")]
        public async Task<IActionResult> Get([FromQuery] int roverId)
        {
            var result = _roverAppService.GetLocation(roverId);
            return CustomResponse(result);
        }
    }
}
