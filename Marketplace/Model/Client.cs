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
    public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
    {
        private static Client instance;

        private Guid uuid = Guid.NewGuid();

        public List<ClientDTO> clientDTO = new List<ClientDTO>();

        public Client(Address address) 
        {
            this.address = address;
        }

        public Client() { }

        public static Client getInstance(Address address)
        {
            if (instance == null)
            {
                instance = new Client(address);
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

            if (this.passwd == null)
                return false;

            if (this.document == null)
                return false;

            if (this.address == null)
                return false;

            if (this.date_of_birth >= DateTime.Now ||
                    DateTime.Compare(this.date_of_birth, new DateTime(1900, 1, 1)) < 0)
                return false;

            if (this.login == null)
                return false;

            return true;
        }

        public static Client convertDTOToModel(ClientDTO obj)
        {
            var client = new Client();
            if (obj.address != null)
            {
                client.address = Address.convertDTOToModel(obj.address);
            }

            client.setAge(obj.date_of_birth);
            client.setEmail(obj.email);
            client.setPhone(obj.phone);
            client.setDoc(obj.document);
            client.setPassword(obj.passwd);
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
            clientDTO.passwd = this.passwd;
            clientDTO.login = this.login;
            clientDTO.email = this.email;
            clientDTO.date_of_birth = this.date_of_birth;

            return clientDTO;
        }

        public ClientDTO findById(int id)
        {
            ClientDTO cliente = new ClientDTO();
            using (var contexto = new DAOContext())
            {
                var clientConsulta = contexto.client.Where(c => c.id == id).Join(contexto.address, x => x.id, y => y.id);
                //var addressConsulta = contexto.client.Join();
                Console.WriteLine(clientConsulta.address.id);
                cliente.name = clientConsulta.name;
                cliente.document = clientConsulta.document;
                cliente.email = clientConsulta.email;
                cliente.phone = clientConsulta.phone;
                cliente.login = clientConsulta.login;
                cliente.passwd = clientConsulta.passwd;
                cliente.date_of_birth = clientConsulta.date_of_birth;
                cliente.address = new AddressDTO
                {
                    street = addressConsulta.street,
                    city = addressConsulta.city,
                    state = addressConsulta.state,
                    country = addressConsulta.country,
                    postal_code = addressConsulta.postal_code
                };
            }
            return cliente;
        }

        public List<ClientDTO> getAll()
        {
            return this.clientDTO;
        }

        public int save()
        {
            int id = 0;

            using (var contexto = new DAOContext())
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
                    passwd = this.passwd,
                    document = this.document,
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
