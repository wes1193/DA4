using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {Console.WriteLine("\n\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API.Extensions.IdentityServiceExtensions - AddIdentityServices()") ;            
        return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {  Console.WriteLine("\n\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API.Extensions.IdentityServiceExtensions - AddIdentityServices()") ;            
             return int.Parse( user.FindFirst(ClaimTypes.NameIdentifier)?.Value );
        }
    }
}