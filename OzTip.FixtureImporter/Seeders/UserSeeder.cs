using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OzTip.Data;
using OzTip.Models;

namespace OzTip.FixtureImporter.Seeders
{
    public static class UserSeeder
    {
        public static void Seed(OzTipContext context)
        {
            var rootUser = new User
            {
                UserName = "admin",
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                GivenName = "Nick",
                Surname = "Coad",
                Email = "nickcoad@gmail.com",
            };

            var userStore = new UserStore<User, Role, int, UserLogin, UserRole, UserClaim>(context);
            var userManager = new UserManager<User, int>(userStore);

            userManager.Create(rootUser, "password");
        }
    }
}
