using CompletelyBooked.Data;
using CompletelyBooked.Models;
using CompletelyBooked.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletelyBooked.Services
{
   
     public class AuthorService
     {


        public bool CreateAuthor(AuthorCreate model)
        {
            var entity = new Author()
            {
                Name = model.Name,
                Birthday = model.Birthday,
                Birthplace = model.Birthplace,
                About = model.About,
 
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Authors
                    .Select
                    (e => new AuthorListItem
                    {
<<<<<<< HEAD
                        Name = e.Name,
                        Birthday = e.Birthday,
                        Birthplace = e.Birthplace,
                        About = e.About
=======
                        AuthorName = e.Name,
                        AuthorBirthday = e.Birthday,
                        AuthorBirthplace = e.Birthplace,
                        AuthorAbout = e.About
>>>>>>> 6eca9831f0671a6d105ebd3bef531d718837b625
                    }
                    );
                return query.ToArray();
            }
        }

        public AuthorDetail GetAuthorByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.Authors.Single(e => e.Name == name);
                return new AuthorDetail
                {
                    Name = entity.Name,
                    Birthday = entity.Birthday,
                    Birthplace = entity.Birthplace,
                    About = entity.About,
                };
            }
        }
     }
}
