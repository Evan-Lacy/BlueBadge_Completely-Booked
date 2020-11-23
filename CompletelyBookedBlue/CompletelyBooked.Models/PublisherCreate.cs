using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class PublisherCreate
    {
        //Creating a Publisher item in this table requires the User to only input two items
        //The Name and the Location of the Publisher. The BestSellerCount and virtual List of Books will be popuulated later.

        public int PublisherId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int YearCreated { get; set; }
    }
}
