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
        public IActionResult addProductToWishList([FromBody] WishlistSaveDTO wishList)
        {            
            WishList wishListModel = new WishList();
            var id = 0;            
                id = wishListModel.save(wishList);

            return new ObjectResult(new
            {
                id = id
            });
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