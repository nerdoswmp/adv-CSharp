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
            productDTO.description = this.description;
            productDTO.image = this.image;
            return productDTO;
        }
        public static Product convertDTOToModel(ProductDTO obj)
        {
            Product product = new Product();
            product.setName(obj.name);
            product.setBarCode(obj.bar_code); 
            product.setDescription(obj.description);
            product.setImage(obj.image);
            return product;
        }
        public ProductDTO findById(int id)
        {
            return new ProductDTO();
        }

        public List<ProductDTO> getAll() { return new List<ProductDTO>(); }

        public static string find(ProductDTO productDTO)
        {
            using (var context = new DAOContext())
            { 
                var produto = context.product.Where(s => s.bar_code == productDTO.bar_code).Single();

                return produto.bar_code;
            }
        }

        public static object findProduct(int id, int store)
        {
            using (var context = new DAOContext())
            {
                var produto = context.stock.Include(s => s.store).Join(context.product, s => s.product.bar_code, p => p.bar_code, (s, p) => new
                {
                    id = p.id,
                    storeid = s.store.id,
                    storename = s.store.name,
                    name = p.name,
                    bar_code = p.bar_code,
                    description = p.description,
                    image = p.image,
                    price = s.unit_price,
                    quantity = s.quantity
                }).Where(x => x.id == id && x.storeid == store).Single();

                return produto;
            }
        }

        public static ProductDTO findProdById(int id)
        {
            using var context = new DAOContext();
                var produto = context.product.Where(p => p.id == id).Single();

            return new ProductDTO()
            {
                image = produto.image,
                name = produto.name,
                description = produto.description,
                bar_code = produto.bar_code
            };
        }

        public static List<object> getProducts()
        {
            using (var context = new DAOContext())
            {
                var products = context.stock.Include(s => s.product).Include(s => s.store);

                List<object> produtos = new List<object>();
                foreach (var produto in products)
                {
                    produtos.Add(produto);
                }

                return produtos;
            }
        }

        public static List<object> getProductsFromOwner(string login)
        {
            using (var context = new DAOContext())
            {
                var products = context.stock.Include(s => s.product).Include(s => s.store)
                    .ThenInclude(s => s.owner).Where(s => s.store.owner.login == login);

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
                    bar_code = this.bar_code,
                    description = this.description,
                    image = this.image                    
                };
                context.product.Add(product);
                context.SaveChanges();
                id = product.id;
            }
            return id;
        }
        public void update(ProductDTO obj){}
        public static void updateProduct(int id,int storeID, ProductEditDTO product)
        {
            using (var context = new DAOContext())
            {
                var produto = context.product.Where(s => s.id == id).First();
                var stock = context.stock.Where(s => s.store.id == storeID).Where(t => t.product.id == id).First();

                if(String.IsNullOrWhiteSpace(product.name) == false) { 
                    produto.name = product.name;
                }
                if (String.IsNullOrWhiteSpace(product.description) == false)
                {
                    produto.description = product.description;
                }
                if (String.IsNullOrWhiteSpace(product.quantidade) == false)
                {
                    stock.quantity = int.Parse(product.quantidade);
                }
                if (String.IsNullOrWhiteSpace(product.preço) == false)
                {
                    stock.unit_price = double.Parse(product.preço);
                }

                context.SaveChanges();
            }          
        }
    
        public void delete(ProductDTO obj){}
        public void deleteProduct()
        {
            using (var context = new DAOContext())
            {
                var prlis = context.product.Where(c => c.bar_code == this.bar_code).Single();

                var wiverif = context.wishList.Include(w => w.stock.product).Where(w => w.stock.product.bar_code == this.bar_code).ToList();

                foreach(var w in wiverif)
                {
                    context.wishList.Remove(w);
                }

                var stverif = context.stock.Include(s => s.product).Where(s => s.product.bar_code == this.bar_code).ToList();

                foreach(var s in stverif)
                {
                    context.stock.Remove(s);
                }

                var puverif = context.purchases.Include(p => p.product).Where(p => p.product.bar_code == this.bar_code).ToList();

                foreach(var p in puverif)
                {
                    p.product = null;
                }
                context.product.Remove(prlis);
                context.SaveChanges();
            }
        }

        public static bool verify(int id, string login)
        {
            using var context = new DAOContext();

            var query = context.stock.Include(s => s.product).Include(s => s.store).ThenInclude(s => s.owner)
                .Any(s => s.product.id == id && s.store.owner.login == login);

            return query;
        }
    }
}
