using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Product
    {
        private string name;
        private double unit_price;
        private string bar_code;

        public string getName()
        {
            return name;
        }
        public void setName(string Name)
        {
            this.name = Name;
        }
        public double getUnitPrice()
        {
            return unit_price;
        }
        public void setUnitPrice(double Unit_price)
        {
            this.unit_price = Unit_price;
        }
        public string getBarCode()
        {
            return bar_code;
        }
        public void setBarCode(string Bar_code)
        {
            this.bar_code = Bar_code;
        }
    }
}
