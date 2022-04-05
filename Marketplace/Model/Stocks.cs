using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace Model
{
    public class Stocks : IValidateDataObject<Stocks>
    {
        private int quantity;
        private Store store;
        private Product product;

        public int getQuantity()
        {
            return quantity;
        }
        public void setQuantity(int Quantity)
        {
            this.quantity = Quantity;
        }
        public Store getStore()
        {
            return store;
        }
        public Product getProduct()
        {
            return product;
        }
        public void setStore(Store store)
        {
            this.store = store;
        }
        public void setProduct(Product product)
        {
            this.product = product;
        }

        public bool validateObject(Stocks obj)
        {
            if(obj.quantity <= 0)
            {
                return false;
            }
            if(obj.store == null)
            {
                return false;
            }
            if(obj.product == null)
            {
                return false;
            }
            return true;
            
        }
    }
}
