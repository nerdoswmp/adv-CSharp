using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("owner")]
public class OwnerController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerOwner(OwnerDTO owner)
    {
        var nowner = Model.Owner.convertDTOToModel(owner);

        var id = nowner.save();
        return new
        {
            nome = owner.name,
            email = owner.email,
            senha = owner.passwd,
            documento = owner.document,
            telefone = owner.phone,
            login = owner.login,
            nascimento = owner.date_of_birth,
            endereco = owner.address,
            id = id
        };
    }

    [HttpGet]
    [Route("information")]
    public object getInformations()
    {
        Owner owner = new Owner();
        return owner.findById(1);
    }

}
