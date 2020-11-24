using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Data
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public Group Group { get; set; }
        [Required]

        public Genre Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Publisher { get; set; }
        public bool IsBestSeller { get; set; }
        public string ISBN { get; set; }



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
