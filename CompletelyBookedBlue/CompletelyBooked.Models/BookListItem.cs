using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class BookListItem
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public bool IsBestSeller { get; set; }
    }
}
