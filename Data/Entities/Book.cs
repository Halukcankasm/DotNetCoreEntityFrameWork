using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liblary.Data.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string SubjectName { get; set; }
        public int CountOfPage { get; set; }
    }
}
