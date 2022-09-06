using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using API.Errors;
using System.Text.Json;


namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _next;
        readonly ILogger<ExceptionMiddleware> _logger;
        readonly  IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next,  
                                    ILogger<ExceptionMiddleware> logger , 
                                    IHostEnvironment env )
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try {
                Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API.Middleware.ExceptionMiddleware - InvokeAsync - Start Try Block \n");
                await _next(context);
                 Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API.Middleware.ExceptionMiddleware - InvokeAsync  - Exit Try Block \n");
           
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] API ExceptionMiddleware - InvokeAsync Exception Block \n");
               
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)  HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment() 
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Server Error") ;

                var options  = new JsonSerializerOptions{PropertyNamingPolicy =  JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response, options);  

                await context.Response.WriteAsync(json);

            }
        }
    }
}