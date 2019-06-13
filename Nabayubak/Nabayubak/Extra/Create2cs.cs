using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nabayubak.Models;
using Nabayubak.Extra;
using System.IO;

namespace Nabayubak.Extra
{
    public class Create2cs
    {
        public object DistrictList()
        {
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Districts.ToList();
                return obj;
            }
        }
        public static object ContestantDetailList()
        {
            List<Naba1> NAB = new List<Naba1>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Contestants.Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
                {
                    x.Id,
                    x.Firstname,
                    x.Lastname,
                    x.Gender,
                    y.Name,
                    x.DateOfBirth
                }).ToList();

                foreach (var item in obj)
                {
                    Naba1 cd = new Naba1();
                    cd.ConstantId = item.Id;
                    cd.FullName = item.Firstname + " " + item.Lastname;
                    cd.DateOfBirth = item.DateOfBirth.Value.ToShortDateString();
                    cd.District = item.Name;
                    cd.Gender = item.Gender;
                    NAB.Add(cd);
                }

                return NAB;
            }
        }
        public static object Create2(string mode, int contestantid, string firstname, string lastname, DateTime dob, bool active, int district, string gender)
        {
            List<Contestant> NAB = new List<Contestant>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                if (mode == "InsertMode")
                {

                    Contestant obj = new Contestant();
                    obj.Firstname = firstname;
                    obj.Lastname = lastname;
                    obj.DateOfBirth = dob;
                    obj.IsActive = active;
                    obj.DistrictId = district;
                    obj.Gender = gender;
                    db.Contestants.Add(obj);
                    db.SaveChanges();
                    


                    return NAB;
                }
                else
                {

                    return ContestantDetailList();
                }
            }
        }      
}
}