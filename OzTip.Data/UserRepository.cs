using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzTip.Core.Interfaces;
using OzTip.Models;

namespace OzTip.Data
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(OzTipContext context) : base(context)
        {

        }
    }
}
