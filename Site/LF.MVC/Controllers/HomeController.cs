using System.Web.Mvc;
using LF.MVC.Models;

namespace LF.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new LineModel());
        }

    }
}
