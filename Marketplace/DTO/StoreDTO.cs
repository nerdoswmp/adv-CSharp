﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StoreDTO
    {
        public string name;
        public string CNPJ;
        public OwnerDTO owner;
        public List<PurchaseDTO> purchases = new List<PurchaseDTO>();
    }
}
