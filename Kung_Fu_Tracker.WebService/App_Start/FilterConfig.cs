using System.Web;
using System.Web.Mvc;

namespace Kung_Fu_Tracker.WebService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
