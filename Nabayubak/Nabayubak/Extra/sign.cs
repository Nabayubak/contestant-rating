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
    public class sign
    {
        public static object Userlist()
        {
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                var obj = db.SignUp.ToList();
                return obj;
            }
        }
        public static bool Login1(string Username, string Password)
        {
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {

                var loginresult = db.SignUp.Where(s => s.Username == Username && s.Password == Password).FirstOrDefault();

                if (loginresult != null)
                {
                    if (Password == loginresult.Password.ToString())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }
            }
        }
    
   
        public static object signup2(string Firstname, string Lastname, string Username, string Password,DateTime Birthday, string Gender)
        {
            
            using (NabayubakDBEntities db = new NabayubakDBEntities())
            {
                
                {
                    SignUp obj = new SignUp();
                    obj.Firstname = Firstname;
                    obj.Lastname = Lastname;
                    obj.Username = Username;
                    obj.Password = Password;
                    obj.Birthday = Birthday;
                    obj.Gender = Gender;
                    db.SignUp.Add(obj);
                    db.SaveChanges();
                    return obj;
                }


          
                
               
            }
        }
    }
}