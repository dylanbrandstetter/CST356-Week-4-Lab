using System.Web;
using System.Web.Mvc;

namespace CST356_Week_4_Lab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
