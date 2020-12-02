using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class AuthorBestSeller
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int BestSellerCount { get; set; }
        public virtual List<BookListItem> BooksWritten { get; set; }
    }
}
