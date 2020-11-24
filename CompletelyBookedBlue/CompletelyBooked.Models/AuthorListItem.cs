using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompletelyBooked.WebAPI.Models
{
    public class AuthorListItem
    {
        public class AuthorDetail
        {
            public int AuthorId { get; set; }
            public string Name { get; set; }
            public int Birthday { get; set; }
            public string Birthplace { get; set; }
            public string About { get; set; }

        }
    }

}
