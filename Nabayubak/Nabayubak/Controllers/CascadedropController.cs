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
    public class CascadedropController : Controller
    {

        [HttpGet]
        public ActionResult Cascadedropdown()
        {
            {
                ViewBag.List1 = Cascaddwn.Cascadedropdownclasslist();
                ViewBag.List2 = Cascaddwn.Section();
                ViewBag.List3 = Cascaddwn.Maplist();
            }
            return View();

        }
        [HttpPost]
        public JsonResult Getsectionlist(int Classid)
        {
            var obj = Cascaddwn.Cascadedropdownsectionlist(Classid);
            return Json(obj, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Sectionlistbtn(int Classid)
        {
            var obj = Cascaddwn.Sectionlistbtn2(Classid);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}