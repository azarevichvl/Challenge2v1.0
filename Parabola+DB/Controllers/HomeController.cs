using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParabolaDB.Models;
using ParabolaDB.Services;
using ParabolaDB.Attributes;

namespace ParabolaDB.Controllers
{
    public class HomeController : Controller
    {
        ParabolaContext db = new ParabolaContext();

        public ActionResult Index(Param par)
        {
            FunctCalc.GeneratePoints(par, db);
            return View(par);
        }

        public JsonResult GetPointsJson()
        {
            return Json(FunctCalc.getPoints(), JsonRequestBehavior.AllowGet);
        }

    }
}