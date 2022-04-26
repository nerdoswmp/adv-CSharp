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
    public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
    {
        private int quantity;
        private double unit_price;
        private Store store;
        private Product product;
        private List<StocksDTO> stocks;

        public double getUnitPrice()
        {
            return unit_price;
        }
        public void setUnitPrice(double unit_price)
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

        public bool validateObject()
        {
            if(this.quantity <= 0)
            {
                return false;
            }
            if(this.store == null)
            {
                return false;
            }
            if(this.product == null)
            {
                return false;
            }
            return true;
            
        }
        public static Stocks convertDTOToModel(StocksDTO obj)
        {            
            Stocks stock = new Stocks();
            stock.setQuantity(obj.quantity);
            stock.setUnitPrice(obj.unit_Price);
            stock.setStore(Store.convertDTOToModel(obj.store));
            stock.setProduct(Product.convertDTOToModel(obj.product));
            return stock;
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

        public int save(int lojaID, int produtoID, int quantidade, double unit_price)
        {
            var id = 0;
            using(var context = new DAOContext())
            {
                DAO.Stocks stock = new DAO.Stocks
                {
                    quantity = quantidade,
                    unit_price = unit_price,
                    store = context.store.Where(c => c.id == lojaID).Single(),
                    product = context.product.Where(c => c.id == produtoID).Single()
                };
                context.stock.Add(stock);
                context.Entry(stock.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(stock.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges(); 

                id = stock.id;
            }
            return id;
        }

        public void update(StocksDTO obj)
        {

        }

        public void delete(StocksDTO obj)
        {

        }

    }
}
