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
        private string quantity;
        private Store store;
        private Product product;

        public string getQuantity()
        {
            return quantity;
        }
        public void setQuantity(string Quantity)
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

        public Stocks(Product product,Store store)
        {
            this.store=store;
            this.product=product;
        }

        public bool validateObject(Stocks obj)
        {
            if(obj.quantity == null)
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
