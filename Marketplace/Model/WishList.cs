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
    public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
    {
        private Client client;
        private List<Stocks> products = new List<Stocks>();
        private List<WishListDTO> wishListDTO = new List<WishListDTO>();

        public Client getClient()
        {
            return client;
        }
        public List<Stocks> getProducts()
        {
            return products;
        }
        public void addProductToWishList(Stocks product)
        {
            products.Add(product);
        }

        private WishList(Client client)
        {
            this.client=client;
        }

        public WishList()
        {
        }

        public bool validateObject()
        {
            if (this.client == null)
            {
                return false;
            }
            if (this.products == null)
            {
                return false;
            }
            return true;
            
        }

        public WishListDTO convertModelToDTO()
        {            
            var wishListDTO = new WishListDTO();
            foreach(var product in products)
            {
                wishListDTO.products.Add(product.convertModelToDTO());
            }
            wishListDTO.client = this.client.convertModelToDTO();
            return wishListDTO;
        }

        public static WishList convertDTOToModel(WishListDTO obj)
        {
            var wishList = new WishList(Client.convertDTOToModel(obj.client));
            foreach(var product in obj.products)
            {
                wishList.addProductToWishList(Stocks.convertDTOToModel(product));
            }
            return wishList;
        }

        public WishListDTO findById(int id)
        {
            return new WishListDTO();
        }

        public List<WishListDTO> getAll()
        {
            return this.wishListDTO;
        }

        public int save(int client, int stock)
        {
            var id = 0;
            using(var context = new DAOContext())
            {
                var clientDAO = context.client.Where(c => c.id == client).Single();
                var stocksDAO = context.stock.Where(c => c.id == stock).Single();

                var wl = new DAO.WishList
                {
                    client = clientDAO,
                    stock = stocksDAO
                };
                context.wishList.Add(wl);
                context.Entry(wl.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(wl.stock).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
                id = wl.id;
            }
            return id;
        }

        public void update(WishListDTO obj)
        {

        }

        public void delete(WishListDTO obj)
        {

        }

        public static string deleteProduct(int id, int ClientId)
        {
            using(var context = new DAOContext())
            {
                var wishlist = context.wishList.Where(w=>w.stock.id == id && w.client.id == ClientId);
                Console.WriteLine(ClientId);
                Console.WriteLine(id);
                context.wishList.RemoveRange(wishlist);
                context.SaveChanges();
                return "sucess";
            }
        }

        public void deleteWishList()
        {
            using (var context = new DAOContext())
            {
               foreach(var prod in this.products)
                {
                    var wishlist = context.wishList.Include(s => s.stock).ThenInclude(p => p.product).Include(s => s.stock)
                        .ThenInclude(s => s.store).FirstOrDefault(w => w.client.document == this.client.getDoc() && w.stock.product.bar_code == prod.getProduct().getBarCode() && w.stock.store.CNPJ == prod.getStore().getCNPJ());
                    if (wishlist == null)
                        continue;
                    context.wishList.Remove(wishlist);
                    context.SaveChanges();
                }
            }
        }

        public static IEnumerable<object> find(int id)
        {
            using(var context = new DAOContext())
            {
                var wishlist = context.wishList.Include(s => s.client).Where(a => a.client.id == id).Join(context.stock.Include(s => s.store), w => w.stock.product, s => s.product, (w, s) => new
                {
                    id = w.stock.id,
                    product = w.stock.product.name,
                    price = w.stock.unit_price,
                    description = w.stock.product.description,
                    image = w.stock.product.image,
                    name = s.store.name,
                }).ToList().GroupBy(x => x.id).Select(g => g.OrderBy(p => p.price).First());

                return wishlist;
            }
        }

        public static List<object> getWishLists(string user)
        {
            using (var context = new DAOContext())
            {

                var wishlist = context.wishList.Include(w => w.client).Include(w => w.stock.product)
                    .Include(w => w.stock.store).Select(x => new
                {
                    id = x.stock.product.id,
                    wishid = x.id,
                    storeid = x.stock.store.id,
                    store = x.stock.store.name,
                    name = x.stock.product.name,
                    bar_code = x.stock.product.bar_code,
                    description = x.stock.product.description,
                    image = x.stock.product.image,
                    price = x.stock.unit_price,
                    client = x.client
                }).Where(w => w.client.login == user);

                List<object> list = new List<object>();
                foreach (var item in wishlist)
                {
                    list.Add(item);
                }

                return list;
            }
        }

    }
}
