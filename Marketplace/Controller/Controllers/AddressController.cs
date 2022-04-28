using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    [HttpPost(Name = "registerAddress")]
    public object registerAddress(AddressDTO address)
    {
        return new object();
    }

    [HttpDelete(Name = "removeAddress")]
    public void removeAddress(AddressDTO address)
    {

    }

    [HttpPut(Name = "updateAddress")]
    public object updateAddress(AddressDTO address)
    {
        return new object();
    }
}
