//using Microsoft.AspNetCore.Mvc;
//using DTO;

//namespace Controller.Controllers
//{
//    [ApiController]
//    [Route("product")]
//    public class ProductController : ControllerBase
//    {
//        [HttpGet("todos")]
//        public void allProducts()
//        {
//            Console.WriteLine("todos");
//        }

//        [HttpPost]
//        [Route("register")]
//        public object createProduct([FromBody] ProductDTO product)
//        {
//            var productModel = Model.Product.convertDTOToModel(product);
//            var id = productModel.save();
//            return new
//            {
//                id = id,
//                nome = product.name,
//                codigoDeBarras = product.bar_code
//            };
//        }

//        [HttpDelete("deletar")]
//        public ProductDTO deleteProduct([FromBody] ProductDTO product)
//        {
//            return null;
//        }
//        [HttpPut("atualizar")]
//        public ProductDTO updateProduct([FromBody] ProductDTO product)
//        {
//            return null;
//        }
//    }
//}
