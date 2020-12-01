using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class AuthorDetail
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Birthplace { get; set; }
        public string About { get; set; }
        public virtual List<BookListItem> BooksWritten { get; set; }

    }
}