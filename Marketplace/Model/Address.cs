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
    public class Address : IValidateDataObject<Address>, IDataController<AddressDTO, Address>
    {
        // vars
        private string street;
        private string city;
        private string state;
        private string country;
        private string postal_code;

        public List<AddressDTO> addressDTO = new List<AddressDTO>();

        // Construtor
        public Address(string street, string city, string state, string country, string postal_code)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
            this.postal_code = postal_code;
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
            this.postal_code = poste_code;
        }

        public string getPostalCode()
        {
            return this.postal_code;
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

            if (obj.postal_code == null)
                return false;

            return false;
        }

        public static Address convertDTOToModel(AddressDTO obj)
        {
            return new Address(obj.street, obj.city, obj.state, obj.country, obj.postal_code);
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
            int id = 0;
            using (var context = new AppDbContext())
            {
                var address = new DAO.Address
                {
                    street = this.street,
                    city = this.city,
                    state = this.state,
                    country = this.country,
                    postal_code = this.postal_code
                };

                context.address.Add(address);
            }

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
