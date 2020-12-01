using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Data
{ 
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public int YearFounded { get; set; }

        public virtual List<Book> BooksPublished { get; set; } = new List<Book>();
        public int BestSellerCount 
        {
            get
            {
                int bestSellerCount = BooksPublished.Where(e => e.IsBestSeller == true).Count();
                //bestSellerCount++;
                return bestSellerCount;
            }
        }


        //[ForeignKey(nameof (IsBestSeller))]
        //public int BookId { get; set; }
        //public bool IsBestSeller { get; set; }
    }
}
