using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class ReviewCreate
    {
        public int BookId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        [MinLength(50, ErrorMessage = "Description Needs to be more than 50 Characters")]
        [MaxLength(1000, ErrorMessage = "Description Needs to be less than 1000 Characters")]
        public string ReviewDescription { get; set; }
    }
}
