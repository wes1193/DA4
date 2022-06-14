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

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register( RegisterDto registerDto)
        {
                if (await UserExists(registerDto.Username))  return BadRequest(String.Format("Username {0} is taken", registerDto.Username));

                using var hmac = new HMACSHA512();

                var user = new AppUser()
                {
                    UserName = registerDto.Username.ToLower(),
                    PasswordHash  = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password) ),
                    PasswordSalt = hmac.Key
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return new UserDto{
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
                
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login( LoginDto loginDto)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username  );

            if (user == null)
                return Unauthorized(String.Format("Invalid username ({0}) ", loginDto.Username));
            
            if(user.PasswordHash == null || user.PasswordSalt == null )
                 return Unauthorized(String.Format("Invalid credentials for user ({0}) ", loginDto.Username));

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash =  hmac.ComputeHash( Encoding.UTF8.GetBytes(loginDto.Password) );
            
            for (int i = 0 ; i < computedHash.Length; i++)
            {
                if ( computedHash[i] != user.PasswordHash[i])
                    return Unauthorized(String.Format("Invalid password ({0}) ", loginDto.Password));
            }

            return new UserDto{
                 Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }

        private async Task<bool> UserExists(string username)
        {
            bool b = false;
            b = _context.Users.Any(x => x.UserName == username.ToLower()  );
           //  return   b;
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());          
        }
    }
}