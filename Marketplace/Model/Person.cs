using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Person
    {
        protected string name;
        protected int age;
        protected string document;
        protected string email;
        protected string phone;
        protected string login;

    }

    class Owner : Person
    {

    }

    class Client : Person
    {

    }
}
