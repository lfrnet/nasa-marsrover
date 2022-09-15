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
    public class PlateauController : MainController
    {
        private readonly IPlateauAppService _plateauAppService;

        public PlateauController(IPlateauAppService plateauAppService)
        {
            _plateauAppService = plateauAppService;
        }

        [HttpPost]
        [SwaggerOperation("Cria o Platô")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitação inválida.")]
        public async Task<IActionResult> Post([FromBody] PlateauViewModel request)
        {
            var result = _plateauAppService.Create(request);
            return CustomResponse(result);
        }
    }
}
