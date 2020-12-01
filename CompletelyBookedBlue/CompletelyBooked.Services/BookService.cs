using CompletelyBooked.Data;
using CompletelyBooked.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Services
{
    public class BookService
    {

        public bool CreateBook(BookCreate model)
        {
            var entity = new Book()
            {
                Title = model.Title,
                AuthorId = model.AuthorId,
                PublisherId = model.PublisherId,
                Group = model.Group,
                Genre = model.Genre,
                Description = model.Description,
                IsBestSeller = model.IsBestSeller,
                ISBN = model.ISBN
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Books
                        .Select(
                            e =>
                                new BookListItem
                                {
                                    BookId = e.BookId,
                                    Title = e.Title,
                                    AuthorId = e.Author.Name,
                                    IsBestSeller = e.IsBestSeller
                                }
                                );
                return query.ToArray();
            }
        }

        public BookDetail GetBookById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == id);
                return
                    new BookDetail
                    {
                        BookId = entity.BookId,
                        Title = entity.Title,
                        Author = entity.Author.Name,
                        BookPublisher = entity.Publisher.Name,
                        Group = entity.Group.ToString(),
                        Genre = entity.Genre.ToString(),
                        Description = entity.Description,
                        IsBestSeller = entity.IsBestSeller,
                        ISBN = entity.ISBN,
                        Reviews = entity.Reviews.Select(e => new ReviewListItem
                        {
                            ReviewId = e.ReviewId,
                            Rating = e.Rating,
                            ReviewDescription = e.ReviewDescription
                        }).ToList()
                    };
            }
        }

        public BookDetail GetBookByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Title == title);
                return
                    new BookDetail
                    {
                        BookId = entity.BookId,
                        Title = entity.Title,
                        Author = entity.Author.Name,
                        BookPublisher = entity.Publisher.Name,
                        Group = entity.Group.ToString(),
                        Genre = entity.Genre.ToString(),
                        Description = entity.Description,
                        IsBestSeller = entity.IsBestSeller,
                        ISBN = entity.ISBN,
                        Reviews = entity.Reviews.Select(e => new ReviewListItem
                        {
                            ReviewId = e.ReviewId,
                            Rating = e.Rating,
                            ReviewDescription = e.ReviewDescription
                        }).ToList()
                    };
            }
        }

        public IEnumerable<BookListItem> GetBooksByAuthor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Books
                        .Where(e => e.AuthorId == id)
                        .Select(
                            e =>
                                    new BookListItem
                                    {
                                        BookId = e.BookId,
                                        Title = e.Title,
                                        AuthorId = e.Author.ToString(),
                                        IsBestSeller = e.IsBestSeller
                                    }
                                    );
                return query.ToArray();
            }
        }

        public IEnumerable<BookListItem> GetBooksByGenre(Genre genre)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Books
                        .Where(e => e.Genre == genre)
                        .Select(
                            e =>
                                    new BookListItem
                                    {
                                        BookId = e.BookId,
                                        Title = e.Title,
                                        AuthorId = e.Author.ToString(),
                                        IsBestSeller = e.IsBestSeller
                                    }
                                    );
                return query.ToArray();
            }
        }

        public BookDetail GetBookByISBN(string isbn)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.ISBN == isbn);
                return
                    new BookDetail
                    {
                        BookId = entity.BookId,
                        Title = entity.Title,
                        Author = entity.Author.ToString(),
                        BookPublisher = entity.Publisher.Name,
                        Group = entity.Group.ToString(),
                        Genre = entity.Genre.ToString(),
                        Description = entity.Description,
                        IsBestSeller = entity.IsBestSeller,
                        ISBN = entity.ISBN,
                        Reviews = entity.Reviews.Select(e => new ReviewListItem
                        {
                            ReviewId = e.ReviewId,
                            Rating = e.Rating,
                            ReviewDescription = e.ReviewDescription
                        }).ToList()
                    };
            }
        }

        public bool UpdateBook(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == model.BookId);

                entity.Title = model.Title;
                entity.AuthorId = model.AuthorId;
                entity.PublisherId = model.PublisherId;
                entity.Group = model.Group;
                entity.Genre = model.Genre;
                entity.Description = model.Description;
                entity.IsBestSeller = model.IsBestSeller;
                entity.ISBN = model.ISBN;

                return ctx.SaveChanges() == 1;

            }
        }


        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == bookId);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
