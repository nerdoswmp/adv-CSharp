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
    public class Store : IValidateDataObject<Store>, IDataController<StoreDTO, Store>
    {
        private string name;
        private string CNPJ;         
        private Owner owner;
        private List<Purchase> purchases = new List<Purchase>();

        public List<StoreDTO> storeDTO = new List<StoreDTO>();

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

        public static Store convertDTOToModel(StoreDTO obj)
        {
            var store = new Store(Owner.convertDTOToModel(obj.owner));
            store.setCNPJ(obj.cnpj);
            store.setName(obj.name);

            return store;
        }

        public StoreDTO convertModelToDTO()
        {
            var storeDTO = new StoreDTO();

            storeDTO.name = this.name;
            storeDTO.cnpj = this.CNPJ;
            storeDTO.owner = this.owner.convertModelToDTO();

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

        public int save()
        {
            var id = 0;

            using (var context = new AppDbContext())
            {
                var store = new DAO.Store
                {
                    name = this.name,
                    CNPJ = this.CNPJ,
                    owner = new DAO.Owner
                    {
                        address = new DAO.Address
                        {
                            street = this.owner.getAddress().getStreet(),
                            city = this.owner.getAddress().getCity(),
                            state = this.owner.getAddress().getState(),
                            country = this.owner.getAddress().getCountry(),
                            postal_code = this.owner.getAddress().getPostalCode()
                        },
                        name = this.owner.getName(),
                        phone = this.owner.getPhone(),
                        email = this.owner.getEmail(),
                        password = this.owner.getDoc(),
                        date_of_birth = this.owner.getAge(),
                        login = this.owner.getLogin()
                    }
                };

                context.store.Add(store);

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
