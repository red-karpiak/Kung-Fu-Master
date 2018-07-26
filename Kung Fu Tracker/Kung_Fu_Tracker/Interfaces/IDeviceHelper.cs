using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Interfaces
{
    /// <summary>
    /// retrieve device specific information
    /// </summary>
    public interface IDeviceHelper
    {
        int GetDeviceWidth();
        int GetDeviceHeight();
    }
}
