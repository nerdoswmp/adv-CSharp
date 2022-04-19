using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;
using DAO;

namespace Model
{
    public class WishList : IValidateDataObject<WishList>, IDataController<WishListDTO, WishList>
    {
        private Client client;
        private List<Product> products = new List<Product>();
        private List<WishListDTO> wishListDTO = new List<WishListDTO>();

        public Client getClient()
        {
            return client;
        }
        public List<Product> getProducts()
        {
            return products;
        }
        public void addProductToWishList(Product product)
        {
            products.Add(product);
        }

        public WishList(Client client)
        {
            this.client=client;
        }
        
        public bool validateObject(WishList obj)
        {
            if(obj.client == null)
            {
                return false;
            }
            if(obj.products == null)
            {
                return false;
            }         
            return true;
            
        }

        public WishListDTO convertModelToDTO()
        {            
            var wishListDTO = new WishListDTO();
            foreach(var product in products)
            {
                wishListDTO.product.products.Add(product.convertModelToDTO());
            }
            wishListDTO.client = this.client.convertModelToDTO();
            return wishListDTO;
        }

        public static WishList convertDTOToModel(WishListDTO obj)
        {
            var wishList = new WishList(Client.convertDTOToModel(obj.client));
            foreach(var product in obj.product.products)
            {
                wishList.addProductToWishList(Product.convertDTOToModel(product));
            }
            return wishList;
        }

        public WishListDTO findById(int id)
        {
            return new WishListDTO();
        }

        public List<WishListDTO> getAll()
        {
            return this.wishListDTO;
        }

        public int save(int client, int product)
        {
            var id = 0;
            using(var context = new AppDbContext())
            {
                var wishList = new DAO.WishList
                {
                    client = context.client.Where(c => c.id == client).Single(),
                    product = context.product.Where(c => c.id == product).Single()
                };
                context.wishList.Add(wishList);
                context.Entry(wishList.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(wishList.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();

                id = wishList.id;
            }
            return id;
        }

        public void update(WishListDTO obj)
        {

        }

        public void delete(WishListDTO obj)
        {

        }

    }
}
