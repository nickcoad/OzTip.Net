using OzTip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Models
{
    public class Score : IHasTimeStamps
    {
        #region Keys
        public int Id { get; set; }
        public int GameId { get; set; }
        public int TeamId { get; set; }
        #endregion

        #region Metadata
        public int Behinds { get; set; }
        public int Goals { get; set; }
        
        public int Total
        {
            get { return (Goals*6) + Behinds; }
        }

        public bool IsHome { get; set; }
        #endregion

        #region Auditing
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        #endregion

        #region Relationships
        public virtual Game Game { get; set; }
        public virtual Team Team { get; set; }
        #endregion
    }
}
