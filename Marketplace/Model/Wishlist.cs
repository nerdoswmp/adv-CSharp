using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace Model
{
    public class WishList : IValidateDataObject<WishList>, IDataController<WishList, WishListDTO>
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

        public WishList convertModelToDTO()
        {
            return this;
        }
    }    
}
