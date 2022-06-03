using Liblary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblary.Data
{
    public class LiblaryRepository : ILiblaryRepository
    {
        private readonly ILogger<LiblaryRepository> _logger;
        private LiblaryContext _context;

        public LiblaryRepository(ILogger<LiblaryRepository> logger)
        {
            LiblaryContext context = new LiblaryContext();
            _context = context;

            _logger = logger;
        }

        public IEnumerable<Author> GetAllAuthor()
        {
            try
            {
                _logger.LogInformation("GetAllAuthor was called");
                //GetAllBook();
                return _context.Authors.Include( author => author.Books).OrderBy(
                    aouthor => aouthor.AuthorName
                ).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to gET ALL GetAllAuthor:{ex}");
                return null;
            }
        }

        public IEnumerable<Book> GetAllBook()
        {
            try
            {
                _logger.LogInformation("Get all Book was called");
                return _context.Books.OrderBy(
                    book => book.BookName
                ).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetAllBook:{ex}");
                return null;
            }
            
        }

        public IEnumerable<Author> GetAuthorByName(string authorName)
        {
            return _context.Authors.Where(
                    author => author.AuthorName == authorName
                ).ToList();
        }
    }
}
