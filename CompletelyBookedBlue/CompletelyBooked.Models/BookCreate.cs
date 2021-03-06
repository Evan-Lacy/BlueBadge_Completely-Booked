﻿using CompletelyBooked.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    //BookCreate - 
    //This Model Class is for creating a new instance of Book inside the Completely Booked
    //Database, including giving the object a Name, Birthday, Birthplace, and a description. 
    public class BookCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public Group Group { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        [MaxLength(5000, ErrorMessage = "Description needs to be less than 5000 characters.")]
        public string Description { get; set; }
        public bool IsBestSeller { get; set; }
        public string ISBN { get; set; }

    }
}
