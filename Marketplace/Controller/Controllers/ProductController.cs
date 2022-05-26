﻿using Microsoft.AspNetCore.Mvc;
using DTO;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [Route("{product}/{store}")]
        public IActionResult singleProduct(int product, int store)
        {
            var produto = Model.Product.findProduct(product, store);
            var result = new ObjectResult(produto);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return result;
        }

        [Authorize]
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

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public string deleteProduct(ProductDTO product)
        {
            var nproduct = Model.Product.convertDTOToModel(product);
            nproduct.deleteProduct();
            return "produto deletado";
        }
        [HttpPut("update/{bar_code}")]
        public string updateProduct(ProductDTO product, string bar_code)
        {
            var nProduct = Model.Product.convertDTOToModel(product);
            nProduct.updateProduct(bar_code);
            return "produto atualizado";
        }
    }
}
