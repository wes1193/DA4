using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Extensions;

namespace API.Entities
{   
     public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash{ get; set; }
        public byte[] PasswordSalt{ get; set; }
         public string Phone { get; set; }
         public string Email { get; set; }
         public DateTime DateOfBirth { get; set; }
         public string KnownAs { get; set; }
         public DateTime Created { get; set; } = DateTime.Now;
         public DateTime LastActive { get; set; }= DateTime.Now;
         public string Gender { get; set; }
         public string LookingFor { get; set; }                
         public string Interests { get; set; }
         public string Description { get; set; }
         public string Introduction { get; set; }
         public string City { get; set; }
         public string Country { get; set; }

         public ICollection<Photo> Photos { get; set; }

         public ICollection<UserLike> LikedByUsers { get; set; }

         public ICollection<UserLike> LikedUsers { get; set; }

         AppUser()
         {
            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API-Entity-Constructor()");
         }
         
        
    }   // end - class
}       // end - namespace