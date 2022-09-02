using System.Web;
using System.Web.Mvc;

namespace CuaHangVatLieuXayDung
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
