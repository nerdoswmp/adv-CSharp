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
    public class Purchase : IValidateDataObject<Purchase>, IDataController<PurchaseDTO, Purchase>
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

        public bool validateObject(Purchase obj)
        {
            if(obj.dataPurchase == null) {return false;}
            if(obj.number_confirmation == null) {return false;}
            if(obj.number_nf == null) {return false;}
            if(obj.purchase_value == null) { return false;}
            if(obj.client == null) { return false;}
            if(obj.products == null) { return false;}
            if(obj.store == null) { return false;}
            if(obj.payment_type == null) { return false; }
            if(obj.purchaseStatus == null) { return false; }
            return true; 
        }
        public void updateStatus(int purchaseStatusEnum)
        {
            this.purchaseStatus = purchaseStatusEnum;
        }

        public PurchaseDTO convertModelToDTO()
        {
            var purchaseDTO = new PurchaseDTO();
            purchaseDTO.data_Purchase = this.dataPurchase;
            purchaseDTO.number_Confirmation = this.number_confirmation;
            purchaseDTO.number_Nf = this.number_nf;
            purchaseDTO.payment_Type = this.payment_type;
            purchaseDTO.purchase_Status = this.purchaseStatus;
            purchaseDTO.purchase_Value = this.purchase_value;
            return purchaseDTO; 
        }

        public static Purchase convertDTOToModel(PurchaseDTO obj)
        {
            Purchase purchase = new Purchase();
            purchase.setDataPurchase(obj.data_Purchase);
            purchase.setNumberConfirmation(obj.number_Confirmation);
            purchase.setNumberNf(obj.number_Nf);
            purchase.setPurchase_value(obj.purchase_Value);
            purchase.setPaymentType((PaymentEnum)obj.payment_Type);
            purchase.setPurchaseStatus((PurchaseStatusEnum)obj.purchase_Status);
            purchase.setStore(Store.convertDTOToModel(obj.storeDTO));
            purchase.setClient(Client.convertDTOToModel(obj.clientDTO));
            foreach (ProductDTO item in obj.product.products)
            {
                purchase.products.Add(Product.convertDTOToModel(item));
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

        public int save(int client, int store, int product)
        {
            var id = 0;
            using(var context = new DAOContext())
            {
                var purchase = new DAO.Purchase
                {
                    client = context.client.Where(c => c.id == client).Single(),
                    store = context.store.Where(c => c.id == store).Single(),
                    product = context.product.Where(c => c.id == product).Single(),
                    dataPurchase = this.dataPurchase,
                    number_confirmation = this.number_confirmation,
                    number_nf = this.number_nf,
                    purchase_value = this.purchase_value,
                    purchaseStatus = this.purchaseStatus,
                    payment_type = this.payment_type                    
                };
                context.purchases.Add(purchase);
                context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
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
