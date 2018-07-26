using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.DataManagement
{
    ///<comment J.Karpiak date="26/07/18">
    ///I had planned on making it generic after i had it working with the PatternLine object,
    ///I realise i should have made it generic from the beginning to avoid having to go back and change a bunch of things 
    ///which would waste time
    ///</comment>
    public interface IRestService
    {
        Task<List<PatternLine>> GetData();
        Task SavePatternLine(PatternLine line);
        Task DeletePatternLine(int id);
    }
}
