using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Entities;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context) 
        {
             _context =  context ;
        }
        
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
        Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API BuggyController - GetNotFound \n");
           var thing = _context.Users.Find(-1)  ;  // this will never exist

           if (thing == null) 
           { Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API BuggyController - GetNotFound - return Not Found: "  );
            return NotFound();
           }

           Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API BuggyController - GetNotFound - return OK "  +  thing.ToString() );
           return NotFound(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {   
            // try {
                Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API BuggyController - GetServerError \n");
                
                var thing = _context.Users.Find(-1)  ;  // this will never exist
                
                Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API BuggyController - GetServerError - generate NULL Exception \n");
                var thingToReturn = thing.ToString();   // generate a Null reference exception
                
                Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API BuggyController - GetServerError - return thingToReturn \n");
                
                 return StatusCode(500, "Status Code 500 thingToReturn: " + thingToReturn.ToString() );  ; 
         /*   }
            catch(Exception ex)
            {
                Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + 
                                "] API BuggyController - GetServerError - Exception: "
                                 + ex.Message + "\n");               
                //throw(ex);
                return StatusCode(500, "Computer says no!");
            }
           */ 
            
        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            Console.WriteLine("\n\n\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API BuggyController - GetBadRequest \n");
            return BadRequest("This was not a good request at all");  // 400
            //return Ok();            
            //return UnprocessableEntity() ;   // 422
           //return Forbid();    // 400
            //return ValidationProblem(); // 400
        }

    }
}