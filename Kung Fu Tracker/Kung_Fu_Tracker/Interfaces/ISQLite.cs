using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Kung_Fu_Tracker.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
