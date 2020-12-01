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

        /// <summary>
        /// This is to get a list of all Authors
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthors();
            return Ok(authors);
        }

        /// <summary>
        /// This is to get Authors by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult Get(string name)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorByName(name);
            return Ok(author);
        }

        /// <summary>
        /// This is to Create an Author
        /// </summary>
        /// <returns></returns>
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

