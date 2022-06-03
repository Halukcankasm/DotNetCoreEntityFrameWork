using Liblary.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Liblary.Data
{
    public class LiblarySeeder
    {
        private LiblaryContext _context;
        private IWebHostEnvironment _env;

        public LiblarySeeder(IWebHostEnvironment env)
        {
            LiblaryContext context = new LiblaryContext();
            _context = context;

            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
            if (!_context.Authors.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath,"Data/author2.json");
                var json = File.ReadAllText(filePath);
                var author = JsonSerializer.Deserialize<IEnumerable<Author>>(json);
                _context.Authors.AddRange(author);
                _context.SaveChanges();
            }
        }
    }
}
