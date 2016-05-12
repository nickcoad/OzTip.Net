using OzTip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Core.Achievements
{
    public class AchievementManager
    {
        private Dictionary<EventHandler, IAchievementChecker> _register { get; set; }

        public void RegisterAchievementChecker<TEventType, TAchievement>(IAchievementChecker achievementChecker)
        {

        }
    }
}
