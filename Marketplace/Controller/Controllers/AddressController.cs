using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers;

[ApiController]
[Route("address")]
public class AddressController : ControllerBase
{

    [Authorize]
    [HttpPost]
    [Route("register")]
    public object registerAddress(AddressDTO address)
    {
        var naddress = Model.Address.convertDTOToModel(address);

        var id = naddress.save();
        return new
        {
            rua = address.street,
            estado = address.state,
            cidade = address.city,
            pais = address.country,
            codigoPostal = address.postal_code,
            id = id
        };
    }

    [Authorize]
    [HttpDelete]
    [Route("remove")]
    public void removeAddress(AddressDTO address)
    {
        var naddress = Model.Address.convertDTOToModel(address);

        naddress.deleteAddress();
    }

    [Authorize]
    [HttpPut]
    [Route("update/{doc}")]
    public string updateAddress(AddressDTO address, string doc)
    {
        var naddress = Model.Address.convertDTOToModel(address);

        naddress.updateAddress(doc);

        return "endereco atualizado";
    }
}
