using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace Model
{
    public class Store : IValidateDataObject<Store>, IDataController<Store, StoreDTO>
    {
        private string name;
        private string CNPJ;         
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
        public string getCNPJ()
        {
            return CNPJ;
        }
        public void setCNPJ(string Cnpj)
        {
            this.CNPJ = Cnpj;
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
            if(obj.CNPJ == null)
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

        public Store convertModelToDTO()
        {
            return this;
        }

    }
}
