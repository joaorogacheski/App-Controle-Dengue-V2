using System.Web;
using System.Web.Mvc;

namespace App_Controle_Dengue_V2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
