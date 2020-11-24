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
        public string Name { get; set; }
<<<<<<< HEAD
        public DateTime Birthday { get; set; }
=======
        public int Birthday { get; set; }
>>>>>>> 6eca9831f0671a6d105ebd3bef531d718837b625
        public string Birthplace { get; set; }
        public string About { get; set; }

    }
}