using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging.Console;


namespace API.Data
{
 
    public class DataContext : DbContext
    {
        // public static readonly LoggerFactory DbCommandConsoleLoggerFactory
        //         = new LoggerFactory (new [] {
        //             new ConsoleLoggerProvider ( (category, level) =>
        //                 category == DbLoggerCategory.Database.Command.Name &&
        //                 level == LogLevel.Information, true)
        //             });

       /* private readonly StreamWriter _logStream = new StreamWriter("mylog-" + DateTime.Now.ToString("hh.mm.ss.fffff") +".txt", append: true);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    => optionsBuilder
                        .LogTo(_logStream.WriteLine)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
        */

        public DataContext(DbContextOptions options) : base(options)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API-Data-DataContect-Constructor()");
        }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<UserLike> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API-Data-DataContect-OnModelCreating()");
           
            base.OnModelCreating(builder);        
           
            builder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.LikedUserId });


                builder.Entity<UserLike>()
                    .HasOne(s => s.SourceUser)
                    .WithMany(l => l.LikedUsers)
                    .HasForeignKey(s => s.SourceUserId)
                    .OnDelete(DeleteBehavior.Cascade);

                
                builder.Entity<UserLike>()
                    .HasOne(s => s.LikedUser)
                    .WithMany(l => l.LikedByUsers)
                    .HasForeignKey(s => s.LikedUserId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}









