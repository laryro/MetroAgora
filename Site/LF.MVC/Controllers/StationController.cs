using System.Web.Mvc;
using LF.MVC.Models;

namespace LF.MVC.Controllers
{
    public class StationController : Controller
    {
        public ActionResult Index()
        {
            return View(new StationModel());
        }

    }
}
