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
    public class SignupController : Controller
    {
       [HttpGet]
        //public ActionResult Loginpage()
        //{
        //    var obj = sign.Userlist();
        //    return View(obj);
        //}
       public ActionResult Loginpage()
       {
           using (NabayubakDBEntities db = new NabayubakDBEntities())
           {
               ViewBag.Userlist = db.SignUp.ToList();
           }
           ViewBag.loginStatus = "jhghg";
           return View();
       }


       [HttpPost]
       public ActionResult Loginpage(string Username, string Password)
       {
           var obj = sign.Login1(Username, Password);
           if (obj == true)
           {
               return RedirectToAction("Profil");
           }
           else
           {
               using (NabayubakDBEntities db = new NabayubakDBEntities())
               {
                   ViewBag.Userlist = db.SignUp.ToList();
               }
               ViewBag.loginStatus = "False";
               return View();//RedirectToAction("Loginpage");
           }
           ViewBag.loginStatus = "False";
           return View();//RedirectToAction("Loginpage");
       }
       
        [HttpGet]
        public ActionResult signup()
       {
           return View();
       }
        [HttpPost]
        public ActionResult signup(string Firstname, string Lastname, string Username, string Password, DateTime Birthday, string Gender)
    {
        var obj = sign.signup2(Firstname, Lastname, Username, Password, Birthday, Gender);

        return RedirectToAction("Loginpage");
	}
        [HttpGet]
        public ActionResult Profil()
        {
            return View();
        }
}
    }