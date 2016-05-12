using OzTip.Data;
using OzTip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Core.Achievements.Checkers
{
    public abstract class OzTipContextAchievementChecker<TDtoType> : IAchievementChecker
    {
        protected readonly OzTipContext _context;

        public OzTipContextAchievementChecker(OzTipContext context)
        {
            _context = context; 
        }

        public abstract bool IsAchievementEarned(TDtoType dto);
    }
}
