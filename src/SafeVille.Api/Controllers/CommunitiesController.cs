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
    public class CommunitiesController : BaseController
    {
        public CommunitiesController(ApplicationContext context)
        {
            Context.CommunityGateway = new CommunityGateway(context);
            Context.UserGateway = new UserGateway(context);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]Dtos.In.CreateCommunityRequest createCommunityRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await ProcessResponse(() => CreateCommunityUseCase.Create(createCommunityRequest));
        }
    }
}