using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nabayubak.Models;



namespace Nabayubak.Extra
{
    public class Rate
    {   
        public static object Delete(int id)
        {
            List<Naba2> NAB = new List<Naba2>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Contestants.Where(x=> x.Id==id).Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
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
            }
            return NAB;

        }
        public static object ConstantRating1(int id)
        {
            List<Naba2> Clist = new List<Naba2>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {

                var obj = db.Contestants.Find(id);
                int? districtId = obj.DistrictId;
                return obj;
            }
            }
        
        public static object ConstantwithRating()
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
                    decimal sum = 0;
                    decimal count = 0;
                    var CheckContestent = db.ContestantRatings.Where(x => x.ContestantId == item.Id).Count();
                    if (CheckContestent > 0)
                    {{
                        sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Select(x => x.Rating).ToList().Sum());
                        count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Count());
                    }
                        decimal AverageRate = Convert.ToDecimal(sum / count);
                        int Ratercount = CheckContestent;
                        Naba2 ad = new Naba2();
                        ad.ConstantId = item.Id;
                        ad.District = item.Name;
                        ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                        ad.FullName = item.Firstname + " " + item.Lastname;
                        ad.Gender = item.Gender;
                        ad.IsActive = item.IsActive;
                        ad.Averagerating = AverageRate;
                        ad.Ratercount = Ratercount;

                        NAB.Add(ad);
                    }
                    else if (CheckContestent == 0)
                    {
                        int Ratercount = CheckContestent;
                        Naba2 ad = new Naba2();
                        ad.ConstantId = item.Id;
                        ad.District = item.Name;
                        ad.Dateofbirth= item.DateOfBirth.Value.ToShortDateString();
                        ad.FullName = item.Firstname + " " + item.Lastname;
                        ad.Gender = item.Gender;
                        ad.IsActive = item.IsActive;
                        ad.Averagerating = 0;
                        ad.Ratercount = Ratercount;

                        NAB.Add(ad);
                    }
                }
            }
            return NAB;
        }
        public static object ConstantwithRating(String searchBy, DateTime Fromdate, DateTime Todate, string Gender, bool? IsActive, string search)
        {
            List<Naba2> NAB = new List<Naba2>();
            try {
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            
            
                if (searchBy == "Gender" && IsActive == true)
                {
                    var ContestantList = db.Contestants.Where(x => x.Gender == Gender && x.IsActive == IsActive).Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
                           {
                               x.Id,
                               x.Firstname,
                               x.Lastname,
                               x.DateOfBirth,
                               x.Gender,
                               x.IsActive,
                               y.Name,
                               

                           })
                           .ToList();

                    foreach (var item in ContestantList)
                    {
                        DateTime fromdate = Fromdate.Date;
                        DateTime todate = Todate.Date;
                        decimal sum = 0;
                        decimal count = 0;
                        var CheckContestent = db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count();
                        if (CheckContestent > 0)
                        {
                            if ( Fromdate != null && Todate != null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count());

                            }
                            else if (Fromdate != null && Todate == null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Count());
                            }
                            else if (Fromdate == null && Todate != null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Count());
                            }
                            else
                            {
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Count());
                            }
                            decimal AverageRate = Convert.ToDecimal(sum / count);
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = AverageRate;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                        else if (CheckContestent == 0)
                        {
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = 0;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                    }
                }
            else if (searchBy == "Gender" && IsActive == false)
            {
                var ContestantList = db.Contestants.Where(x => x.Gender == Gender && x.IsActive == IsActive).Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
                {
                    x.Id,
                    x.Firstname,
                    x.Lastname,
                    x.DateOfBirth,
                    x.Gender,
                    x.IsActive,
                    y.Name,


                })
                       .ToList();

                foreach (var item in ContestantList)
                {
                    DateTime fromdate = Fromdate.Date;
                    DateTime todate = Todate.Date;
                    decimal sum = 0;
                    decimal count = 0;
                    var CheckContestent = db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count();
                    if (CheckContestent > 0)
                    {
                        if (Fromdate != null && Todate != null)
                        {
                            
                            sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                            count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count());

                        }
                        else if (Fromdate != null && Todate == null)
                        {
                            
                            sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Select(x => x.Rating).ToList().Sum());
                            count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Count());
                        }
                        else if (Fromdate == null && Todate != null)
                        {
                            
                            sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                            count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Count());
                        }
                        else
                        {
                            sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Select(x => x.Rating).ToList().Sum());
                            count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Count());
                        }
                        decimal AverageRate = Convert.ToDecimal(sum / count);
                        int Ratercount = CheckContestent;
                        Naba2 ad = new Naba2();
                        ad.ConstantId = item.Id;
                        ad.District = item.Name;
                        ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                        ad.FullName = item.Firstname + " " + item.Lastname;
                        ad.Gender = item.Gender;
                        ad.IsActive = item.IsActive;
                        ad.Averagerating = AverageRate;
                        ad.Ratercount = Ratercount;

                        NAB.Add(ad);
                    }
                    else if (CheckContestent == 0)
                    {
                        int Ratercount = CheckContestent;
                        Naba2 ad = new Naba2();
                        ad.ConstantId = item.Id;
                        ad.District = item.Name;
                        ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                        ad.FullName = item.Firstname + " " + item.Lastname;
                        ad.Gender = item.Gender;
                        ad.IsActive = item.IsActive;
                        ad.Averagerating = 0;
                        ad.Ratercount = Ratercount;

                        NAB.Add(ad);
                    }
                }
            }
                else if (searchBy == "Name" && IsActive == true)
                {
                    var ContestantList = db.Contestants.Where(x => x.Firstname.StartsWith(search) && x.IsActive == IsActive).Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
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
                        DateTime fromdate = Fromdate.Date;
                        DateTime todate = Todate.Date;
                        decimal sum = 0;
                        decimal count = 0;
                        var CheckContestent = db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count();
                        if (CheckContestent > 0)
                        {
                            if (Fromdate != null && Todate != null)
                            {
                              
                               
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count());

                            }
                            else if (Fromdate != null && Todate == null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Count());
                            }
                            else if (Fromdate == null && Todate != null)
                            {
                               
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Count());
                            }
                            else
                            {
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Count());
                            }
                            decimal AverageRate = Convert.ToDecimal(sum / count);
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = AverageRate;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                        else if (CheckContestent == 0)
                        {
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = 0;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                    }
                }
                else if (searchBy == "Name" && IsActive == false)
                {
                    var ContestantList = db.Contestants.Where(x => x.Firstname.StartsWith(search) && x.IsActive == IsActive).Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
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
                        DateTime fromdate = Fromdate.Date;
                        DateTime todate = Todate.Date;
                        decimal sum = 0;
                        decimal count = 0;
                        var CheckContestent = db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count();
                        if (CheckContestent > 0)
                        {
                            if (Fromdate != null && Todate != null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count());

                            }
                            else if (Fromdate != null && Todate == null)
                            {
                               
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Count());
                            }
                            else if (Fromdate == null && Todate != null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Count());
                            }
                            else
                            {
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id).Count());
                            }
                            decimal AverageRate = Convert.ToDecimal(sum / count);
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = AverageRate;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                        else if (CheckContestent == 0)
                        {
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = 0;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                    }
                }
                else if (Fromdate != null && Todate != null && IsActive == true)
                    {
                        
                            var ContestantList = db.Contestants.Where(x => x.IsActive == IsActive).Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
                                   {
                                       x.Id,
                                       x.Firstname,
                                       x.Lastname,
                                       x.DateOfBirth,
                                       x.Gender,
                                       x.IsActive,
                                       y.Name,


                                   })
                                   .ToList();
                        
                           
                        

                    foreach (var item in ContestantList)
                    {
                        DateTime fromdate = Fromdate.Date;
                        DateTime todate = Todate.Date;
                        decimal sum = 0;
                        decimal count = 0;
                        var CheckContestent = db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count();
                        if (CheckContestent > 0)
                        {
                            if ( Fromdate !=null && Todate !=null)
                            {
                               
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count());

                            }
                            else if (Fromdate != null && Todate == null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Count());
                            }
                            else if (Fromdate == null && Todate != null)
                            {
                               
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Count());
                            }
                           
                            decimal AverageRate = Convert.ToDecimal(sum / count);
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = AverageRate;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                        else if (CheckContestent == 0)
                        {
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = 0;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                    }
                }
                else if (Fromdate != null && Todate != null && IsActive == false)
                {
                    var qab = db.ContestantRatings.Where(x => x.RateDate >= Fromdate && x.RateDate <= Todate).ToList();
                    var ContestantList = db.Contestants.Where(x => x.IsActive == IsActive).Join(db.Districts, x => x.DistrictId, y => y.Id, (x, y) => new
                    {
                        x.Id,
                        x.Firstname,
                        x.Lastname,
                        x.DateOfBirth,
                        x.Gender,
                        x.IsActive,
                        y.Name,


                    })
                           .ToList();

                    foreach (var item in ContestantList)
                    {
                        DateTime fromdate = Fromdate;
                        DateTime todate = Todate;
                        decimal sum = 0;
                        decimal count = 0;
                        var CheckContestent = db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count();
                        if (CheckContestent > 0)
                        {
                            if (Fromdate != null && Todate != null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate && x.RateDate <= todate).Count());

                            }
                            else if (Fromdate != null && Todate == null)
                            {
                               
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate >= fromdate).Count());
                            }
                            else if (Fromdate == null && Todate != null)
                            {
                                
                                sum = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Select(x => x.Rating).ToList().Sum());
                                count = Convert.ToDecimal(db.ContestantRatings.Where(x => x.ContestantId == item.Id && x.RateDate <= todate).Count());
                            }

                          decimal AverageRate = Convert.ToDecimal(sum / count);
                                int Ratercount = CheckContestent;
                                Naba2 ad = new Naba2();
                                ad.ConstantId = item.Id;
                                ad.District = item.Name;
                                ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                                ad.FullName = item.Firstname + " " + item.Lastname;
                                ad.Gender = item.Gender;
                                ad.IsActive = item.IsActive;
                                ad.Averagerating = AverageRate;
                                ad.Ratercount = Ratercount;

                                NAB.Add(ad);
                            
                        }
                        else if (CheckContestent == 0)
                        {
                            int Ratercount = CheckContestent;
                            Naba2 ad = new Naba2();
                            ad.ConstantId = item.Id;
                            ad.District = item.Name;
                            ad.Dateofbirth = item.DateOfBirth.Value.ToShortDateString();
                            ad.FullName = item.Firstname + " " + item.Lastname;
                            ad.Gender = item.Gender;
                            ad.IsActive = item.IsActive;
                            ad.Averagerating = 0;
                            ad.Ratercount = Ratercount;

                            NAB.Add(ad);
                        }
                    }
                }
                
                return NAB;
        }
            catch(Exception)
            {
                return 0;
            }
            }
        public static object RateConstant(int id, int rate)
        {
            var date = "";
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var a = DateTime.Now;
                var b = DateTime.Today;
                var c = DateTime.Today.ToShortDateString();
                var d = DateTime.Today.ToString("yyyy-MM-dd");
                ContestantRating ins = new ContestantRating();
                ins.ContestantId = id;
                ins.RateDate = DateTime.Today;
                ins.Rating = rate;
                db.ContestantRatings.Add(ins);
                db.SaveChanges();
                return ConstantwithRating();
            }
        }



        }

       
    }
