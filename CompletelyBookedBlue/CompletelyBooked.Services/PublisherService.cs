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
        public IEnumerable<PublisherListItem> GetPublishersById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Publishers
                    .Where (e => id == e.PublisherId)
                    .Select
                    (e => new PublisherListItem
                    {
                        PublisherId = e.PublisherId,
                        Name = e.Name,
                        Location = e.Location,
                        YearFounded = e.YearFounded,
                        BestSellerCount = e.BestSellerCount,
                        BooksPublished = e.BooksPublished.Select(b => new BookListItem
                        {
                            BookId = b.BookId,
                            Author = b.Author,
                            Title = b.Title
                        }).ToList()
                    }) ;
                return query.ToArray();
            }
        }

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
                        BestSellerCount = e.BestSellerCount,
                        BookCount = e.BooksPublished.Count()
                       
                    });
                return query.ToArray();
            }
        }

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
