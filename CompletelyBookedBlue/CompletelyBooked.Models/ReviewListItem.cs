using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string ReviewDescription { get; set; }
    }
}
