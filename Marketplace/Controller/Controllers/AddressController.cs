//using Microsoft.AspNetCore.Mvc;
//using DTO;
//using Model;

//namespace Controller.Controllers;

//[ApiController]
//[Route("address")]
//public class AddressController : ControllerBase
//{
//    [HttpPost]
//    [Route("register")]
//    public object registerAddress([FromBody] AddressDTO address)
//    {
//        var Address = Model.Address.convertDTOToModel(address);

//        var id = Address.save();
//        return new
//        {
//            rua = address.street,
//            estado = address.state,
//            cidade = address.city,
//            pais = address.country,
//            codigoPostal = address.postal_code,
//            id = id
//        };
//    }

//    [HttpDelete(Name = "removeAddress")]
//    public void removeAddress(AddressDTO address)
//    {

//    }

//    [HttpPut(Name = "updateAddress")]
//    public object updateAddress(AddressDTO address)
//    {
//        return new object();
//    }
//}
