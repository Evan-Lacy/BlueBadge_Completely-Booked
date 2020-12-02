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

        public IHttpActionResult GetAllBestSellers()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBestSellers();
            return Ok(books);
        }

        public IHttpActionResult Get(int id)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorBestSellersId(id);
            return Ok(author);
        }

        public IHttpActionResult Get(string name)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorBestSellersName(name);
            return Ok(author);
        }
    }
}
