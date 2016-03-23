using System;
using System.Collections.Generic;

namespace OzTip.Models
{
    public class User
    {
        #region Keys
        public int Id { get; set; }
        public int? TeamId { get; set; }
        #endregion

        #region Metadata
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string Email { get; set; }
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
    }
}
