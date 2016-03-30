using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTip.Core.Interfaces
{
    public interface IHasTimeStamps
    {
        DateTime Updated { get; set; }
        DateTime Created { get; set; }
    }
}
