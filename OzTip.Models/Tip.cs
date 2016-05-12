using OzTip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Models
{
    public class Tip : IHasTimeStamps
    {
        #region Keys
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public int GameId { get; set; }
        #endregion

        #region Metadata
        public bool IsTentative { get; set; }
        #endregion

        #region Auditing
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        #endregion

        #region Relationships
        public virtual Competition Competition { get; set; }
        public virtual Game Game { get; set; }
        public virtual Team Team { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}
