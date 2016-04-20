using OzTip.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace OzTip.Models
{
    public class Competition : IHasTimeStamps
    {
        #region Keys
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SeasonId { get; set; }
        #endregion

        #region Metadata
        public string Name { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public bool IsPrivate { get; set; }
        #endregion

        #region Auditing
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        #endregion

        #region Relationships
        public virtual Season Season { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<User> Users { get; set; }
        #endregion

        public Competition()
        {
            Users = new List<User>();
        }
    }
}
