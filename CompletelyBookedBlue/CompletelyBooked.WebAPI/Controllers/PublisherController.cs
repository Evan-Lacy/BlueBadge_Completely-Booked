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
        private PublisherService CreatePublisherService()
        {
            var pubService = new PublisherService();
            return pubService;
        }

        /// <summary>
        /// This is to get a list of Publishers 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            PublisherService pubService = CreatePublisherService();
            var publishers = pubService.GetPublishers();
            return Ok(publishers);
        }

        /// <summary>
        /// This is to get publishers by Id
        /// </summary>
        /// <param name="id">This is to get a publisher by the publisher ID within the Completely Booked Database</param>
        /// <returns></returns>
        public IHttpActionResult GetById(int id)
        {
            PublisherService pubService = CreatePublisherService();
            var publishers = pubService.GetPublishersById(id);
            return Ok(publishers);
        }


        /// <summary>
        /// This is to create a Publisher 
        /// </summary>
        /// <param name="publisher">This is to create a Publisher within the Completely Booked Database</param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete a Publisher via this query with the Publisher Name
        /// </summary>
        /// <param name="name">This parameter is designed to allow the authorized user to delete a publisher from the Completely Booked Database.</param>
        /// <returns></returns>
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
