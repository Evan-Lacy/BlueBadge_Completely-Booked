using CompletelyBooked.Data;
using CompletelyBooked.Models;
using CompletelyBooked.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Services
{

    public class AuthorService
    {


        public bool CreateAuthor(AuthorCreate model)
        {
            var entity = new Author()
            {
                Name = model.Name,
                Birthday = model.Birthday,
                Birthplace = model.Birthplace,
                About = model.About,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Authors
                    .Select
                    (e => new AuthorListItem
                    {
                        AuthorId = e.AuthorId,
                        Name = e.Name,
                        Birthday = e.Birthday,
                        Birthplace = e.Birthplace,
                        About = e.About
                    }
                    );
                return query.ToArray();
            }
        }

        public IEnumerable<AuthorDetail> GetAuthorByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx.Authors
                .Where(e => name == e.Name)
                .Select
                (e => new AuthorDetail
                {
                    AuthorId = e.AuthorId,
                    Name = e.Name,
                    Birthday = e.Birthday,
                    Birthplace = e.Birthplace,
                    About = e.About,
                    BooksWritten = e.BooksWritten.Select(b => new BookListItem
                    {
                        BookId = b.BookId,
                        AuthorId = b.Author.Name,
                        Title = b.Title,
                        IsBestSeller = b.IsBestSeller
                    }).ToList()
                });
                return query.ToArray();
            }
        }

        public IEnumerable<AuthorDetail> GetAuthorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx.Authors
                .Where(e => id == e.AuthorId)
                .Select
                (e => new AuthorDetail
                {
                    AuthorId = e.AuthorId,
                    Name = e.Name,
                    Birthday = e.Birthday,
                    Birthplace = e.Birthplace,
                    About = e.About,
                    BooksWritten = e.BooksWritten.Select(b => new BookListItem
                    {
                        BookId = b.BookId,
                        AuthorId = b.Author.Name,
                        Title = b.Title,
                        IsBestSeller = b.IsBestSeller
                    }).ToList()
                });
                return query.ToArray();
            }
        }

        public bool UpdateAuthor(AuthorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == model.AuthorId);

                entity.Name = model.Name;
                entity.Birthday = model.Birthday;
                entity.Birthplace = model.Birthplace;
                entity.About = model.About;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteAuthor(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == authorId);

                ctx.Authors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }


        }
    }

}
