using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nabayubak.Models;

namespace Nabayubak.Extra
{
    public class Transfer
    {
        public static object Getlist1()
        {
            List<NabaT12> NAB = new List<NabaT12>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Table_1.ToList();

                foreach (var item in obj)
                {
                    NabaT12 ad = new NabaT12();
                    ad.Id = item.Id;
                    ad.Name1 = item.Name1;
                    ad.Namae1Id = item.Name1Id;
                    NAB.Add(ad);
                }
            }
            return NAB;

        }

        public static object Getlist2()
        {
            List<NabaT12> NAB = new List<NabaT12>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Table_2.ToList();

                foreach (var item in obj)
                {
                    NabaT12 ad = new NabaT12();
                    ad.Id = item.Id;
                    ad.Name2 = item.Name2;
                    ad.Namae2Id = item.Name2Id;
                    NAB.Add(ad);
                }
            }
            return NAB;

        }
        public static object button2(int[] listOfIds)
        {
            List<NabaT12> NAB = new List<NabaT12>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                if (listOfIds.Length > 0)
                {
                    foreach (var id in listOfIds)
                    {
                        var list = db.Table_1.Where(x => x.Id == id).ToList();
                        Table_1 dataOfTable1 = list.FirstOrDefault();
                        Table_2 insertIntoTable2 = new Table_2();
                        insertIntoTable2.Name2 = dataOfTable1.Name1;
                        insertIntoTable2.Name2Id = id;
                        db.Table_2.Add(insertIntoTable2);
                        db.SaveChanges();

                        db.Table_1.Remove(dataOfTable1);
                        db.SaveChanges();
                    }
                }

                return db.Table_2.ToList();
            }

        }
        public static object button1(int[] listOfIds)
        {
            List<NabaT12> NAB = new List<NabaT12>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                if (listOfIds.Length > 0)
                {
                    foreach (var id in listOfIds)
                    {
                        var list = db.Table_2.Where(x => x.Id == id).ToList();
                        Table_2 dataOfTable1 = list.FirstOrDefault();
                        Table_1 insertIntoTable1 = new Table_1();
                        insertIntoTable1.Name1 = dataOfTable1.Name2;
                        insertIntoTable1.Name1Id = id;
                        db.Table_1.Add(insertIntoTable1);
                        db.SaveChanges();

                        db.Table_2.Remove(dataOfTable1);
                        db.SaveChanges();
                    }
                }

                return db.Table_1.ToList();
            }

        }
        //public static object GetAlltable2()
        //{
        //    List<Table2> NAB = new List<Table2>();
        //    using (NabayubakDBEntities db = new NabayubakDBEntities())
        //    {
        //        {
        //            var obj = db.Table_2.ToList();

        //            foreach (var item in obj)
        //            {
        //                Table2 ad = new Table2();
        //                ad.Id = item.Id;
        //                ad.Namae2Id = item.Name2Id;
        //                ad.Name2 = item.Name2;
        //                NAB.Add(ad);
        //            }
        //            return NAB;
        //        }
        //    }
        //}
        //        public static object GetAlltable1()
        //{
        //    List<Table1> NAB = new List<Table1>();
        //    using (NabayubakDBEntities db = new NabayubakDBEntities())
        //    {
        //        {
        //            var obj = db.Table_1.ToList();

        //            foreach (var item in obj)
        //            {
        //                Table1 ad = new Table1();
        //                ad.Id = item.Id;
        //                ad.Namae1Id = item.Name1Id;
        //                ad.Name1 = item.Name1;
        //                NAB.Add(ad);
        //            }
        //            return NAB;
        //        }

        //    }

        //}
    }
}

