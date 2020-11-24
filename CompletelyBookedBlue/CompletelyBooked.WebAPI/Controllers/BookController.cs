using CompletelyBooked.Models;
using CompletelyBooked.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompletelyBooked.WebAPI.Controllers
{
    public class BookController : ApiController
    {
        private BookService CreateBookService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new BookService();
            return bookService;
        }

        public IHttpActionResult Get()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);
        }

        public IHttpActionResult GetById(int id)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBookById(id);
            return Ok(books);
        }

        public IHttpActionResult GetByTitle(string title)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBookByTitle(title);
            return Ok(books);
        }

        public IHttpActionResult GetByAuthor(string author)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooksByAuthor(author);
            return Ok(books);
        }

        public IHttpActionResult GetByISBN(string isbn)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBookByISBN(isbn);
            return Ok(books);
        }

        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.CreateBook(book))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(BookEdit book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.UpdateBook(book))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateBookService();

            if (!service.DeleteBook(id))
                return InternalServerError();

            return Ok();
        }
    }
}
