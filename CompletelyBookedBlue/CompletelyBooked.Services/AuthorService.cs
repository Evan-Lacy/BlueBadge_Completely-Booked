using CompletelyBooked.Data;
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
                Name = model.AuthorName,
                Birthday = model.AuthorBirthday,
                Birthplace = model.AuthorBirtplace,
                About = model.AuthorAbout,
 
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
                        AuthorName = e.Name,
                        AuhtorBirthday = e.Birthday,
                        AuthorBirthplace = e.Birthplace,
                        AuhtorAbout = e.About
                    }
                    );
                return query.ToArray();
            }
        }

        public AuthorDetail GetAuthorByName(int name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.Authors.Single(e => e.Name == _name);
                return new AuthorDetail
                {
                    AuthorName = entity.Name,
                    AuthorBirthday = entity.Birthday,
                    AuthorBirthplace = entity.Birthplace,
                    AuthorAbout = entity.About,
                };
            }
        }
     }
}
