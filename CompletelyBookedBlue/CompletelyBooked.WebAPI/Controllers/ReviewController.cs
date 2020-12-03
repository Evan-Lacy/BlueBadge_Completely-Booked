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
    public class ReviewController : ApiController
    {
        //Create Service
        private ReviewService CreateReviewService()
        {
            var reviewService = new ReviewService();
            return reviewService;
        }

        /// <summary>
        /// This is how to return all reviews 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetReviews()
        {
            ReviewService reviewService = CreateReviewService();
            var reviews = reviewService.GetAllReviews();
            return Ok(reviews);
        }

        /// <summary>
        /// Return a list of all Reviews of a single book by it's Id number
        /// </summary>
        /// <param name="id">This parameter is used for selecting all reviews of a book by that book's Id within the Completely Booked Database</param>
        /// <returns></returns>
        public IHttpActionResult GetReviewsByBookId(int id)
        {
            ReviewService reviewService = CreateReviewService();
            var reviews = reviewService.GetReviewsByBook(id);
            return Ok(reviews);
        }

        /// <summary>
        /// Return a single Review based on ReviewId
        /// </summary>
        /// <param name="reviewId">This paramter allows an authorized user to return a single review from within the database based on the ReviewId number.</param>
        /// <returns></returns>
        public IHttpActionResult GetByReviewId(int reviewId)
        {
            ReviewService reviewService = CreateReviewService();
            var reviews = reviewService.GetByReviewId(reviewId);
            return Ok(reviews);
        }

        /// <summary>
        /// Create a Review for a Book, with a Rating and Review Description.
        /// </summary>
        /// <param name="review">This parameter is to be used for creating a review of a book, giving it the values of a rating between 1-10 and a review description.</param>
        /// <returns></returns>
        public IHttpActionResult PostAReview(ReviewCreate review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateReviewService();

            if (!service.CreateReview(review))
            {
                return InternalServerError();
            }

            return Ok();
        }

        /// <summary>
        /// Update a book Review, changing the rating or editing the description
        /// </summary>
        /// <param name="review">This parameter is to be used for updating a book reivew made by the appropriate User Account. With this authorization, the rating can be updated, as can the description of the review itself.</param>
        /// <returns></returns>
        public IHttpActionResult Put(ReviewEdit review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400
            }

            var service = CreateReviewService();

            if (!service.UpdateReview(review))
            {
                return InternalServerError();//500
            }

            return Ok();//200
        }

        /// <summary>
        /// Delete a review based on the Review Id
        /// </summary>
        /// <param name="id">This parameter is designed to allow an authorized user to delete a review from the list of reviews on a book</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReviewService();

            if (!service.DeleteReview(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
