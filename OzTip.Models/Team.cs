using System;
using System.Collections.Generic;

namespace OzTip.Models
{
    public class Team
    {
        #region Keys
        public int Id { get; set; }
        public int? VenueId { get; set; }
        #endregion

        #region Metadata
        public string Stub { get; set; }
        public string Code { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Description { get; set; }
        public bool IsCurrent { get; set; }
        public string TelstraCode { get; set; }
        #endregion

        #region Auditing
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        #endregion

        #region Relationships
        public virtual ICollection<Score> Scores { get; set; }
        public virtual Venue Venue { get; set; }
        #endregion
    }
}
