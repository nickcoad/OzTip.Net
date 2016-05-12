using OzTip.Core.Achievements.Dtos;
using OzTip.Data;
using OzTip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Core.Achievements.Checkers
{
    internal class PerfectRoundAchievementChecker : OzTipContextAchievementChecker<PerfectRoundAchievementDto>
    {
        public PerfectRoundAchievementChecker(OzTipContext context)
            : base(context)
        {

        }

        public override bool IsAchievementEarned(PerfectRoundAchievementDto dto)
        {
            return (dto.NumberOfGamesInRound == dto.NumberOfWins);
        }
    }
}
