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
    public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
    {
        private static Client instance;

        private Guid uuid = Guid.NewGuid();

        public List<ClientDTO> clientDTO = new List<ClientDTO>();

        public Client(Address address) 
        {
            this.address = address;
        }

        private Client() { }

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
            return new ClientDTO();
        }

        public static object findByDoc(string document)
        {
            object obj;

            using (var contexto = new DAOContext())
            {
                var clientConsulta = contexto.client.Include(client => client.address).Where(c => c.document == document).Single();
                //Console.WriteLine(clientConsulta.address.id);
                obj = new
                {
                    name = clientConsulta.name,
                    document = clientConsulta.document,
                    email = clientConsulta.email,
                    phone = clientConsulta.phone,
                    login = clientConsulta.login,
                    passwd = clientConsulta.passwd,
                    date_of_birth = clientConsulta.date_of_birth,
                    address = clientConsulta.address,
                };
                
            }
            return obj;
        }

        public static ClientDTO findByUsername(string username)
        {
            ClientDTO obj;

            using (var contexto = new DAOContext())
            {
                var clientConsulta = contexto.client.Include(client => client.address).Where(c => c.login == username).Single();
                obj = new ClientDTO()
                {
                    name = clientConsulta.name,
                    document = clientConsulta.document,
                    email = clientConsulta.email,
                    phone = clientConsulta.phone,
                    login = clientConsulta.login,
                    passwd = clientConsulta.passwd,
                    date_of_birth = clientConsulta.date_of_birth
                };

            }
            return obj;
        }

        public List<ClientDTO> getAll()
        {
            return this.clientDTO;
        }

        public static List<ClientDTO> getAllClients()
        {
            using var context = new DAOContext();

            var list = context.client.ToList();
            List<ClientDTO> objs = new List<ClientDTO>();
            foreach(var client in list)
            {
                objs.Add(new ClientDTO
                {
                    name = client.name,
                    phone = client.phone,
                    email = client.email,
                    login = client.login,
                    date_of_birth = client.date_of_birth,
                    passwd = client.passwd
                });
            }

            return objs;
        }

        public int save()
        {
            int id = 0;

            using (var context = new DAOContext())
            {
                var emailexists = context.client.Where(c => c.email == this.email).FirstOrDefault();
                var documentexists = context.client.Where(c => c.document == this.document).FirstOrDefault();
                var phoneexists = context.client.Where(c => c.phone == this.phone).FirstOrDefault();
                var loginexists = context.client.Where(c => c.login == this.login).FirstOrDefault();

                if (emailexists == null && documentexists == null && phoneexists == null)
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

                    context.client.Add(client);

                    context.SaveChanges();

                    id = client.id;
                }
                else if (emailexists != null)
                {
                    id = -1;
                }
                else if (phoneexists != null)
                {
                    id = -2;
                }
                else if (documentexists != null)
                {
                    id = -3;
                }
                else if (loginexists != null)
                {
                    id = -4;
                }
            }

            return id;
        }

        public void update(ClientDTO obj)
        {

        }

        public void delete(ClientDTO obj)
        {

        }

        public int getId()
        {
            int id = 0;
            using (var contexto = new DAOContext())
            {
                try
                {
                    var clientConsulta = contexto.client.Where(c => c.login == this.login && c.passwd == this.passwd).Single();
                    id = clientConsulta.id;
                }
                catch
                {
                    id = -1;
                }

            }
            return id;
        
        }

        public static Client loginClient(LoginDTO login)
        {
            Client? obj;

            using (var contexto = new DAOContext())
            {
                try
                {
                    var clientConsulta = contexto.client.Where(c => c.login == login.login && c.passwd == login.passwd).Single();
                    obj = new Client
                    {
                        name = clientConsulta.name,
                        document = clientConsulta.document,
                        email = clientConsulta.email,
                        phone = clientConsulta.phone,
                        login = clientConsulta.login,
                        passwd = clientConsulta.passwd,
                        date_of_birth = clientConsulta.date_of_birth,
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
