﻿using CompletelyBooked.Data;
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
        public int YearCreated { get; set; }
        //public virtual List<Book> BooksPublished{ get; set; }
        public int BestSellerCount { get; set; }
    }
}
