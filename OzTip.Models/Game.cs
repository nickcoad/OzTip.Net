using OzTip.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OzTip.Models
{
    public class Game : IHasTimeStamps
    {
        #region Keys
        public int Id { get; set; }
        public int RoundId { get; set; }
        public int VenueId { get; set; }
        #endregion

        #region Metadata
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string TelstraCode { get; set; }
        #endregion

        #region Auditing
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        #endregion

        #region Relationships
        public virtual Round Round { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }

        public Score HomeScore
        {
            get { return Scores.FirstOrDefault(sc => sc.IsHome); }
        }
        public Score AwayScore
        {
            get { return Scores.FirstOrDefault(sc => !sc.IsHome); }
        }

        public int? HomeTeamId
        {
            get { return HomeScore != null ? HomeScore.TeamId : (int?)null; }
        }
        public int? AwayTeamId
        {
            get { return AwayScore != null ? AwayScore.TeamId : (int?)null; }
        }

        public Team HomeTeam
        {
            get { return HomeScore != null ? HomeScore.Team : null; }
        }
        public Team AwayTeam
        {
            get { return AwayScore != null ? AwayScore.Team : null; }
        }
        

        #endregion
    }
}
