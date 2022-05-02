using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerClient(ClientDTO client)
    {
        var nclient = Model.Client.convertDTOToModel(client);

        var id = nclient.save();
        return new
        {
            nome = client.name,
            email = client.email,
            senha = client.passwd,
            documento = client.document,
            telefone = client.phone,
            login = client.login,
            nascimento = client.date_of_birth,
            endereco = client.address,
            id = id
        };
    }

    [HttpPost]
    [Route("information")]
    public object getInformations()
    {
        return new object();
    }

}
