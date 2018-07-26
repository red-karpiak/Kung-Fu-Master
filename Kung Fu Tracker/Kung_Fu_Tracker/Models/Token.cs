using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Models
{
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// A Token class necessary for handling user logins and time outs.
    /// </summary>
    public class Token
    {
        public int Id { get; set; }
        public string accessToken { get; set; }
        public string errorDescription { get; set; }
        public DateTime expireDate { get; set; }
        public double expireIn { get; set; }
        public Token() { }
    }
}
