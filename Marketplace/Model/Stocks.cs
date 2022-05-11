using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public int save(string lojaID, string produtoID, int quantidade, double unit_price)
        {
            var id = 0;
            using(var context = new DAOContext())
            {
                DAO.Stocks stock = new DAO.Stocks
                {
                    quantity = quantidade,
                    unit_price = unit_price,
                    store = context.store.Where(c => c.CNPJ == lojaID).Single(),
                    product = context.product.Where(c => c.bar_code == produtoID).Single()
                };
                context.stock.Add(stock);
                if (stock.store != null)
                {
                    context.Entry(stock.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
                if (stock.product != null)
                {
                    context.Entry(stock.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
                context.SaveChanges(); 

                id = stock.id;
            }
            return id;
        }

        public void update(StocksDTO obj)
        {

        }

        public void updateStock()
        {
            using (var context = new DAOContext())
            {
                
                var entity = context.stock.Include(s => s.store).Include(s => s.product)
                    .Where(s => s.store.CNPJ == this.store.getCNPJ() && s.product.bar_code == this.product.getBarCode()).Single();
                entity.unit_price = this.unit_price;
                entity.quantity = this.quantity;
                context.SaveChanges();
            }
        }

        public void delete(StocksDTO obj)
        {

        }

    }
}
