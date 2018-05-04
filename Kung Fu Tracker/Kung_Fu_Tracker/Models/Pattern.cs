using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Models
{
    public class Pattern
    {
        public int ID { get; set; }
        public string Rank { get; set; }
        public List<PatternLine> PatternLines { get; set; }

        public Pattern() { }
        public Pattern(string rank, List<PatternLine> patternLines)
        {
            Rank = rank;
            if (patternLines == null)
                PatternLines = new List<PatternLine>();
            else
                PatternLines = patternLines;
        }
    }
}
