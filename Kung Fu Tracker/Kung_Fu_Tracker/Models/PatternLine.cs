﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Models
{
    /// <summary auth="J.Karpiak" date="26/07/26">
    /// A single step entry in a complete pattern
    /// 
    /// Again, I would like to have a DataItem base class to inherit from.
    /// </summary>
    public class PatternLine
    {
        
        public int ID { get; set; }
        public string Rank { get; set; }
        public int Order { get; set; }
        public string Feet { get; set; }
        public string LeftHand { get; set; }
        public string RightHand { get; set; }
        public PatternLine(string rank, int order = 0, string feet = "", string leftHand = "", string rightHand = "")
        {
            Rank = rank;
            Order = order;
            Feet = feet;
            LeftHand = leftHand;
            RightHand = rightHand;
        }

    }
}
