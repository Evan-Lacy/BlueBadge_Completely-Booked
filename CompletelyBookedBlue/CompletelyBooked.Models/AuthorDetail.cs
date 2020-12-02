using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Models
{
    //AuthorDetail - 
    //This Model Class is for displaying all of the details of a single Author
    //As selected via the AuthorId within the Service assembly. It returns all the information of
    //an Author object, including the Name, Birthday, Birthplace, About, and a list of all Books written by
    //The Author, as tied together via a Foreign Key within the Book class.
    public class AuthorDetail
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Birthplace { get; set; }
        public string About { get; set; }
        public virtual List<BookListItem> BooksWritten { get; set; }

    }
}