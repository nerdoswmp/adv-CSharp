using Microsoft.AspNetCore.Mvc;
using DTO;
namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        [HttpGet("todos")]
        public void getAllStore()
        {
            Console.WriteLine("todos");            
        }
        [HttpPost("criar")]
        public StoreDTO registerStore([FromBody] StoreDTO store)
        {
            return store;
        }

        [HttpGet("informação")]
        public void getStoreInformation([FromBody] StoreDTO store)
        {
            Console.WriteLine(store.name);
            Console.WriteLine(store.CNPJ);
            Console.WriteLine(store.purchases);
            Console.WriteLine(store.owner.name);
        }
    }
}
