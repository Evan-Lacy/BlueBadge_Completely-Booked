using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string ReviewDescription { get; set; }


        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        //public string ISBN { get; set; }
    }
}
