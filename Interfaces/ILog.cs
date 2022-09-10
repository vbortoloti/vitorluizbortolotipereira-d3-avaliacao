using login_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_system.Interfaces
{
    internal interface ILog
    {
       void RegisterAccess(User user, string status);
    }
}
