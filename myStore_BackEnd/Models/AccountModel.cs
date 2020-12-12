using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myStore_BackEnd.Models
{
    public class AccountModel
    {
        public int id_user { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string user_avatar { get; set; }
        public int user_level { get; set; }

        public string getLogin(string uid, string pwd)
        {
            string myLevel = "";
            mystoreEntities db = new mystoreEntities();

            var user = db.users.Where(a => a.user_id.Equals(uid) && a.user_pass.Equals(pwd)).FirstOrDefault();

            if (user != null)
            {
                if (user.user_level == 0)
                {
                    myLevel = "Administrator";
                }
                else if (user.user_level == 1)
                {
                    myLevel = "Staf";
                }
                else
                {
                    myLevel = "User";
                }
            }

            return myLevel;
        }
    }
}