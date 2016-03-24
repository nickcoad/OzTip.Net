using System;
using OzTip.Common;
using OzTip.Models;

namespace OzTip.Data.Seeders
{
    public static class UserSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var passwordSalt = Utilities.GenerateSalt();
            var rootUser = new User
            {
                Username = "admin",
                Salt = passwordSalt,
                Password = Utilities.GeneratePasswordHash("password", passwordSalt),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                GivenName = "Nick",
                Surname = "Coad",
                Email = "nickcoad@gmail.com",
            };

            context.Users.Add(rootUser);
        }
    }
}
