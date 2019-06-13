using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nabayubak.Models;
using Nabayubak.Extra;
using System.IO;

namespace Nabayubak.Controllers
{
    public class NabaCController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            {
                var obj = ExtraList1.ContestantDetails();
                return View(obj);
            }
        }
        [HttpPost]
        public ActionResult List(Naba2 a, string FullName)
        {
            var obj = ExtraList1.ContestantDetails(a, FullName);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetAllContestant()
    {
        var obj = ExtraList1.GetAllContestant();
        return Json(obj, JsonRequestBehavior.AllowGet);
    }
	}
}