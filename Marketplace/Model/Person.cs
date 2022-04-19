using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        // Vars
        protected string name;
        protected DateTime date_of_birth;
        protected string passwd;
        protected string document;
        protected string email;
        protected string phone;
        protected string login;
        protected Address address;


        // Construtor
        public Person(Address address)
        {
            this.address = address;
        }

        // gets | sets
        public void setName(string name)
        {
            this.name = name;
        }
        
        public string getName()
        {
            return this.name;
        }

        public void setAge(DateTime age)
        {
            this.date_of_birth = age;
        }

        public DateTime getAge()
        {
            return this.date_of_birth;
        }

        public void setDoc(string document)
        {
            this.document = document;
        }

        public string getDoc()
        {
            return this.document;
        }

        public void setPassword(string password)
        {
            this.passwd = password;
        }

        public string getPassword()
        {
            return this.passwd;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setPhone(string phone)
        {
            this.phone = phone;
        }

        public string getPhone()
        {
            return this.phone;
        }

        public void setLogin(string login)
        {
            this.login = login;
        }

        public string getLogin()
        {
            return this.login;
        }

        public Address getAddress()
        {
            return this.address;
        }

    }
}
