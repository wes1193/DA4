using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Entities
{   
     public class AppUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

         public string Phone { get; set; }

         public string Email { get; set; }

         public byte[] PasswordHash { get; set; }
         public byte[] PasswordSalt { get; set; }
         

    }
}