using OzTip.Core.Events.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Core.Events
{
    public class EventRegistry
    {
        public event EventHandler<GameFinishedEventArgs> GameFinished;

        public virtual void OnGameFinished(GameFinishedEventArgs args)
        {
            if (GameFinished != null)
            {
                GameFinished(this, args);
            }
        }
    }
}
