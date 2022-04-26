using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //if(this.dataPurchase == null) {return false;}
            if(this.number_confirmation == null) {return false;}
            if(this.number_nf == null) {return false;}
            //if(this.purchase_value == null) { return false;}           
            //if(this.payment_type == null) { return false; }
            //if(this.purchaseStatus == null) { return false; }
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

        public List<PurchaseDTO> getAll()
        {
            return this.purchaseDTO;
        }

        public int save()
        {
            var id = 0;
            using(var context = new DAOContext())
            {
                var purchase = new DAO.Purchase
                {
                    client = context.client.FirstOrDefault(c => c.id == 1),
                    store = context.store.FirstOrDefault(c => c.id == 1),
                    product = context.product.Where(c => c.id == 1).Single(),
                    data_purchase = this.dataPurchase,
                    confirmation_number = this.number_confirmation,
                    number_nf = this.number_nf,
                    purchase_value = this.purchase_value,
                    purchase_status = this.purchaseStatus,
                    payment_type = this.payment_type                    
                };
                context.purchases.Add(purchase);
                if (purchase.client != null)
                {
                    context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
                if (purchase.store != null)
                {
                    context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
                if (purchase.product != null)
                {
                    context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
                context.SaveChanges();
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
