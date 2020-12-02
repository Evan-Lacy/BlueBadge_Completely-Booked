using CompletelyBooked.Data;
using CompletelyBooked.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Services
{
    public class PublisherService
    {
      
        public bool CreatePublisher(PublisherCreate model)
        {
            var entity = new Publisher()
            {
                PublisherId = model.PublisherId,
                Name = model.Name,
                Location = model.Location,
                YearFounded = model.YearFounded
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get Publishers by Id
        public IEnumerable<PublisherDetail> GetPublishersById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Publishers
                    .Where (e => id == e.PublisherId)
                    .Select
                    (e => new PublisherDetail
                    {
                        PublisherId = e.PublisherId,
                        Name = e.Name,
                        Location = e.Location,
                        YearFounded = e.YearFounded,
                        BestSellerCount = e.BooksPublished.Where(b => b.IsBestSeller == true).ToList().Count(),
                        BooksPublished = e.BooksPublished.Select(b => new BookListItem
                        {
                            BookId = b.BookId,
                            AuthorId = b.Author.Name,
                            Title = b.Title, 
                            IsBestSeller = b.IsBestSeller
                        }).ToList()
                    }) ;
                return query.ToArray();
            }
        }

        //method to get a list of publishers 
        public IEnumerable<PublisherListItem> GetPublishers()
        {           
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Publishers
                    .Select
                    (e => new PublisherListItem
                    {
                        PublisherId = e.PublisherId,
                        Name = e.Name,
                        Location = e.Location,
                        YearFounded = e.YearFounded,
                        BookCount = e.BooksPublished.Count(),
                        BestSellerCount = e.BooksPublished.Where(b => b.IsBestSeller == true).ToList().Count()
                    });
                return query.ToArray();
            }
        }

        //method to update a publisher 
        public bool UpdatePublisher(PublisherEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Single(e => e.Name == model.Name);

                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.YearFounded = model.YearFounded;

                return ctx.SaveChanges() == 1;
            }
        }


        //method to delete a publisher; will delete books 
        public bool DeletePublisher(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Single(e => e.Name == name);

                ctx.Publishers.Remove(entity);

                return ctx.SaveChanges() == 1; 
            }
        }
    }
}
