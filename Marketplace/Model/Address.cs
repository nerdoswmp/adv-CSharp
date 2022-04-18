using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;

namespace Model
{
    public class Address : IValidateDataObject<Address>, IDataController<AddressDTO, Address>
    {
        // vars
        private string street;
        private string city;
        private string state;
        private string country;
        private string poste_code;

        // Construtor
        public Address(string street, string city, string state, string country, string poste_code)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
            this.poste_code = poste_code;
        }

        public Address() { }

        // gets | sets
        public void setStreet(string street)
        {
            this.street = street;
        }

        public string getStreet()
        {
            return this.street;
        }

        public void setCity(string city)
        {
            this.city = city;
        }

        public string getCity()
        {
            return this.city;
        }

        public void setState(string state)
        {
            this.state = state;
        }

        public string getState()
        {
            return this.state;
        }

        public void setCountry(string country)
        {
            this.country = country;
        }

        public string getCountry()
        {
            return this.country;
        }

        public void setPostalCode(string poste_code)
        {
            this.poste_code = poste_code;
        }

        public string getPostalCode()
        {
            return this.poste_code;
        }
            
        public bool validateObject(Address obj)
        {
            if (obj.street == null)
                return false;

            if (obj.city == null)
                return false;

            if (obj.state == null)
                return false;

            if (obj.country == null)
                return false;

            if (obj.poste_code == null)
                return false;

            return false;
        }

        public AddressDTO convertModelToDTO() 
        {
            var addto = new AddressDTO();
            return addto;
        }

        public AddressDTO findById(int id)
        {
            var addto = new AddressDTO();
            return addto;
        }

        public List<AddressDTO> getAll()
        {
            var list = new List<AddressDTO>();
            return list;
        }

        public int save()
        {
            int a = 1;
            return a; 
        }

        public void update(AddressDTO obj)
        {

        }

        public void delete(AddressDTO obj)
        {

        }

    }
}
