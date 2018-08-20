using System.Web;
using System.Web.Mvc;

namespace MVC5_DDD_EF_NINJECT.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
