using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet("todos")]
        public void allProducts()
        {
            Console.WriteLine("todos");          
        }
        [HttpPost("criar")]
        public ProductDTO createProduct([FromBody] ProductDTO product)
        {
            return product;
        }

        [HttpDelete("deletar")]
        public ProductDTO deleteProduct([FromBody] ProductDTO product)
        {
            return null;
        }
        [HttpPut("atualizar")]
        public ProductDTO updateProduct([FromBody] ProductDTO product)
        {
            return null;
        }
    }
}
