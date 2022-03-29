using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Address
    {
        // vars
        private string street;
        private string city;
        private string state;
        private string country;
        private string poste_code;

        // Construtor
        public Address(string street, string city, string state, string country, string poste_code)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
            this.poste_code = poste_code;
        }

        public Address() { }

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

        public void setPostCode(string poste_code)
        {
            this.poste_code = poste_code;
        }

        public string getPostCode()
        {
            return this.poste_code;
        }
    }
}
