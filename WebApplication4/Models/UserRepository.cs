using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace WebApplication4.Models
{
    public class UserRepository 
    {
        private static IList<User> Users;

        public IEnumerable<User> GetUsers(string id = "")
        {
            return Users.Where(e => e.sid == id || string.IsNullOrEmpty(id));
        }

        static UserRepository()
        {
            Users = new List<User>();

            Users.Add(new User("worinima", "89789", 1));
            Users.Add(new User("nimasile", "69857", 0));
            Users.Add(new User("wodiaonimade", "123456", 1));
        }
    }
}