using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblary.Data.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
