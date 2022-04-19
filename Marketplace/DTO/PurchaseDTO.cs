using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PurchaseDTO
    {
        public DateTime data_Purchase;
        public double purchase_Value;
        public int payment_Type;
        public int purchase_Status;
        public string number_Confirmation;
        public string number_Nf;
        public ClientDTO clientDTO;
        public StoreDTO storeDTO;
        public ProductDTO product;
    }
}
