using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBook.Domain
{
    public class AppUser : IdentityUser
    {
        public string Country { get; set; }


    }
}
