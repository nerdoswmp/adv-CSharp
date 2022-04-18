using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;

namespace Model
{
    public class Product : IValidateDataObject<Product>, IDataController<ProductDTO, Product>
    {
        private string name;
        private double unit_price;
        private string bar_code;

        public string getName()
        {
            return name;
        }
        public void setName(string Name)
        {
            this.name = Name;
        }
        public double getUnitprice()
        {
            return unit_price;
        }
        public void setUnitPrice(double Unit_price)
        {
            this.unit_price = Unit_price;
        }
        public string getBarCode()
        {
            return bar_code;
        }
        public void setBarCode(string Bar_code)
        {
            this.bar_code = Bar_code;
        }
        public bool validateObject(Product obj)
        {
            if(obj.name == null)
            {
                return false;
            }
            if(obj.unit_price <= 0)
            {
                return false;
            }
            if(obj.bar_code == null)
            {
                return false;
            }
            return true;
        }

        public ProductDTO convertModelToDTO()
        {
            var prdto = new ProductDTO();
            return prdto;
        }

        public ProductDTO findById(int id)
        {
            var prdto = new ProductDTO();
            return prdto;
        }

        public List<ProductDTO> getAll()
        {
            var list = new List<ProductDTO>();
            return list;
        }

        public int save()
        {
            int a = 1;
            return a;
        }

        public void update(ProductDTO obj)
        {

        }

        public void delete(ProductDTO obj)
        {

        }

    }
}
