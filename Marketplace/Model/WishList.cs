using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;

namespace Model
{
    public class WishList : IValidateDataObject<WishList>, IDataController<WishListDTO, WishList>
    {
        private Client client;
        private List<Product> products = new List<Product>();

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
            var widto = new WishListDTO();
            return widto;
        }

        public WishListDTO findById(int id)
        {
            var widto = new WishListDTO();
            return widto;
        }

        public List<WishListDTO> getAll()
        {
            var list = new List<WishListDTO>();
            return list;
        }

        public int save()
        {
            int a = 1;
            return a;
        }

        public void update(WishListDTO obj)
        {

        }

        public void delete(WishListDTO obj)
        {

        }

    }
}
