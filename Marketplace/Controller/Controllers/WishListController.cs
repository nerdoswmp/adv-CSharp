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
            var id = wishListModel.save("85214789455", 1);
            return new
            {
                id = id,
                client = wishList.client,
                produto = wishList.products
            };
        }                    
        //[HttpDelete("deletar")]
        //public ProductDTO deleteProduct([FromBody] Object request)
        //{
        //    return null;
        //}
    }
}
