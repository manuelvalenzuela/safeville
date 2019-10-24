namespace SafeVille.Api.Controllers
{
    using System.Threading.Tasks;
    using Core.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
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