using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.DataManagement
{
    public interface IRestService
    {
        //after working with PatternLine, genericize it
        Task<List<PatternLine>> GetData();
        Task SavePatternLine(PatternLine line);
        Task DeletePatternLine(int id);
    }
}
