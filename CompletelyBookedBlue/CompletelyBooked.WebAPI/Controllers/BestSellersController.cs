using CompletelyBooked.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompletelyBooked.WebAPI.Controllers
{
    public class BestSellersController : ApiController
    {
        
        private BookService CreateBookService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new BookService();
            return bookService;
        }

      
        private AuthorService CreateAuthorService()
        {
            var authorService = new AuthorService();
            return authorService;
        }

        /// <summary>
        /// This is to get a list of all Best Sellers 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAllBestSellers()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBestSellers();
            return Ok(books);
        }

        /// <summary>
        /// This is to get a list of Best Sellers by Author ID
        /// </summary>
        /// <param name="id">This is to get a Best Seller List within the Completely Booked Database using the Author ID</param>
        /// <returns></returns>

        public IHttpActionResult Get(int id)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorBestSellersId(id);
            return Ok(author);
        }

        /// <summary>
        /// This is to get a list of Best Sellers by Author Name
        /// </summary>
        /// <param name="name">This is to get a Best Seller List within the Completely Booked Database using the Author Name</param>
        /// <returns></returns>
        public IHttpActionResult Get(string name)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorBestSellersName(name);
            return Ok(author);
        }
    }
}
