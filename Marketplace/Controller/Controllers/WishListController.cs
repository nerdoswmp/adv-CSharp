using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Controller.Controllers
{
    [ApiController]
    [Route("wishList")]
    public class WishListController : ControllerBase
    {

        [Authorize]
        [HttpPost]
        [Route("register")]
        public IActionResult addProductToWishList([FromBody] StocksRequestDTO stocksDTO)
        {            
            WishList wishListModel = new Model.WishList();
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var clientId = Lib.GetIdFromRequest(Request.Headers["Authorization"].ToString());
            var irra = wishListModel.save(clientId, stocksDTO.id);

            var result = new ObjectResult(irra);

            return result;
        }
        [Authorize]
        [HttpGet]
        [Route("get")]
        public IActionResult getWishlistById(int id)
        {            
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            id = Lib.GetIdFromRequest(Request.Headers["Authorization"].ToString());
            var wish = Model.WishList.find(id);
            var result = new ObjectResult(wish);
            return result;
        }
        [Authorize]
        [HttpGet]
        [Route("all/{id}")]
        public IActionResult allWishlist(string id)
        {
            var wishlist = Model.WishList.getWishLists(id);
            var result = new ObjectResult(wishlist);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;
        }

        [Authorize]
        [HttpDelete]
        [Route("delete/{idwishlist}")]
        public string removeProductToWishList(int idwishlist)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var ClientId = Lib.GetIdFromRequest(Request.Headers["Authorization"].ToString());
            var response = Model.WishList.deleteProduct(idwishlist, ClientId);
            return response;
        }
    }
}

// 94238892346236852