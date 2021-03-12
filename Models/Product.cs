using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace Who_Whom_.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string User { get; set; }

        public AccountUser UsersAccount { get; set; }

    }

    public class AccountUser : IdentityUser
    {

        public AccountUser()
        {

        }
    }
}
