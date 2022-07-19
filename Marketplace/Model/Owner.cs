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

        private Owner() { }

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
            return new OwnerDTO();
        }

        public static object findByDoc(string document)
        {
            object obj;

            using (var contexto = new DAOContext())
            {
                var ownerConsulta = contexto.owner.Include(owner => owner.address).Where(c => c.document == document).Single();
                //Console.WriteLine(clientConsulta.address.id);
                obj = new
                {
                    name = ownerConsulta.name,
                    document = ownerConsulta.document,
                    email = ownerConsulta.email,
                    phone = ownerConsulta.phone,
                    login = ownerConsulta.login,
                    passwd = ownerConsulta.passwd,
                    date_of_birth = ownerConsulta.date_of_birth,
                    address = ownerConsulta.address,
                };

            }
            return obj;
        }

        public static int findByUsername(string username)
        {
            int id;

            using (var contexto = new DAOContext())
            {
                var ownerConsulta = contexto.owner.Include(owner => owner.address).Where(c => c.login == username).Single();

                id = ownerConsulta.id;
            }
            return id;
        }

        public List<OwnerDTO> getAll()
        {
            return this.ownerDTO;
        }

        public static List<OwnerDTO> getAllOwners()
        {
            using var context = new DAOContext();

            var list = context.owner.ToList();
            List<OwnerDTO> objs = new List<OwnerDTO>();
            foreach (var owner in list)
            {
                objs.Add(new OwnerDTO
                {
                    name = owner.name,
                    phone = owner.phone,
                    email = owner.email,
                    login = owner.login,
                    date_of_birth = owner.date_of_birth,
                    passwd = owner.passwd
                });
            }

            return objs;
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

        public int getId()
        {
            int id = 0;
            using (var contexto = new DAOContext())
            {
                try
                {
                    var ownerConsulta = contexto.owner.Where(c => c.login == this.login && c.passwd == this.passwd).Single();
                    id = ownerConsulta.id;
                }
                catch
                {
                    id = -1;
                }

            }
            return id;

        }

        public static Owner loginOwner(LoginDTO login)
        {
            Owner? obj;

            using (var contexto = new DAOContext())
            {
                try
                {
                    var ownerConsulta = contexto.owner.Where(c => c.login == login.login && c.passwd == login.passwd).Single();
                    obj = new Owner
                    {
                        name = ownerConsulta.name,
                        document = ownerConsulta.document,
                        email = ownerConsulta.email,
                        phone = ownerConsulta.phone,
                        login = ownerConsulta.login,
                        passwd = ownerConsulta.passwd,
                        date_of_birth = ownerConsulta.date_of_birth,
                    };
                }
                catch
                {
                    obj = null;
                }

            }
            return obj;
        }

    }
}
