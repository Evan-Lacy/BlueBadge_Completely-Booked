using CompletelyBooked.Services;
using CompletelyBooked.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompletelyBooked.WebAPI.Controllers
{
    public class AuthorController : ApiController
    {


        private AuthorService CreateAuthorService()
        {
            var authorService = new AuthorService();
            return authorService;
        }

        public IHttpActionResult Get()
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthors();
            return Ok(authors);
        }

        public IHttpActionResult Get(int name)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorByName(name);
            return Ok(author);
        }

        public IHttpActionResult Post(AuthorCreate author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateAuthorService();

            if (!service.CreateAuthor(author))
            {
                return InternalServerError();//500
            }

            return Ok();//200
        }

    }
}

