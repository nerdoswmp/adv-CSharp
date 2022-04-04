using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace Model
{
    internal class Store : IValidateDataObject<Store>
    {
        private string name;
        private string cnpj;         
        private Owner owner;
        private List<Purchase> purchases = new List<Purchase>();


        public string getName()
        {
            return name;
        }
        public void setName(string Name)
        {
            this.name = Name;
        }
        public string getCnpj()
        {
            return cnpj;
        }
        public void setCnpj(string Cnpj)
        {
            this.cnpj = Cnpj;
        }
        public Owner getOwner()
        {
            return owner;
        }
        public List<Purchase> getPurchases()
        {
            return purchases;
        }
        public void addNewPurchase(Purchase purchase)
        {
            purchases.Add(purchase);
        }
        
        public Store(Owner owner)
        {
            this.owner=owner;
        }
 
        public bool validateObject(Store obj)
        {
            if(obj.name == null)
            {
                return false;
            }
            if(obj.cnpj == null)
            {
                return false;
            }
            if(obj.owner == null)
            {
                return false;
            }
            if(obj.purchases == null)
            {
                return false;
            }           
            return true;
            
        }

    }
}
