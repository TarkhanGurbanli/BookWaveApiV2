using BookWave.Service.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookWave.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> result)
    {
        return result.Status switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => Created(result.UrlAsCreated, result),
            _ => new ObjectResult(result) { StatusCode = result.Status.GetHashCode() }
        };
    }

    [NonAction]
    public IActionResult CreateActionResult(ServiceResult result)
    {
        return result.Status switch
        {
            HttpStatusCode.NoContent => new ObjectResult(null) { StatusCode = result.Status.GetHashCode() },
            _ => new ObjectResult(result) { StatusCode = result.Status.GetHashCode() }
        };
    }

    //[NonAction]
    //public IActionResult CreateActionResult(RegistrationResponse result)
    //    => new ObjectResult(result)
    //    {
    //        StatusCode = result.Flag
    //        ? (int)HttpStatusCode.OK
    //        : (int)HttpStatusCode.BadRequest
    //    };

    //[NonAction]
    //public IActionResult CreateActionResult(LoginResponse result)
    //    => new ObjectResult(result)
    //    {
    //        StatusCode = result.Flag
    //        ? (int)HttpStatusCode.OK
    //        : (int)HttpStatusCode.Unauthorized
    //    };
}