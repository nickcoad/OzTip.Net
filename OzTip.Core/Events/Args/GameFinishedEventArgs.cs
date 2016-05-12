using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Core.Events.Args
{
    public class GameFinishedEventArgs : EventArgs
    {
        public int GameId { get; set; }
    }
}
