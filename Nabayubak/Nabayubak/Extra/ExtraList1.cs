using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nabayubak.Models;

namespace Nabayubak.Extra
{
    public class ExtraList1
    {
        public static object ContestantDetails()
        {
            List<Naba2> NAB = new List<Naba2>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Contestants.Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
                {
                    x.Id,
                    x.Firstname,
                    x.Lastname,
                    x.Gender,
                    y.Name,
                    x.DateOfBirth,
                    x.IsActive
                }).ToList();

                foreach (var item in obj)
             {
                       
                        Naba2 ad = new Naba2();
                        ad.ConstantId = item.Id;
                        ad.District = item.Name;
                        ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                        ad.FullName = item.Firstname + " " + item.Lastname;
                        ad.Gender = item.Gender;
                        ad.IsActive = item.IsActive;
                       NAB.Add(ad);
                    }
                return NAB;
                }

            }
        public static object GetAllContestant()
        {
            List<Naba2> NAB = new List<Naba2>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Contestants.Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
                {
                    x.Id,
                    x.Firstname,
                    x.Lastname,
                    x.Gender,
                    y.Name,
                    x.DateOfBirth,
                    x.IsActive
                }).ToList();

                foreach (var item in obj)
                {

                    Naba2 ad = new Naba2();
                    ad.ConstantId = item.Id;
                    ad.District = item.Name;
                    ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                    ad.FullName = item.Firstname + " " + item.Lastname;
                    ad.Gender = item.Gender;
                    ad.IsActive = item.IsActive;
                    NAB.Add(ad);
                }
                return NAB;
            }

        }
        
    public static object ContestantDetails(Naba2 a, string FullName) 
    { 
        List<Naba2> NAB = new List<Naba2>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
       
        {
            var ContestantList = db.Contestants.Where(x => x.Firstname.StartsWith(FullName)).Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
                    {
                        x.Id,
                        x.Firstname,
                        x.Lastname,
                        x.DateOfBirth,
                        x.Gender,
                        x.IsActive,
                        y.Name

                    })
                           .ToList();

                    foreach (var item in ContestantList)
               {
                    Naba2 ad = new Naba2();
                    ad.ConstantId = item.Id;
                    ad.District = item.Name;
                    ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                    ad.FullName = item.Firstname + " " + item.Lastname;
                    ad.Gender = item.Gender;
                    ad.IsActive = item.IsActive;
                    NAB.Add(ad);
                }
            return NAB;
            }

            }         
}
            
        }

    
