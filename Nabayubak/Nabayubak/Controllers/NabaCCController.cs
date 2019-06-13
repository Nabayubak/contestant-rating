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
    public class NabaCCController : Controller
    {
        [HttpGet]
        public ActionResult Shift1()
        {
            {
                ViewBag.N = Transfer.Getlist1();
                ViewBag.A = Transfer.Getlist2();
            }

            return View();

        }
        //[HttpPost]
        //public ActionResult Shift1(int id, int Namae1Id, int Namae2Id, string Name1, string Name2)
        //{
        //    var obj = Transfer.Shift12(id, Namae1Id, Namae2Id, Name1, Name2);
        //    return Json(obj, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult button2(int[] id)
        {
            var obj = Transfer.button2(id);
            return Json(obj, JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public ActionResult button1(int[] id)
        {
            var obj = Transfer.button1(id);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public ActionResult GetAlltable2 ()
        //{
        //    var obj = Transfer.GetAlltable2();
        //    return Json(obj, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public ActionResult GetAlltable1()
        //{
        //    var obj = Transfer.GetAlltable1();
        //    return Json(obj, JsonRequestBehavior.AllowGet);
        //}
	}
	}

