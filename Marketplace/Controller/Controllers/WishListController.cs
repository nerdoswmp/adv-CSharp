using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers
{
    [ApiController]
    [Route("wishList")]
    public class WishListController : ControllerBase
    {

        [Authorize]
        [HttpPost]
        [Route("register")]
        public object addProductToWishList([FromBody] WishListDTO wishList)
        {
            var wishListModel = Model.WishList.convertDTOToModel(wishList);
            var id = 0;
            foreach(var stock in wishList.products)
            {

                id = wishListModel.save(wishList.client.login, stock);
            }          
            return new
            {
                id = id,
                client = wishList.client.login,
                produto = wishList.products,
            };
        }

        [Authorize]
        [HttpGet]
        [Route("all/{id}")]
        public IActionResult allWishlist(string id)
        {
            var wishlist = Model.WishList.getWishList(id);
            var result = new ObjectResult(wishlist);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;
        }

        [Authorize]
        [HttpDelete]
        [Route("remove")]
        public string removeProductToWishList([FromBody] WishListDTO request)
        {
            Model.WishList.convertDTOToModel(request).deleteWishList();
            return "produto removido com sucesso do WishList";
        }
    }
}

// 94238892346236852