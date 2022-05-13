using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IActionResult allProducts()
        {
            var produtos = Model.Product.getProducts();
            var result = new ObjectResult(produtos);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return result;
        }

        [HttpPost]
        [Route("register")]
        public object createProduct([FromBody] ProductDTO product)
        {
            var productModel = Model.Product.convertDTOToModel(product);
            var id = productModel.save();
            return new
            {
                id = id,
                nome = product.name,
                codigoDeBarras = product.bar_code,
                descricao = product.description,
                imagem = product.image
            };
        }

        [HttpDelete]
        [Route("delete")]
        public string deleteProduct(ProductDTO product)
        {
            var nproduct = Model.Product.convertDTOToModel(product);
            nproduct.deleteProduct();
            return "produto deletado";
        }
        [HttpPut("atualizar/{bar_code}")]
        public string updateProduct(ProductDTO product, string bar_code)
        {
            var nProduct = Model.Product.convertDTOToModel(product);
            nProduct.updateProduct(bar_code);
            return "produto atualizado";
        }
    }
}
