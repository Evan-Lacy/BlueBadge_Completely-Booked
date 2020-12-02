using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public string Birthplace { get; set; }
        [Required]
        public string About { get; set; }
        public virtual List<Book> BooksWritten { get; set; } = new List<Book>();
        public int BestSellerCount
        {
            get
            {
                int bestSellerCount = BooksWritten.Where(e => e.IsBestSeller == true).Count();
                return bestSellerCount;
            }
        }

    }

}
