using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    public class AuthorDetail
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorBirthday { get; set; }
        public string AuthorBirthplace { get; set; }
        public string AuthorAbout { get; set; }

    }
}