using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace Model
{
    public class Wishlist : IValidateDataObject<Wishlist>
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

        public Wishlist(Client client)
        {
            this.client=client;
        }
        
        public bool validateObject(Wishlist obj)
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
        
    }    
}
