﻿using CompletelyBooked.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    //BookDetail - 
    //This Model Class is for displaying all of the details of a single Book
    public class BookDetail
    {
        public int BookId { get; set; }       
        public string Title { get; set; }       
        public string Author { get; set; }        
        public string BookPublisher { get; set; }
        public string Group { get; set; }       
        public string Genre { get; set; }      
        public string Description { get; set; }     
        public bool IsBestSeller { get; set; }
        public string ISBN { get; set; }

        public virtual List<ReviewListItem> Reviews { get; set; }
    }
}
