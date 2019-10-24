namespace SafeVille.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Core.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : ControllerBase
    {
        protected async Task<IActionResult> ProcessResponse<T>(Func<Task<T>> func)
        {
            try
            {
                return await ProcessSuccess(func);
            }
            catch (AppException e)
            {
                return BadRequest(e.ApiReturn);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        private async Task<IActionResult> ProcessSuccess<T>(Func<Task<T>> func)
        {
            var result = await Task.Run(func);
            if (result != null)
            {
                return Ok(new
                {
                    Result = result,
                    ResultCode = 0
                });
            }

            return Ok(new
            {
                Result = default(T),
                ResultCode = 1
            });
        }
    }
}