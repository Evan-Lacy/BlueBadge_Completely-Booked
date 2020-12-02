using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompletelyBooked.WebAPI.Models
{
    //AuthorCreate - 
    //This Model Class is for creating a new instance of Author inside the Completely Booked
    //Database, including giving the object a Name, Birthday, Birthplace, and an About description
    public class AuthorCreate
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public string Birthplace { get; set; }
        [Required]
        public string About { get; set; }

    }
}