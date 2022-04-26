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
    public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
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

        private WishList(Client client)
        {
            this.client=client;
        }

        public WishList()
        {
        }

        public bool validateObject()
        {
            //if(this.client == null)
            //{
            //    return false;
            //}
            //if(this.products == null)
            //{
            //    return false;
            //}         
            return true;
            
        }

        public WishListDTO convertModelToDTO()
        {            
            var wishListDTO = new WishListDTO();
            foreach(var product in products)
            {
                wishListDTO.products.Add(product.convertModelToDTO());
            }
            wishListDTO.client = this.client.convertModelToDTO();
            return wishListDTO;
        }

        public static WishList convertDTOToModel(WishListDTO obj)
        {
            var wishList = new WishList(Client.convertDTOToModel(obj.client));
            foreach(var product in obj.products)
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

        public int save(string client, int product)
        {
            var id = 0;
            using(var context = new DAOContext())
            {
                var wishList = new DAO.WishList
                {
                    client = context.client.FirstOrDefault(c => c.document == client),
                    product = context.product.FirstOrDefault(c => c.id == product)
                };
                context.wishList.Add(wishList);
                if (wishList.client != null)
                {
                    context.Entry(wishList.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
                if (wishList.product != null)
                {
                    context.Entry(wishList.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
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
