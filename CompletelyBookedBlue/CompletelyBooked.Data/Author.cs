using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Data
{
    //Author Table
    //An author object requires a Name, a Birthday, a Birthplace, and an About
    //The Virtual List of type Book is for storing the relevant list of books that an
    //author is credited for writing and having published. It should contain all books that
    //have been created and given the same Author ID
    //
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public string Birthplace { get; set; }
        [Required]
        public string About { get; set; }
        public virtual List<Book> BooksWritten { get; set; } = new List<Book>();
        public int BestSellerCount
        {
            get
            {
                int bestSellerCount = BooksWritten.Where(e => e.IsBestSeller == true).Count();
                return bestSellerCount;
            }
        }

    }

}
