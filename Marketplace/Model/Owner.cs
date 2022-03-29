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

        public Owner(Adress adress):base(adress)
        { }

        public static Owner getInstance(Adress adress)
        {
            if (instance == null)
            {
                instance = new Owner(adress);
            }

            return instance;
        }

    

    }
}
