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
    public class Client : Person, IValidateDataObject<Client>, IDataController<ClientDTO, Client>
    {
        private static Client instance;

        private Guid uuid = Guid.NewGuid();

        public List<ClientDTO> clientDTO = new List<ClientDTO>();

        public Client(Address address) : base(address)
        { }

        public static Client getInstance(Address address)
        {
            if (instance == null)
            {
                instance = new Client(address);
            }

            return instance;
        }

        public bool validateObject(Client obj)
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

        public static Client convertDTOToModel(ClientDTO obj)
        {
            var client = new Client(Address.convertDTOToModel(obj.address));
            client.setAge(obj.dateOfBirth);
            client.setEmail(obj.email);
            client.setPhone(obj.phone);
            client.setDoc(obj.document);
            client.setLogin(obj.login);
            client.setName(obj.name);
            
            return client;
        }

        public ClientDTO convertModelToDTO()
        {
            var clientDTO = new ClientDTO();
            clientDTO.address = this.address.convertModelToDTO();
            clientDTO.name = this.name;
            clientDTO.phone = this.phone;
            clientDTO.document = this.document;
            clientDTO.login = this.login;
            clientDTO.email = this.email;
            clientDTO.dateOfBirth = this.date_of_birth;

            return clientDTO;
        }

        public ClientDTO findById(int id)
        {
            return new ClientDTO();
        }

        public List<ClientDTO> getAll()
        {
            return this.clientDTO;
        }

        public int save()
        {
            int id = 0;

            using (var contexto = new AppDbContext())
            {
                var client = new DAO.Client
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

                contexto.client.Add(client);

                contexto.SaveChanges();

                id = client.id;
            }

            return id;
        }

        public void update(ClientDTO obj)
        {

        }

        public void delete(ClientDTO obj)
        {

        }

    }
}
