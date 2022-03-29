using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Client : Person
    {
        private static Client instance;

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
    }
}
