using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.DataManagement
{
    public interface IDatabaseFetcher
    {
        string GetData(string conn);
    }
}
