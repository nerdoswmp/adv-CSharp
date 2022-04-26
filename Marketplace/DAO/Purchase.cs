using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Enums;

namespace DAO
{
    public class Purchase
    {
        public int id;
        public DateTime data_purchase;
        public double purchase_value;
        public string confirmation_number;
        public string number_nf;        
        public int payment_type;
        public int purchase_status;
        public Client client;
        public Product product;
        public Store store;
    }
}
