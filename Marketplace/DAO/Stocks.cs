using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAO
{
    public class Stocks
    {
        public int id;
        public int quantity;
        public double unit_price;
        public Store store;
        public Product product;      
    }
}
