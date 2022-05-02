using Microsoft.AspNetCore.Mvc;
using DTO;
namespace Controller.Controllers
{
    [ApiController]
    [Route("wishList")]
    public class WishListController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public object addProductToWishList([FromBody] WishListDTO wishList)
        {
            var wishListModel = Model.WishList.convertDTOToModel(wishList);
            var id = 0;
            foreach(var product in wishList.products)
            {
                var idProduto = Model.Product.find(product);

                id = wishListModel.save(wishList.client.document, idProduto);
            }          
            return new
            {
                id = id,
                client = wishList.client.document,
                produto = wishList.products
            };
        }
        [HttpDelete("deletar")]
        public ProductDTO deleteProduct([FromBody] Object request)
        {
            return null;
        }
    }
}
