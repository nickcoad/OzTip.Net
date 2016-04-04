using OzTip.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Models
{
    public class Invitation : IHasTimeStamps
    {
        #region Keys
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int? UserId { get; set; }
        #endregion

        #region Metadata
        public string Token { get; set; }
        public string Email { get; set; }
        #endregion

        #region Auditing
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        #endregion

        #region Relationships
        public virtual User User { get; set; }
        #endregion
    }
}
