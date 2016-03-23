using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Models
{
    public class Round
    {
        #region Keys
        public int Id { get; set; }
        public int SeasonId { get; set; }
        #endregion

        #region Metadata
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string TelstraCode { get; set; }
        #endregion

        #region Auditing
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        #endregion

        #region Relationships
        public virtual Season Season { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        #endregion
    }
}
