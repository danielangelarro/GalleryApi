using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GalleryApi.API.Controllers;

public class ErrorsControllers : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<ExceptionHandlerFeature>()?.Error;

        return Problem(title: exception?.Message, statusCode: 500);
    }
}