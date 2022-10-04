using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MemberUpdateDto
    {
        public String Introduction {get;set;}
        public String Description {get;set;}
        public String LookingFor {get;set;}
        public String Interests {get;set;}
        public String City {get;set;}
        public String Country {get;set;}
        
    }
}