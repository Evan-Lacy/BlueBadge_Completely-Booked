using CompletelyBooked.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class PublisherDetail
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int YearFounded { get; set; }
        public int BestSellerCount { get; set; }
        public virtual List<BookListItem> BooksPublished { get; set; }
    }
}
