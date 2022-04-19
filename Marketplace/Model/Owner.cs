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
    public class Owner : Person, IValidateDataObject<Owner>, IDataController<OwnerDTO, Owner>
    {
        private static Owner instance;

        private Guid uuid = Guid.NewGuid();

        public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();

        public Owner(Address address) : base(address)
        { }

        public static Owner getInstance(Address address)
        {
            if (instance == null)
            {
                instance = new Owner(address);
            }

            return instance;
        }


        public bool validateObject(Owner obj)
        {
            if (obj.name == null)
                return false;

            if (obj.phone == null)
                return false;

            if (obj.email == null)
                return false;

            if (obj.document == null)
                return false;

            if (obj.address == null)
                return false;

            if (obj.date_of_birth >= DateTime.Now ||
                    DateTime.Compare(obj.date_of_birth, new DateTime(1900, 1, 1)) < 0)
                return false;

            if (obj.login == null)
                return false;

            return true;
        }


        public static Owner convertDTOToModel(OwnerDTO obj)
        {
            var owner = new Owner(Address.convertDTOToModel(obj.address));
            owner.setAge(obj.dateOfBirth);
            owner.setEmail(obj.email);
            owner.setPhone(obj.phone);
            owner.setDoc(obj.document);
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
            ownerDTO.login = this.login;
            ownerDTO.email = this.email;
            ownerDTO.dateOfBirth = this.date_of_birth;

            return ownerDTO;
        }

        public OwnerDTO findById(int id)
        {
            return new OwnerDTO();
        }

        public List<OwnerDTO> getAll()
        {
            return this.ownerDTO;
        }

        public int save()
        {
            int id = 0;

            using (var contexto = new AppDbContext())
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
                    password = this.document,
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
