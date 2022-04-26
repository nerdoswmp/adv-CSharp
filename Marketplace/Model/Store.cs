using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;
using DAO;

namespace Model
{
    public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
    {
        private string name;
        private string CNPJ;         
        private Owner owner;
        private List<Purchase> purchases = new List<Purchase>();

        public List<StoreDTO> storeDTO = new List<StoreDTO>();

        private Store()
        {

        }

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
 
        public bool validateObject()
        {
            if(this.name == null)
            {
                return false;
            }
            if(this.CNPJ == null)
            {
                return false;
            }
          
            return true;
            
        }

        public static Store convertDTOToModel(StoreDTO obj)
        {
            var store = new Store();
            if(obj.owner != null)
            {
                store.owner = Owner.convertDTOToModel(obj.owner);
            }            
            store.setCNPJ(obj.CNPJ);
            store.setName(obj.name);
            foreach (var purchase in obj.purchases)
            {
                if (purchase != null)
                {
                    store.addNewPurchase(Purchase.convertDTOToModel(purchase));
                }
            }

            return store;
        }

        public StoreDTO convertModelToDTO()
        {
            var storeDTO = new StoreDTO();

            storeDTO.name = this.name;
            storeDTO.CNPJ = this.CNPJ;
            storeDTO.owner = this.owner.convertModelToDTO();
            foreach(var purchase in this.purchases)
            {
                storeDTO.purchases.Add(purchase.convertModelToDTO());
            }

            return storeDTO;
        }

        public StoreDTO findById(int id)
        {
            return new StoreDTO();
        }

        public List<StoreDTO> getAll()
        {
            return this.storeDTO;
        }

        public int save(int owner)
        {
            var id = 0;

            using (var context = new DAOContext())
            {
                var store = new DAO.Store
                {
                    name = this.name,
                    CNPJ = this.CNPJ,
                    owner = context.owner.Where(c => c.id == owner).Single()
            };

                context.store.Add(store);
                if (store.owner != null)
                {
                    context.Entry(store.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
                context.SaveChanges();

                id = store.id;
            }

            return id;
        }

        public void update(StoreDTO obj)
        {

        }

        public void delete(StoreDTO obj)
        {

        }


    }
}
