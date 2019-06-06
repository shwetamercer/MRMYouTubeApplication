using MRMMVC.Utilitis;
using System.Web.Mvc;

namespace MRMMVC.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            Logger.Info("Index started...");

            return View();
        }
    }
}

