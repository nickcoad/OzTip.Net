using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OzTip.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OzTip.Models
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>, IHasTimeStamps
    {
        #region Keys
        public int? TeamId { get; set; }
        #endregion

        #region Metadata
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        #endregion

        #region Auditing
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        #endregion

        #region Relationships
        public virtual ICollection<Tip> Tips { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual Team Team { get; set; }
        #endregion


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
