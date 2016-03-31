using System.Collections.Generic;

namespace OzTip.Models
{
    public class Venue
    {
        #region Keys
        public int Id { get; set; }
        #endregion

        #region Metadata
        public string Stub { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string TimeZone { get; set; }
        public bool IsCurrent { get; set; }
        public string TelstraCode { get; set; }
        #endregion

        #region Relationships
        public virtual ICollection<Team> Teams { get; set; }
        #endregion
    }
}
