using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace DelegateInFormInputMemoryLeak.Controllers;

[ApiController]
[Route("api/test/[action]")]
public class TestApiController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromForm] SomeViewModel _)
    {
        // do stuff

        return Ok();
    }
}

public class SomeViewModel
{
    // Using this with [FromForm] causes memory leak
    [BindNever, ValidateNever, JsonIgnore] // does not fix it
    public Func<string> Func { get; set; }
}