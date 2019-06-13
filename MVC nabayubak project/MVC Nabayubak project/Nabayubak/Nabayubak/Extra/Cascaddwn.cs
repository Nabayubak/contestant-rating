using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nabayubak.Models;

namespace Nabayubak.Extra
{
    public class Cascaddwn
    {
        public static object Cascadedropdownclasslist()
        {
            List<CSMAP> MAP = new List<CSMAP>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Classname.ToList();

                foreach (var item in obj)
                {
                    CSMAP ad = new CSMAP();
                    ad.Classid = item.ClassId;
                    ad.Class = item.Class;

                    MAP.Add(ad);
                }
            }
            return MAP;

        }
        public static object Maplist()
        {
            List<CSMAP> MAP = new List<CSMAP>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Class_section_MAP.Join(db.Classname, x => x.ClassId, y => y.ClassId, (x, y) => new
                {
                    x.ClassId,
                    y.Class,
                   x.Id,
                   x.Section,
                   x.SectionId,
                }).ToList();

                foreach (var item in obj)
                {
                    CSMAP ad = new CSMAP();
                    ad.Classid = item.ClassId;
                    ad.Class = item.Class;
                    ad.Id = item.Id;
                    ad.Section = item.Section;
                    ad.Sectionid = item.SectionId;

                    MAP.Add(ad);
                }
            }
            return MAP;

        }
        public static object Section()
        {
            List<CSMAP> MAP = new List<CSMAP>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Sectionname.ToList();

                foreach (var item in obj)
                {
                    CSMAP ad = new CSMAP();
                    ad.Sectionid = item.SectionId;
                    ad.Section = item.Section;

                    MAP.Add(ad);
                }
            }
            return MAP;

        }
        public static object Cascadedropdownsectionlist(int Classid)
        {
            List<CSMAP> MAP = new List<CSMAP>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Class_section_MAP.Where(x=>x.ClassId == Classid).ToList();

                foreach (var item in obj)
                {
                    CSMAP ad = new CSMAP();
                    ad.Id = item.Id;
                    ad.Classid = item.ClassId;
                    ad.Section = item.Section;
                    ad.Sectionid = item.SectionId;
                   

                    MAP.Add(ad);
                }
            }
            return MAP;
        }
        public static object Sectionlistbtn2(int Classid)
        {
            List<CSMAP> MAP = new List<CSMAP>();
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.Class_section_MAP.Where(x => x.ClassId == Classid).ToList();

                foreach (var item in obj)
                {
                    CSMAP ad = new CSMAP();
                    ad.Id = item.Id;
                    ad.Classid = item.ClassId;
                    ad.Section = item.Section;
                    ad.Sectionid = item.SectionId;


                    MAP.Add(ad);
                }
            }
            return MAP;
        }
    }
}