﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Data
{
    //Book Table
    //A book object requires a BookID, a Title, a Group, a Genre, a Description, A Publisher ID and an Author ID
    //Foreign Key -- Publisher ties a book to a publisher; author ties a book to an author
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        //[Required]
        //public string Author { get; set; }
        [Required]
        public Group Group { get; set; }
        [Required]

        public Genre Genre { get; set; }
        [Required]
        public string Description { get; set; }
        //[Required]
        //public string BookPublisher { get; set; }
        public bool IsBestSeller { get; set; }
        public string ISBN { get; set; }

        public virtual List<Review> Reviews { get; set; } = new List<Review>();
        public virtual List<Book> BooksWritten { get; set; } = new List<Book>();

        //[Required]
        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
    public enum Genre
    {
        [Display(Name ="Action/Adventure")]
        Action_Adventure = 1,
        Alternate_history,
        Anthology,
        Art_Architecture,
        Autobiography,
        Biography,
        Business,
        Chick_lit,
        Childrens,
        Classic,
        Comic_book,
        Coming_of_age,
        Cookbook,
        Crime,
        Encyclopedia,
        Drama,
        Fantasy,
        Graphic_novel,
        History,
        Horror,
        Humor,
        Memoir,
        Mystery,
        Poetry,
        Romance,
        Satire,
        Science,
        Science_fiction,
        Short_story,
        Sports,
        True_crime,
        Thriller,
        Western,
        Young_adult

    }

    public enum Group
    {
        [Display(Name = "Fiction")]
        Fiction = 1,
        [Display(Name = "Non-Fiction")]
        NonFiction
    }
}
