using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompletelyBooked.WebAPI.Models
{
    public class AuthorListItem
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Birthplace { get; set; }
        public string About{ get; set; }
      
    }

}
