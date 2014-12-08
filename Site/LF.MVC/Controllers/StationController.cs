using System.Web.Mvc;
using LF.MVC.Models;
using System;

namespace LF.MVC.Controllers
{
    public class StationController : Controller
    {
        public ActionResult Index(Int32 id)
        {
            var model = new StationModel(id);
            
            return View(model);
        }

        public ActionResult Create()
        {
            return View( new NewOccurrenceModel());
        }

        [HttpPost]
        public ActionResult Create(NewOccurrenceModel model, Int32 stationId)
        {
            model.Save();
            return View(new NewOccurrenceModel(stationId));
        }

    }
}
