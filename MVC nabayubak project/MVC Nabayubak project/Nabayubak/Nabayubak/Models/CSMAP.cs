using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nabayubak.Models
{
    public class CSMAP
    {
        public int Id { get; set; }
        public Nullable<int> Classid { get; set; }
        public Nullable<int> Sectionid { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
    }
}