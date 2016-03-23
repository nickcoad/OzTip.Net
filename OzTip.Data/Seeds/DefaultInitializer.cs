using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzTip.Common;
using OzTip.Models;

namespace OzTip.Data.Seeds
{
    public class DefaultInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<OzTipContext>
    {
        protected override void Seed(OzTipContext context)
        {
            var passwordSalt = Utilities.GenerateSalt();
            var rootUser = new User
            {
                Username = "admin",
                Salt = passwordSalt,
                Password = Utilities.GeneratePasswordHash("l1TKYw9t", passwordSalt),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                GivenName = "Nick",
                Surname = "Coad",
                Email = "nickcoad@gmail.com",
            };

            context.Users.Add(rootUser);

            context.SaveChanges();
        }
    }
}
