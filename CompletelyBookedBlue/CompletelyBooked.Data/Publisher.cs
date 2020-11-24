using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Data
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public int YearFounded { get; set; }
        public virtual List<Book> BooksPublished { get; set; }
        public int BestSellerCount { get; set; }
    }
}
