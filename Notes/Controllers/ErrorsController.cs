using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}