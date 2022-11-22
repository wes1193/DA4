using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;

namespace API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]

    public class BaseApiController: ControllerBase
    {
        
    }
}