﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;
using DAO;

namespace Model
{
    public class Product : IValidateDataObject<Product>, IDataController<ProductDTO, Product>
    {
        private string name;       
        private string bar_code;
        private List<ProductDTO> products;

        public string getName()
        {
            return name;
        }
        public void setName(string Name)
        {
            this.name = Name;
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
            if(obj.bar_code == null)
            {
                return false;
            }
            return true;
        }

        public ProductDTO convertModelToDTO()
        {
            var productDTO = new ProductDTO();
            productDTO.name = this.name;
            productDTO.barCode = this.bar_code;
            return productDTO;
        }

        public static Product convertDTOToModel(ProductDTO obj)
        {
            Product product = new Product();
            product.setName(obj.name);
            product.setBarCode(obj.barCode);        
            return product;
        }

        public ProductDTO findById(int id)
        {
            return new ProductDTO();
        }

        public List<ProductDTO> getAll()
        {
            return this.products;
        }

        public int save()
        {
            var id = 0;
            using(var context = new AppDbContext())
            {
                var product = new DAO.Product
                {                    
                    name = this.name,
                    bar_code = this.bar_code
                };
                context.product.Add(product);
                context.SaveChanges();
                id = product.id;
            }
            return id;
        }

        public void update(ProductDTO obj)
        {

        }

        public void delete(ProductDTO obj)
        {

        }

    }
}
