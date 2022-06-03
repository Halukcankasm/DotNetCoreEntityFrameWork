using Liblary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblary.Data
{
    public class LiblaryContext : DbContext
    {
        private IConfiguration _configuration;

        public LiblaryContext()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", true, true)
                .Build();
            _configuration = configuration;
                                       
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }  


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionString:LiblaryContextDbPath"]);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
