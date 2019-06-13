using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nabayubak.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
    }
}