using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class UserListController : Controller
    {
    //    [assembly: Dependency("UserRepository",LoadHint.Default)]
        public UserRepository Repository { get; set;}

        // GET: Users
        /*
        public ActionResult UserList()
        {
            return View();
        }
        */
        public ActionResult UserList()
        {
            Repository = new UserRepository();
            var users = this.Repository.GetUsers();
            return View("UserList", users);
        }

        public ActionResult GetUserById(string id)
        {
            Repository = new UserRepository();
            User user = this.Repository.GetUsers(id).FirstOrDefault();
            if (null == user)
            {
                throw new HttpException(404, string.Format("sid为{0}的员工不存在", id));
            }
            return View("User", user);
        }
    }
}