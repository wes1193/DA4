using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using API.Interfaces;
using API.Services;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            Console.WriteLine("\n\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API ApplicationServiceExtensions - AddApplicationServices") ;            
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ILikesRepository, LikesRepository>();
            services.AddScoped<LogUserActivity>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly );
            
            //string svcs = services.ToArray().ToString() ;
            //Console.WriteLine("ApplicationServiceExtensions - AddApplicationServices - " + svcs) ; 

            services.AddDbContext<DataContext>(options => {   
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
                }
            );

            return services;
        }
    }
}