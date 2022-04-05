using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Enums;
namespace Model
{
    public class Purchase : IValidateDataObject<Purchase>
    {
        private DateTime dataPurchase;
        private double purchase_value;
        private string number_confirmation;
        private string number_nf;
        private Client client;
        private List<Product> products = new List<Product>();
        private Store store;
        private PaymentEnum payment_type;
        private PurchaseStatusEnum purchaseStatus;


        public PaymentEnum getPaymentType()
        {
            return payment_type;
        }
        public void setPaymentType(PaymentEnum PaymentType)
        {
            this.payment_type = PaymentType;
        }
        public PurchaseStatusEnum getPurchaseStatus()
        {
            return purchaseStatus;
        }
        public void setPurchaseStatus(PurchaseStatusEnum purchaseStatus)
        {
            this.purchaseStatus = purchaseStatus;
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
        public void updateStatus(PurchaseStatusEnum purchaseStatusEnum)
        {
            this.purchaseStatus = purchaseStatusEnum;
        }
    }
}
