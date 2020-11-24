using CompletelyBooked.Models;
using CompletelyBooked.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompletelyBooked.WebAPI.Controllers
{
    public class PublisherController : ApiController
    {
        public PublisherService CreatePublisherService()
        {
            var pubService = new PublisherService();
            return pubService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            PublisherService pubService = CreatePublisherService();
            var publishers = pubService.GetPublishers();
            return Ok(publishers);
        }

        [HttpPost]
        public IHttpActionResult Post(PublisherCreate publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400
            }

            var service = CreatePublisherService();

            if (!service.CreatePublisher(publisher))
            {
                return InternalServerError();//500
            }

            return Ok();//200
        }

        [HttpPut]
        public IHttpActionResult Put(PublisherEdit publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400
            }

            var service = CreatePublisherService();

            if (!service.UpdatePublisher(publisher))
            {
                return InternalServerError();//500
            }

            return Ok();//200
        }

        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            var service = CreatePublisherService();

            if (!service.DeletePublisher(name))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
