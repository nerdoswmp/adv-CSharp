using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Enums;
namespace Model
{
    internal class Purchase : IValidateDataObject<Purchase>
    {
        private DateTime date_purchase;
        private double purchase_value;
        private string number_confirmation;
        private string number_nf;
        private Client client;
        private Product product;
        private Store store;
        private PaymentEnum paymentEnum;
        private PurchaseStatusEnum purchaseStatusEnum;


        public PaymentEnum getPaymentEnum()
        {
            return paymentEnum;
        }
        public void setPaymentEnum(PaymentEnum PaymentEnum)
        {
            this.paymentEnum = PaymentEnum;
        }
        public PurchaseStatusEnum GetPurchaseStatusEnum()
        {
            return purchaseStatusEnum;
        }
        public void setPurchaseStatusEnum(PurchaseStatusEnum purchaseStatusEnum)
        {
            this.purchaseStatusEnum = purchaseStatusEnum;
        }
        public DateTime getDatePurchase()
        {
            return date_purchase;
        }
        public void setDatePurchase(DateTime Date_purchase)
        {
            this.date_purchase = Date_purchase;
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
        public Product getProduct()
        {
            return product;
        }
        public Store getStore()
        {
            return store;
        }
        public Purchase(Client client,Store store, Product product) 
        { 
            this.client = client;
            this.product = product;
            this.store = store;            
        }
        public bool validateObject(Purchase obj)
        {
            if(obj.date_purchase == null) {return false;}
            if(obj.number_confirmation == null) {return false;}
            if(obj.number_nf == null) {return false;}
            if(obj.purchase_value == null) { return false;}
            if(obj.client == null) { return false;}
            if(obj.product == null) { return false;}
            if(obj.store == null) { return false;}
            if(obj.paymentEnum == null) { return false; }
            if(obj.purchaseStatusEnum == null) { return false; }
            return true; 
        }
        public void updateStatus(PurchaseStatusEnum purchaseStatusEnum)
        {
            this.purchaseStatusEnum = purchaseStatusEnum;
        }
    }
}
