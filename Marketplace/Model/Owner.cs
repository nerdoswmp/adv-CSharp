using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    class Owner : Person, IValidateDataObject<Owner>
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


        public bool validateObject(Owner obj)
        {
            if (obj.name == null)
                return false;

            else if (obj.phone == null)
                return false;

            else if (obj.email == null)
                return false;

            else if (obj.document == null)
                return false;

            else if (obj.address == null)
                return false;

            else if (obj.date_of_birth >= DateTime.Now ||
                    DateTime.Compare(obj.date_of_birth, new DateTime(1900, 1, 1)) < 0)
                return false;

            else if (obj.login == null)
                return false;

            else
                return true;
        }
    }
}
