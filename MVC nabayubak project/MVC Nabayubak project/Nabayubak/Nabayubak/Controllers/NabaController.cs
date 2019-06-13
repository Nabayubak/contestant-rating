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
    public class NabaController : Controller
    {
        Create2cs CM = new Create2cs();
        public ActionResult Index()
        {
            ViewBag.DistrictList = CM.DistrictList();
            ViewBag.ContestantList = Create2cs.ContestantDetailList();
            return View();
            //List<Naba1> Clist = new List<Naba1>();
            //using (NabayubakDBEntities db = new NabayubakDBEntities())
            //{
            //    var obj = db.Contestants.Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
            //    {
            //        x.Id,
            //        x.Firstname,
            //        x.Lastname,
            //        x.Gender,
            //        y.Name,
            //        x.DateOfBirth
            //    }).ToList();

            //    foreach (var item in obj)
            //    {
            //        Naba1 cd = new Naba1();
            //        cd.ConstantId = item.Id;
            //        cd.FullName = item.Firstname + " " + item.Lastname;
            //        cd.DateOfBirth = item.DateOfBirth.Value.ToShortDateString();
            //        cd.District= item.Name;
            //        cd.Gender = item.Gender;
            //        Clist.Add(cd);
            //    }
            //    ViewBag.ok = Clist.ToList();

            //    return View();
            //}
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    using (NabayubakDBEntities db = new NabayubakDBEntities())
        //    { 
        //        ViewBag.Districtslist = db.Districts.ToList(); 
        //    }
        //    return View();
        //}
      
        //[HttpPost]
        //public ActionResult Create(Contestant a)
        //{       
        //    try
        //        {
        //            using (NabayubakDBEntities db = new NabayubakDBEntities())
        //            {
        //                Contestant obj = new Contestant();
        //                obj.Firstname = a.Firstname;
        //                obj.Lastname = a.Lastname;
        //                obj.DateOfBirth = a.DateOfBirth;
        //                obj.IsActive = a.IsActive;
        //                obj.DistrictId = a.DistrictId;
        //                obj.Gender = a.Gender;
        //                db.Contestants.Add(obj);
        //                db.SaveChanges();
        //            }
        //        }
        //        catch (Exception ex) 
        //        { }
        //        return RedirectToAction("Index");
            
            
        //}
        [HttpGet]
        public ActionResult Create12()
        {
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                ViewBag.Districtslist = db.Districts.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create2(string mode, int contestantid, string firstname, string lastname, DateTime dob, bool active, int district, string gender)
        {
            var obj = Create2cs.Create2(mode, contestantid, firstname, lastname, dob, active, district, gender);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Contestant con = new Contestant();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                con = db.Contestants.Find(id);
                int? districtId = con.DistrictId;
             
                ViewBag.Districtslist = db.Districts.ToList().Select(x => new SelectListItem{Value = x.Id.ToString(),Text = x.Name,Selected = (x.Id == 1)});
                //ViewBag.Districtslist = db.Districts.ToList();
                if (con == null)
                {
                    return HttpNotFound();
                }
               // return View(con);
            }
            return View(con);
        }

        [HttpPost]
        public ActionResult Edit(Contestant a, int Id)
        {
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var edit = db.Contestants.Where (x => x.Id == Id).FirstOrDefault();
                edit.Firstname = a.Firstname;
                edit.Lastname = a.Lastname;
                edit.DateOfBirth = a.DateOfBirth;
                edit.IsActive = a.IsActive;
                edit.DistrictId = a.DistrictId;
                edit.Gender = a.Gender;
                db.SaveChanges();

                // for delete
                //var delete = db.Contestants.Where (x => x.Id == Id).FirstOrDefault();
                // db.Contestants.Remove(delete);
                // db.SaveChanges();                  
               
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
       public ActionResult Delete (int id)
        
            {
                var obj = Rate.Delete(id);
                return View(obj);
            }
        
        [HttpPost]
        public ActionResult Delete(int? Id = 0)
        {
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var delete = db.Contestants.Where(x => x.Id == Id).FirstOrDefault();
                db.Contestants.Remove(delete);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ConstantRating()
        {
            var obj = Rate.ConstantwithRating();
            return View(obj);
        }

        [HttpPost]
        //public ActionResult ConstantRating(String searchBy, String search, String Gender)
        public ActionResult ConstantRating(Naba2 OBJ, String searchBy, DateTime Fromdate, DateTime Todate, string search)
        {
            //var obj = Rate.ConstantwithRating(search, search, Gender);
            var obj = Rate.ConstantwithRating(searchBy, Fromdate, Todate, OBJ.Gender, OBJ.IsActive, search);
            return View(obj);
        }
        [HttpGet]
        public ActionResult Rating(int id= 0)

        {
            var obj = Rate.ConstantRating1(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult RateConstant(int id, int rate)
        {
            try { 
                var obj = Rate.RateConstant(id, rate);

                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {

                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SavePhoto(HttpPostedFileBase filea, int constantid)
        {

            if (filea != null && filea.ContentLength > 0)
            {
                //file name lera aako
                var fileName = Path.GetFileName(filea.FileName);
                //file save garne path
                var path = Path.Combine(Server.MapPath("~/Photos"), constantid + fileName);
                filea.SaveAs(path);
                var imagepath = "/Photos/";
                 using (NabayubakDBEntities db = new NabayubakDBEntities())
                {
                    var stdPhoto = db.Contestants.Where(x => x.Id == constantid).FirstOrDefault();
                    stdPhoto.PhotoUrl = imagepath + constantid + fileName;
                    db.SaveChanges();

                }
            }

            return View();
        }
    }
	
}