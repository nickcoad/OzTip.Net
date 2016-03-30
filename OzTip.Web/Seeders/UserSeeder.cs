using System;
using OzTip.Common;
using OzTip.Models;
using OzTip.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace OzTip.Web.Seeders
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
