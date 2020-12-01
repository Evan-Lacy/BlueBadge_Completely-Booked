using CompletelyBooked.Data;
using CompletelyBooked.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Services
{
    public class ReviewService
    { 
        //Create a review
        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review()
            {
                BookId = model.BookId,
                Rating = model.Rating,
                ReviewDescription = model.ReviewDescription
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    
        //Get All Reviews
        public IEnumerable<ReviewListItem> GetAllReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query = ctx
                    .Reviews
                    .Select
                    (e => new ReviewListItem
                    {
                        ReviewId = e.ReviewId,
                        Rating = e.Rating,
                        ReviewDescription = e.ReviewDescription
                    });

                return query.ToArray();
            }
        }

        //Get All Reviews of a Single Book by BookId
        public IEnumerable<ReviewDetail> GetReviewsByBook(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query = ctx
                    .Reviews
                    .Where(e => id == e.BookId)
                    .Select
                    (e => new ReviewDetail
                    {
                        ReviewId = e.ReviewId,
                        BookTitle = e.Book.Title,
                        Rating = e.Rating,
                        ReviewDescription = e.ReviewDescription
                    });

                return query.ToArray();
            }
        }

        //Get A Single Review by ReviewID
        public IEnumerable<ReviewDetail> GetByReviewId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query = ctx
                    .Reviews
                    .Where(e => id == e.ReviewId)
                    .Select
                    (e => new ReviewDetail
                    {
                        ReviewId = e.ReviewId,
                        BookTitle = e.Book.Title,
                        Rating = e.Rating,
                        ReviewDescription = e.ReviewDescription
                    });

                return query.ToArray();
            }
        }

        //Update Reviews
        public bool UpdateReview(ReviewEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.ReviewId == model.ReviewId);

                entity.Rating = model.Rating;
                entity.ReviewDescription = model.ReviewDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete a Review
        public bool DeleteReview(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => id == e.ReviewId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
