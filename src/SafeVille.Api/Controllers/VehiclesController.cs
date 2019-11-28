namespace SafeVille.Api.Controllers
{
    using System.Threading.Tasks;
    using Core;
    using Core.UseCases;
    using Data;
    using Data.Gateways;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : BaseController
    {
        public VehiclesController(ApplicationContext context)
        {
            Context.UserGateway = new UserGateway(context);
            Context.VehicleGateway = new VehicleGateway(context);
        }

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