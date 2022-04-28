using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController : ControllerBase
{
    [HttpPost(Name = "registerOwner")]
    public object registerOwner(OwnerDTO owner)
    {
        return new object();
    }

    [HttpGet(Name = "getInformations")]
    public object getInformations()
    {
        return new object();
    }

}
