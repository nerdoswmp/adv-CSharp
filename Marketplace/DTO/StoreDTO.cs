using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StoreDTO
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string CNPJ { get; set; }
        public OwnerDTO? owner { get; set; }
        public List<PurchaseDTO> purchases = new List<PurchaseDTO>();

    }
}
