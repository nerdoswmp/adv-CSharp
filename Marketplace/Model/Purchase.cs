using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using Enums;
using DTO;
using DAO;

namespace Model
{
    public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
    {
        private DateTime dataPurchase;
        private string number_confirmation;
        private string number_nf;        
        private int payment_type;
        private int purchaseStatus;
        private double purchase_value;

        private Client client;
        private Store store;

        private List<Product> products = new List<Product>();
        private List<PurchaseDTO> purchaseDTO = new List<PurchaseDTO>();
        
      
        public int getPaymentType()
        {
            return payment_type;
        }
        public void setPaymentType(PaymentEnum PaymentType)
        {
            this.payment_type = (int)PaymentType;
        }
        public int getPurchaseStatus()
        {
            return purchaseStatus;
        }
        public void setPurchaseStatus(PurchaseStatusEnum purchaseStatus)
        {
            this.purchaseStatus = (int)purchaseStatus;
        }
        public DateTime getDataPurchase()
        {
            return dataPurchase;
        }
        public void setDataPurchase(DateTime Date_purchase)
        {
            this.dataPurchase = Date_purchase;
        }
        public double getPurchase_value()
        {
            return purchase_value;
        }
        public void setPurchase_value(double Purchase_value)
        {
            this.purchase_value = Purchase_value;
        }
        public string getNumberConfirmation()
        {
            return number_confirmation;
        }
        public void setNumberConfirmation(string Number_confirmation)
        {
            this.number_confirmation = Number_confirmation;
        }
        public string getNumberNf()
        {
            return number_nf;
        }
        public void setNumberNf(string Number_nf)
        {
            this.number_nf = Number_nf;
        }
        public Client getClient()
        {
            return client;
        }
        public void setClient(Client client)
        {
            this.client = client;   
        }
        public List<Product> getProducts()
        {
            return products;
        }
        public void setProducts(List<Product> products)
        {
            this.products = products;
        }
        public Store getStore()
        {
            return store;
        }        
        public void setStore(Store store)
        {
            this.store = store;
        }

        public bool validateObject()
        {
            if (this.dataPurchase >= DateTime.Now ||
                    DateTime.Compare(this.dataPurchase, new DateTime(1900, 1, 1)) < 0)
                return false;
            if (this.number_confirmation == null) { return false; }
            if (this.number_nf == null) { return false; }
            if (this.purchase_value < 0) { return false; }
            //if (this.payment_type == null) { return false; }
            //if (this.purchaseStatus == null) { return false; }
            return true; 
        }
        public void updateStatus(int purchaseStatusEnum)
        {
            this.purchaseStatus = purchaseStatusEnum;
        }

        public PurchaseDTO convertModelToDTO()
        {
            var purchaseDTO = new PurchaseDTO();
            purchaseDTO.data_purchase = this.dataPurchase;
            purchaseDTO.confirmation_number = this.number_confirmation;
            purchaseDTO.number_nf = this.number_nf;
            purchaseDTO.payment_type = this.payment_type;
            purchaseDTO.purchase_status = this.purchaseStatus;
            purchaseDTO.purchase_value = this.purchase_value;
            return purchaseDTO; 
        }

        public static Purchase convertDTOToModel(PurchaseDTO obj)
        {
            Purchase purchase = new Purchase();

            if (obj.client != null)
            {
                purchase.setClient(Client.convertDTOToModel(obj.client));
            }
            if (obj.store != null)
            {
                purchase.setStore(Store.convertDTOToModel(obj.store));
            }
            purchase.setDataPurchase(obj.data_purchase);
            purchase.setNumberConfirmation(obj.confirmation_number);
            purchase.setNumberNf(obj.number_nf);
            purchase.setPurchase_value(obj.purchase_value);
            purchase.setPaymentType((PaymentEnum)obj.payment_type);
            purchase.setPurchaseStatus((PurchaseStatusEnum)obj.purchase_status);
            
            foreach (ProductDTO item in obj.productsDTO)
            {
                if (item != null)
                {
                    purchase.products.Add(Product.convertDTOToModel(item));
                }
            }

            return purchase;
        }

        public PurchaseDTO findById(int id)
        {
            return new PurchaseDTO();
        }

        public static List<object> findByStoreId(int id)
        {
            List<object> purchases = new List<object>();
            using (var contexto = new DAOContext())
            {
                var purchaseConsulta = contexto.purchases.Include(purchase => purchase.client).ThenInclude(client => client.address)
                    .Include(purchase => purchase.store).ThenInclude(store => store.owner).Include(purchase => purchase.product)
                    .Where(c => c.store.id == id);


                var distinctPurchase = purchaseConsulta.Select(x => new
                {
                    x.id,
                    x.number_nf,
                    x.store,
                    x.client,
                    x.confirmation_number,
                    x.purchase_status,
                    x.payment_type,
                    x.data_purchase
                }).Distinct().ToList();

                //var list = contexto.purchases.Where(c => c.id == purchaseConsulta.id)
                //    .Select(c => c.product).ToList();

                List<object> list = new List<object>();

                int i = 0;
                foreach (var nf in distinctPurchase)
                {
                    foreach (var item in purchaseConsulta.Where(c => c.number_nf == nf.number_nf))
                    {
                        list.Add(item.product);
                    };

                    purchases.Add(new
                    {
                        nf.confirmation_number,
                        nf.data_purchase,
                        nf.number_nf,
                        nf.payment_type,
                        nf.purchase_status,
                        //purchaseConsulta.purchase_value,
                        nf.client,
                        nf.store,
                        products = new List<object>(list),
                    });

                    list.Clear();
                    i++;
                }

                //obj = new {
                //    singlePurchase.confirmation_number,
                //    singlePurchase.data_purchase,
                //    singlePurchase.number_nf,
                //    singlePurchase.payment_type,
                //    singlePurchase.purchase_status,
                //    //purchaseConsulta.purchase_value,
                //    singlePurchase.client,
                //    singlePurchase.store,
                //    products,
                //};
            
            }
            return purchases;
        }

        public PurchaseDTO findByClientId(int id)
        {
            return new PurchaseDTO();
        }

        public List<PurchaseDTO> getAll()
        {
            return this.purchaseDTO;
        }

        public int save()
        {
            var id = 0;
            using(var context = new DAOContext())
            {
                if (this.products.Count() <= 0) { return -1; }

                var purchase = new DAO.Purchase
                {
                    client = context.client.Where(c => c.document == this.client.getDoc()).Single(),
                    store = context.store.Where(c => c.CNPJ == this.store.getCNPJ()).Single(),
                    product = context.product.Where(c => c.bar_code == this.products.First().getBarCode()).Single(),
                    data_purchase = this.dataPurchase,
                    confirmation_number = this.number_confirmation,
                    number_nf = this.number_nf,
                    purchase_value = this.purchase_value,
                    purchase_status = this.purchaseStatus,
                    payment_type = this.payment_type                    
                };
                context.purchases.Add(purchase);
                context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
                this.products.Remove(products.First());
                this.save();
                id = purchase.id;
            }
            return id;
        }

        public void update(PurchaseDTO obj)
        {

        }

        public void delete(PurchaseDTO obj)
        {

        }

    }
}
