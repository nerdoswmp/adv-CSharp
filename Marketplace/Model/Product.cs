using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;
using DAO;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Product : IValidateDataObject, IDataController<ProductDTO, Product>
    {
        private string name;       
        private string bar_code;
        private string description;
        private string image;
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
        public string getDescription()
        {
            return description;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }

        public string getImage()
        {
            return image;
        }
        public void setImage(string image)
        {
            this.image = image;
        }
        public bool validateObject()
        {
            if(this.name == null)
            {
                return false;
            }           
            if(this.bar_code == null)
            {
                return false;
            }
            return true;
        }
        public ProductDTO convertModelToDTO()
        {
            var productDTO = new ProductDTO();
            productDTO.name = this.name;
            productDTO.bar_code = this.bar_code;            
            return productDTO;
        }
        public static Product convertDTOToModel(ProductDTO obj)
        {
            Product product = new Product();
            product.setName(obj.name);
            product.setBarCode(obj.bar_code);                        
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

        public static int find(ProductDTO productDTO)
        {
            using (var context = new DAOContext())
            { 
                var produto = context.product.Where(s => s.bar_code == productDTO.bar_code).Single();

                return produto.id;
            }
        }

        public static List<object> getProducts()
        {
            using (var context = new DAOContext())
            {                
                var products = context.product;
                List<object> produtos = new List<object>();
                foreach (var produto in products)
                {
                    produtos.Add(produto);
                }

                return produtos;
            }
        }

        public int save()
        {
            var id = 0;
            using(var context = new DAOContext())
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
            using(var context = new DAOContext())
            {
                var produto = context.product.Where(s => s.bar_code == obj.bar_code);
            }
        }
        public void delete(ProductDTO obj){}
    }
}
