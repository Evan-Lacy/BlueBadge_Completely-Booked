using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompletelyBooked.WebAPI.Models
{
    public class AuthorCreate
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Birthplace { get; set; }
        [Required]
        public string About { get; set; }

    }
}