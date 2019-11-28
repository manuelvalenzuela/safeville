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
    public class UsersController : BaseController
    {
        public UsersController(ApplicationContext context)
        {
            Context.VehicleReportGateway = new VehicleReportGateway(context);
        }

        [HttpPost]
        [Route("ReportVehicle")]
        public async Task<IActionResult> Register([FromBody]Dtos.In.ReportVehicleRequest reportVehicleRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await ProcessResponse(() => ReportVehicleUseCase.Report(reportVehicleRequest));
        }
    }
}