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

        /// <summary>
        /// This is to get a list of all books
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);
        }

        /// <summary>
        /// This is to get a Book by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetById(int id)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBookById(id);
            return Ok(books);
        }

        /// <summary>
        /// This is to get books by Title 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public IHttpActionResult GetByTitle(string title)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBookByTitle(title);
            return Ok(books);
        }

        /// <summary>
        /// This is to get books by Author 
        /// </summary>
        /// <param name="author">This is to get books by Author within the Completely Booked Database</param>
        /// <returns></returns>
        public IHttpActionResult GetByAuthor(string author)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooksByAuthor(author);
            return Ok(books);
        }

        /// <summary>
        /// This is to get books by ISBN
        /// </summary>
        /// <param name="isbn">This is to get books by ISBN within the Completely Booked Database</param>
        /// <returns></returns>
        public IHttpActionResult GetByISBN(string isbn)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBookByISBN(isbn);
            return Ok(books);
        }

        /// <summary>
        /// This is to Create a new Book
        /// </summary>
        /// <param name="book">This is to create a new book within the Completely Booked Database</param>
        /// <returns></returns>
        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.CreateBook(book))
                return InternalServerError();

            return Ok();
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public IHttpActionResult Put(BookEdit book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.UpdateBook(book))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// This is to delete a book by ID 
        /// </summary>
        /// <param name="id">This is to delete a book by using the book ID</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateBookService();

            if (!service.DeleteBook(id))
                return InternalServerError();

            return Ok();
        }
    }
}
