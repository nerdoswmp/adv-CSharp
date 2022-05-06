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
    public class Address : IValidateDataObject, IDataController<AddressDTO, Address>
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

        private Address() { }

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

        public void setPostalCode(string postal_code)
        {
            this.postal_code = postal_code;
        }

        public string getPostalCode()
        {
            return this.postal_code;
        }
            
        public bool validateObject()
        {
            if (this.street == null)
                return false;

            if (this.city == null)
                return false;

            if (this.state == null)
                return false;

            if (this.country == null)
                return false;

            if (this.postal_code == null)
                return false;

            return true;
        }

        public static Address convertDTOToModel(AddressDTO obj)
        {
            return new Address(obj.street, obj.city, obj.state, obj.country, obj.postal_code);
        }

        public AddressDTO convertModelToDTO() 
        {
            var addressDTO = new AddressDTO();

            addressDTO.street = this.street;
            addressDTO.city = this.city;
            addressDTO.state = this.state;
            addressDTO.country = this.country;
            addressDTO.postal_code = this.postal_code;
            return addressDTO;
        }

        public AddressDTO findById(int id)
        {
            return new AddressDTO();
        }

        public List<AddressDTO> getAll()
        {
            return this.addressDTO;
        }

        public int save()
        {
            int id = 0;
            using (var context = new DAOContext())
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

                context.SaveChanges();

                id = address.id;
            }

            return id; 
        }

        public void update(AddressDTO obj)
        {

        }

        public void delete(AddressDTO address)
        {

        }


        public void deleteAddress()
        {
            using (var context = new DAOContext())
            {

                var adlis = context.address.Where(c => c.postal_code == this.postal_code).ToList();
                if (adlis.Count() <= 0)
                {
                    return;
                }

                foreach (var ad in adlis)
                {
                    var clverif = context.client.FirstOrDefault(c => c.address.id == ad.id);
                    var owverif = context.owner.FirstOrDefault(c => c.address.id == ad.id);

                    if (clverif == null && owverif == null)
                    {
                        context.address.Remove(context.address.Where(c => c.id == ad.id).Single());
                    }
                    else if (clverif == null)
                    {
                        context.owner.Remove(owverif);
                    }
                    else if (owverif == null)
                    {
                        context.client.Remove(clverif);
                    }
                    else
                    {
                        Console.WriteLine("Something happened idk");
                    }
                    context.SaveChanges();
                }
                this.deleteAddress();
            }
            return;
        }
    }
}
