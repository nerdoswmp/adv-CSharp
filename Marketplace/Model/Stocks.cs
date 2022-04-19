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
        private double unit_price;
        private Store store;
        private Product product;
        private List<StocksDTO> stocks;

        public double getUnit_price()
        {
            return unit_price;
        }
        public void setUnit_price(double unit_price)
        {
            this.unit_price = unit_price;
        }
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
        public static Stocks convertDTOToModel(StocksDTO obj)
        {
            purchase.setDataPurchase(obj.data_Purchase);
            Stocks stock = new Stocks();
            stock.setQuantity(obj.quantity);
            stock.setUnit_price(obj.unit_Price);
            
        }

        public StocksDTO convertModelToDTO()
        {
            var stocksDTO = new StocksDTO();
            stocksDTO.quantity = this.quantity;
            stocksDTO.unit_Price = this.unit_price;
            stocksDTO.store = this.store.convertModelToDTO();
            stocksDTO.product = this.product.convertModelToDTO();
            return stocksDTO;
        }

        public StocksDTO findById(int id)
        {
            return new StocksDTO();
        }

        public List<StocksDTO> getAll()
        {
            return this.stocks;
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
