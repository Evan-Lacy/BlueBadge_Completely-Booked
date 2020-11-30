using CompletelyBooked.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class PublisherListItem
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int YearFounded { get; set; }
        public  List<BookListItem> BooksPublished{ get; set; }
        public int BestSellerCount
        {
            get
            {
                int bestSellerCount = BooksPublished.Where(e => e.IsBestSeller == true).Count();
                //bestSellerCount += BooksPublished.Where(e => e.IsBestSeller == true).Count();

                return bestSellerCount;
            }
        }
        public int BookCount { get; set; }
    }
}
