using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Nabayubak.Models
{
    public class Naba2
    {
        public int Id { get; set; }
        public int ConstantId { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [DisplayName("Date of Birth")]
        public string Dateofbirth { get; set; }
        public string District { get; set; }
        [DisplayName("Average Rating")]
        public decimal Averagerating { get; set; }
        public string Gender { get; set; }
        public bool? IsActive { get; set; }
        public int Rating { get; set; }
        public decimal Rate { get; set; }
        public DateTime? Fromdate{get; set;}
        public DateTime? Todate{get; set;}
        [DisplayName ("Rater count")]
        public int Ratercount { get; set;}

    }
}