using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using API.Data;
using API.Entities;
using API.DTOs;
using API.Services;
using API.Interfaces;
using AutoMapper;

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        public AccountController(DataContext context, 
                                ITokenService tokenService ,
                                IMapper mapper
                                )
        {   Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] AccountController Constructor") ;           
            _mapper = mapper;
            _tokenService = tokenService;
            _context = context;            
        }
        
        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register( RegisterDto registerDto)
        {
            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Register\n");
            if (await UserExists(registerDto.Username))  return BadRequest(String.Format("Username {0} is taken", registerDto.Username));


            var user = _mapper.Map<AppUser>(registerDto);

            using var hmac = new HMACSHA512();
            
            user.UserName = registerDto.Username.ToLower() ; 
            user.PasswordHash  = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password) );
            user.PasswordSalt = hmac.Key;            
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Register - saved user: " + user.UserName + "\n");
           
            return new UserDto
            {   Username = user.UserName ,
                Token = _tokenService.CreateToken(user) ,
                KnownAs = user.KnownAs
            };
                
        }


        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login( LoginDto loginDto)
        {   Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - \n");
           
            var user = await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username  );

            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - is user null\n");
            if (user == null)
            {
                Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - Unauthorized User \n");
                return Unauthorized(String.Format("Invalid username ({0}) ", loginDto.Username));
            }

            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - check user has and salt\n");
            if(user.PasswordHash == null || user.PasswordSalt == null )
            {
                Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - Unauthorized Password \n");
                return Unauthorized(String.Format("Invalid credentials for user ({0}) ", loginDto.Username));
            }

            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - get hmac");
            using var hmac = new HMACSHA512(user.PasswordSalt);

            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - computer hash");
            var computedHash =  hmac.ComputeHash( Encoding.UTF8.GetBytes(loginDto.Password) );
            
            for (int i = 0 ; i < computedHash.Length; i++)
            {
                if ( computedHash[i] != user.PasswordHash[i])
                {
                    Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - Invalid Password \n");
                    return Unauthorized(String.Format("Invalid password ({0}) ", loginDto.Password));
                }
            }

            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API AccountController - Login - return new user");
            return new UserDto
            {   Username = user.UserName,
                Token = _tokenService.CreateToken(user) ,
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url ,
                KnownAs = user.KnownAs
            };

        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        private async Task<bool> UserExists(string username)
        {
            bool b = false;
            b = _context.Users.Any(x => x.UserName == username.ToLower()  );
           //  return   b;
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());          
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */


    }
}