using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompletelyBooked.WebAPI.Models
{
    public class AuthorListItem
    {
        public int AuthorId { get; set; }
        public int AuthorName { get; set; }
        public string AuthorBirthday { get; set; }
        public string AuthorBirthplace { get; set; }
        public string AuthorAbout{ get; set; }
      
    }
}