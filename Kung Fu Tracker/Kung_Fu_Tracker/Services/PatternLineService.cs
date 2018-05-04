using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Services
{
    public class PatternLineService
    {
        public ObservableCollection<PatternLine> GetPatternLines()
        {
            var list = new ObservableCollection<PatternLine>();
            return list;
        }
    }
}
