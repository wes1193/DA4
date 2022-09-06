using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            Console.WriteLine("\n\n >>>>> [" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] Class Seed - SeedUsers - Start");
            // check and see if there are any users in the DB
            if(await context.Users.AnyAsync()) 
            {   Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "]Class Seed - SeedUsers - Found Some Users, so exiting");
                return;
            }
            
            // no users found, add the seed Data
            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "]Class Seed - SeedUsers - No Users Found - so add some");

            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "]Class Seed - SeedUsers - read seed data");
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "]Class Seed - SeedUsers - convert to a list");
            var users =  JsonSerializer.Deserialize<List<AppUser>>(userData);

            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "]Class Seed - SeedUsers - loop thru users");
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;
                context.Users.Add(user);   /* add users to EF Users collection, but not to the DB at this point */
                Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "]Class Seed - SeedUsers -adding user: " +  user.UserName.ToString());
            }

            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "]Class Seed - SeedUsers - Save users to DB");
            await context.SaveChangesAsync();

            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "]Class Seed - SeedUsers - Done\n\n");
        }
        
    }
}