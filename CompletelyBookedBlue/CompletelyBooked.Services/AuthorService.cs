﻿using CompletelyBooked.Data;
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

        //Create a New Author object for the Database
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

        //Method to get all Authors within the Database
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

        //Method to retrieve the Author from the Database via the Author Name
        //The API call in Postman is a query - ?name=name
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
                    BestSellerCount = e.BooksWritten.Where(b => b.IsBestSeller == true).ToList().Count(),
                    BooksWritten = e.BooksWritten.Select(b => new BookListItem
                    {
                        BookId = b.BookId,
                        Author = b.Author.Name,
                        Title = b.Title,
                        IsBestSeller = b.IsBestSeller
                    }).ToList(),
                });
                return query.ToArray();
            }
        }

        //Method to retrieve the Author from the Database via the AuthorId
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
                    BestSellerCount = e.BooksWritten.Where(b => b.IsBestSeller == true).ToList().Count(),
                    BooksWritten = e.BooksWritten.Select(b => new BookListItem
                    { //This is a reference to display all the books and specific information about them
                        BookId = b.BookId,
                        Author = b.Author.Name,
                        Title = b.Title,
                        IsBestSeller = b.IsBestSeller
                    }).ToList()
                });
                return query.ToArray();
            }
        }


    


        public IEnumerable<AuthorBestSeller> GetAuthorBestSellersId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx.Authors
                .Where(e => id == e.AuthorId)
                .Select
                (e => new AuthorBestSeller
                {
                    AuthorId = e.AuthorId,
                    Name = e.Name,                   
                    BestSellerCount = e.BooksWritten.Where(b => b.IsBestSeller == true).ToList().Count(),
                    BooksWritten = e.BooksWritten.Where(b => b.IsBestSeller == true).ToList().Select(b => new BookListItem
                    {
                        BookId = b.BookId,
                        Author = b.Author.Name,
                        Title = b.Title,
                        IsBestSeller = b.IsBestSeller
                    }).ToList(),
                });
                return query.ToArray();
            }
        }


        public IEnumerable<AuthorBestSeller> GetAuthorBestSellersName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx.Authors
                .Where(e => name == e.Name)
                .Select
                (e => new AuthorBestSeller
                {
                    AuthorId = e.AuthorId,
                    Name = e.Name,
                    BestSellerCount = e.BooksWritten.Where(b => b.IsBestSeller == true).ToList().Count(),
                    BooksWritten = e.BooksWritten.Where(b => b.IsBestSeller == true).ToList().Select(b => new BookListItem
                    {
                        BookId = b.BookId,
                        Author = b.Author.Name,
                        Title = b.Title,
                        IsBestSeller = b.IsBestSeller
                    }).ToList(),
                });
                return query.ToArray();
            }
        }


        //Update an Author in the Database by changing Name, Birthday, Birthplace, or About
        //Based around the AuthorId


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

        //Delete an Author from the Database, and consequently deletes all books they have written from the Book Table
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
