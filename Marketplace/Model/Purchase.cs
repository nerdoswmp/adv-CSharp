using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Purchase
    {
        private DateTime date_purchase;
        private double payment;
        private string number_confirmation;
        private string number_nf;

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

        public Purchase(Client client,Store store, Product product) 
        { 
                
        }
    }
}
