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
        public DateTime dataPurchase;        
        public string number_confirmation;
        public string number_nf;        
        public int payment_type;
        public int purchaseStatus;
        public Client client;
        public List<Product> products = new List<Product>();
        public Store store;
    }
}
