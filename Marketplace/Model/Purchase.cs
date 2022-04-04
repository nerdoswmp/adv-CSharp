using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Purchase
    {
        private DateTime date_purchase;
        private double payment;
        private string number_confirmation;
        private string number_nf;
        private Client client;
        private Product product;
        private Store store;

        public DateTime getDatePurchase()
        {
            return date_purchase;
        }
        public void setDatePurchase(DateTime Date_purchase)
        {
            this.date_purchase = Date_purchase;
        }
        public double getPayment()
        {
            return payment;
        }
        public void setPayment(double Payment)
        {
            this.payment = Payment;
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
    }
}
