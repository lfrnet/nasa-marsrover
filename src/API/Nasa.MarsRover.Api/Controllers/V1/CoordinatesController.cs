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
    public class CoordinatesController : MainController
    {
        private readonly ICoordinatesAppSevice _coordinatesAppSevice;

        public CoordinatesController(ICoordinatesAppSevice coordinatesAppSevice)
        {
            _coordinatesAppSevice = coordinatesAppSevice;
        }

        [HttpPost]
        [SwaggerOperation("Cria platô, cria e movimenta o rover")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a localização do rover")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitação inválida.")]
        public async Task<IActionResult> Post([FromBody, 
            SwaggerRequestBody("Informe as coordenadas exemplo: 5 5 1 2 N LMLMLMLMM 3 3 E MMRMMRMRRM", Required = true)] string coordinatesRequest)
        {
            var result = _coordinatesAppSevice.Execute(coordinatesRequest);
            return CustomResponse(result);
        }
    }
}
