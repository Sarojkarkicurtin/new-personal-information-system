using System.Web;
using System.Web.Mvc;

namespace personal_inforamtion_system_new
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
