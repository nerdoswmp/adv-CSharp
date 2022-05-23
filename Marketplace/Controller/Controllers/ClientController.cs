using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;

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

    [HttpGet]
    [Route("login")]
    public string loginClient([FromBody] ClientDTO client)
    {
        var nclient = Model.Client.convertDTOToModel(client);
        var id = nclient.loginClient(client.login,client.passwd);
        if(id == true)
        {
            return "LOGOUU!!";
        }
        else
        {
            return "NAO LOGOU";
        }
    }

    [HttpGet]
    [Route("information/{document}")]
    public object getInformations(string document)
    {
        return Client.findByDoc(document);
    }

}
