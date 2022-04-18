using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;

namespace Model
{
    public class Stocks : IValidateDataObject<Stocks>, IDataController<StocksDTO, Stocks>
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

        public StocksDTO convertModelToDTO()
        {
            var stkdto = new StocksDTO();
            return stkdto;
        }

        public StocksDTO findById(int id)
        {
            var stkdto = new StocksDTO();
            return stkdto;
        }

        public List<StocksDTO> getAll()
        {
            var list = new List<StocksDTO>();
            return list;
        }

        public int save()
        {
            int a = 1;
            return a;
        }

        public void update(StocksDTO obj)
        {

        }

        public void delete(StocksDTO obj)
        {

        }

    }
}
