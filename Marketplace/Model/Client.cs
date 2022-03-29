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

        public Client(Adress adress) : base(adress)
        { }

        public static Client getInstance(Adress adress)
        {
            if (instance == null)
            {
                instance = new Client(adress);
            }

            return instance;
        }
    }
}
