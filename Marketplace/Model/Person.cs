using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Person
    {
        // Vars
        protected string name;
        protected int age;
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

        public void setAge(int age)
        {
            this.age = age;
        }

        public int getAge()
        {
            return this.age;
        }

        public void setDoc(string document)
        {
            this.document = document;
        }

        public string getDoc()
        {
            return this.document;
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

    }
}
