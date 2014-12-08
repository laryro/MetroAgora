using System.Web.Mvc;
using LF.MVC.Models;
using System;
using LF.MVC.Authorize;

namespace LF.MVC.Controllers
{
    public class StationController : Controller
    {
        public ActionResult Index(Int32 id)
        {
            var model = new StationModel(id);
            
            return View(model);
        }

        [LFAuthorize]
        public ActionResult Create(Int32 stationId)
        {
            return View( new NewOccurrenceModel(stationId));
        }

        [HttpPost]
        public ActionResult Create(NewOccurrenceModel model, Int32 stationId)
        {
            
            model.StationId = stationId;
            model.Save();
            return View(new NewOccurrenceModel(stationId));
        }

    }
}
