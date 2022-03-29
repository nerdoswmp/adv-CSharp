using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Stocks
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
        public void setStore(Store store)
        {
            this.store = store;
        }
        public Product getProduct()
        {
            return product;
        }
        public void setProduct(Product product)
        {
            this.product = product;
        }

        public Stocks(Product product,Store store)
        {
            this.store=store;
            this.product=product;
        }
    }
}
