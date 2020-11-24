using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompletelyBooked.WebAPI.Models
{
    public class AuthorListItem
    {
<<<<<<< HEAD
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }
        public string About{ get; set; }
      
=======
        public class AuthorDetail
        {
            public int AuthorId { get; set; }
            public string Name { get; set; }
            public int Birthday { get; set; }
            public string Birthplace { get; set; }
            public string About { get; set; }

        }
>>>>>>> 6eca9831f0671a6d105ebd3bef531d718837b625
    }

}
