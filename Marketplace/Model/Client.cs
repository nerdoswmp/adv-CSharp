﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    public class Client : Person, IValidateDataObject<Client>
    {
        private static Client instance;

        private Guid uuid = Guid.NewGuid();

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

        public bool validateObject(Client obj)
        {

            if (obj.name == null)
                return false;

            if (obj.phone == null)
                return false;

            if (obj.email == null)
                return false;

            if (obj.document == null)
                return false;

            if (obj.address == null)
                return false;

            if (obj.date_of_birth >= DateTime.Now || 
                    DateTime.Compare(obj.date_of_birth, new DateTime(1900, 1, 1)) < 0)
                return false;

            if (obj.login == null)
                return false;

            return true;
        }
    }
}
