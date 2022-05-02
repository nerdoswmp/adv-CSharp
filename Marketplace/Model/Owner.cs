using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using DTO;
using DAO;

namespace Model
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        private static Owner instance;

        private Guid uuid = Guid.NewGuid();

        public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();

        public Owner(Address address) 
        { 
            this.address = address;
        }

        public static Owner getInstance(Address address)
        {
            if (instance == null)
            {
                instance = new Owner(address);
            }

            return instance;
        }


        public bool validateObject()
        {
            if (this.name == null)
                return false;

            if (this.phone == null)
                return false;

            if (this.email == null)
                return false;

            if (this.document == null)
                return false;

            if (this.address == null)
                return false;

            if (this.passwd == null)
                return false;

            if (this.date_of_birth >= DateTime.Now ||
                    DateTime.Compare(this.date_of_birth, new DateTime(1900, 1, 1)) < 0)
                return false;

            if (this.login == null)
                return false;

            return true;
        }

        public Owner() { }

        public static Owner convertDTOToModel(OwnerDTO obj)
        {
            var owner = new Owner();
            if(obj.address != null)
            {
                owner.address = Address.convertDTOToModel(obj.address);
            }
            
            owner.setAge(obj.date_of_birth);
            owner.setEmail(obj.email);
            owner.setPhone(obj.phone);
            owner.setDoc(obj.document);
            owner.setPassword(obj.passwd);
            owner.setLogin(obj.login);
            owner.setName(obj.name);

            return owner;
        }

        public OwnerDTO convertModelToDTO()
        {
            var ownerDTO = new OwnerDTO();
            ownerDTO.address = this.address.convertModelToDTO();
            ownerDTO.name = this.name;
            ownerDTO.phone = this.phone;
            ownerDTO.document = this.document;
            ownerDTO.passwd = this.passwd;
            ownerDTO.login = this.login;
            ownerDTO.email = this.email;
            ownerDTO.date_of_birth = this.date_of_birth;

            return ownerDTO;
        }

        public OwnerDTO findById(int id)
        {
            OwnerDTO owner = new OwnerDTO();
            using (var contexto = new DAOContext())
            {
                var ownerConsulta = contexto.client.Include(owner => owner.address).Where(c => c.id == id).Single();
                owner.name = ownerConsulta.name;
                owner.document = ownerConsulta.document;
                owner.email = ownerConsulta.email;
                owner.phone = ownerConsulta.phone;
                owner.login = ownerConsulta.login;
                owner.passwd = ownerConsulta.passwd;
                owner.date_of_birth = ownerConsulta.date_of_birth;
                owner.address = new AddressDTO
                {
                    street = ownerConsulta.address.street,
                    city = ownerConsulta.address.city,
                    state = ownerConsulta.address.state,
                    country = ownerConsulta.address.country,
                    postal_code = ownerConsulta.address.postal_code
                };
            }
            return owner;
        }

        public List<OwnerDTO> getAll()
        {
            return this.ownerDTO;
        }

        public int save()
        {
            int id = 0;

            using (var contexto = new DAOContext())
            {
                var owner = new DAO.Owner
                {
                    address = new DAO.Address
                    {
                        street = this.address.getStreet(),
                        city = this.address.getCity(),
                        state = this.address.getState(),
                        country = this.address.getCountry(),
                        postal_code = this.address.getPostalCode()
                    },
                    name = this.name,
                    phone = this.phone,
                    email = this.email,
                    passwd = this.passwd,
                    document = this.document,
                    date_of_birth = this.date_of_birth,
                    login = this.login
                };

                contexto.owner.Add(owner);

                contexto.SaveChanges();

                id = owner.id;
            }

            return id;
        }

        public void update(OwnerDTO obj)
        {

        }

        public void delete(OwnerDTO obj)
        {

        }


    }
}
