namespace SafeVille.Api.Controllers
{
    using System.Threading.Tasks;
    using Core.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : BaseController
    {
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]Dtos.In.VehicleRegistrationRequest vehicleRegistrationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await ProcessResponse(() => RegisterKnownVehicleUseCase.Register(vehicleRegistrationRequest));
        }
    }
}