using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    //AuthorEdit - 
    //This Model class is for allowing the user to edit the Author object in the
    //Database, changing the values for the Name, Birthday, Birthplace, and the About description
    public class AuthorEdit
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Birthplace { get; set; }
        public string About { get; set; }
    }
}
