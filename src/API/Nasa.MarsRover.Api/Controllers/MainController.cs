using Microsoft.AspNetCore.Mvc;
using Nasa.MarsRover.Domain.Interfaces;
using System.Linq;

namespace Nasa.MarsRover.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(IValidationResult result)
        {
            if (result.IsValid)
                return Ok(result.Data);

            return BadRequest(new { errors = result.Errors.Select(e => e) });
        }
    }
}
