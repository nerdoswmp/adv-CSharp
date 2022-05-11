using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
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
        [HttpDelete]
        [Route("remove")]
        public string removeProductToWishList([FromBody] WishListDTO request)
        {
            Model.WishList.convertDTOToModel(request).deleteWishList();
            return "produto removido com sucesso do WishList";
        }
    }
}
