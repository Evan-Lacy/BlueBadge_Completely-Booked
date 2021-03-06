﻿using CompletelyBooked.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class BookEdit
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public Group Group { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
        public bool IsBestSeller { get; set; }
        public string ISBN { get; set; }
    }
}
