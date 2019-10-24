namespace SafeVille.Api.Controllers
{
    using System.Threading.Tasks;
    using Core.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CommunitiesController : BaseController
    {
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