using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Models
{
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// A complete pattern for a specific rank
    /// 
    /// I would like to create a more generic "DataItem" class that all items that require entries in a DB can share,
    /// Have a generic base class would also make data submission cleaner
    /// </summary>
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
