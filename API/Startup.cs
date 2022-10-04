using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using API.Data;
using API.Interfaces;
using API.Services;
using API.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using API.Middleware;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
       
        public Startup(IConfiguration config)
        {
            Console.WriteLine("\n>>>> Startup.cs - constructor()");
            _config = config;
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            Console.WriteLine("\n\n>>>> API - Startup.cs - ConfigureServices()");
            services.AddApplicationServices(_config);
            services.AddControllers();
            services.AddCors();        /* add this to allow the Ang client to access the API on a different URL */
            services.AddIdentityServics(_config);

            services.AddSwaggerGen(c =>
                { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" } );
                }
            );
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /* don't change the order that these methods are called */

            //if (env.IsDevelopment())
            //{  app.UseDeveloperExceptionPage();                
            //}

            Console.WriteLine("\n>>>> Startup.cs - Configure()");
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            
            app.UseRouting();

            /* CORS Policy 
                add this to allow the Ang client to access the API on a different URL 
                has to be AFTER UseRouting and BEFORE UseEndpoints and UseAuthorization */
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")); 
 
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                                {  endpoints.MapControllers();
                                }
                            );
            
        }
    }
}
