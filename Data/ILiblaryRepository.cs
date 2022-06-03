using Liblary.Data.Entities;
using System.Collections.Generic;

namespace Liblary.Data
{
    public interface ILiblaryRepository
    {
        IEnumerable<Author> GetAllAuthor();
        IEnumerable<Author> GetAuthorByName(string authorName);
        IEnumerable<Book> GetAllBook();
    }
}