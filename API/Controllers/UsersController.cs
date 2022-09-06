using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        // private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            
        }

        [HttpGet] 
        /*[AllowAnonymous]*/
       //public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
       public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //var users = _context.Users.ToList();
            //return users;
            //return await  _context.Users.ToListAsync();
            
            //var users = await _userRepository.GetUsersAsync(); 
            // return Ok(users);
            //return Ok(await _userRepository.GetUsersAsync()); 

            // var users = await _userRepository.GetUsersAsync();
            // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            // return Ok(usersToReturn); 

            Console.WriteLine("\n\n>>>>>>>> <<<<<<<<< \nAPI UsersControler GetUsers\n\n");
            var users = await _userRepository.GetMembersAsync();
            return Ok(users); 
        }


        [HttpGet("{username}")]
        //public async Task<ActionResult<AppUser>> GetUser(string username)
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            // var user = _context.Users.Find(id);
            // return user;
            
            // return await  _context.Users.FindAsync(id);
            // return await _userRepository.GetUserByUsernameAsync(username);

            Console.WriteLine("\n\n>>>>> API UsersControler GetUser - username: " + username.ToString() + "\n");                      
            //var user  = await _userRepository.GetUserByUsernameAsync(username);
            //return  _mapper.Map<MemberDto>(user);

            return  await _userRepository.GetMemberAsync(username);                        
        }

        // api/users/3
       /* [Authorize] */
        /*[HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //var user = _context.Users.Find(id);
            //return user;
            Console.WriteLine("\n\nAPI UsersControler GetUsers - ID: " + id.ToString());           
            //return await  _context.Users.FindAsync(id);
            return Ok(await _userRepository.GetUserByIdAsync(id));  
        }
        */
    }
}