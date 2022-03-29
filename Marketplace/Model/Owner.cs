using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Owner : Person
    {
        private static Owner instance;

        public Owner(Address address):base(address)
        { }

        public static Owner getInstance(Address address)
        {
            if (instance == null)
            {
                instance = new Owner(address);
            }

            return instance;
        }

    

    }
}
