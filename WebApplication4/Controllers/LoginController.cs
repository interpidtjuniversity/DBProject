using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using System.Windows.Forms;

namespace WebApplication4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Home()
        {
            //[1] 获取数据
            string loginId = Request.Params["LoginId"];
            string loginpwd = Request.Params["Loginpwd"];//接受form提交的数据
            User objAdmin = new User()
            {
                sid = loginId,
                skey = loginpwd
            };//对象初始化器（对属性赋值）
            //[2] 业务处理  调用数据访问类   使用数据访问类中的方法
            objAdmin = new LoginService().AdminLogin(objAdmin);
            if (objAdmin != null)
            {
                ViewData["info"] = "欢迎登录！" + objAdmin.sid;
                return Redirect("~/Home/Home");
            }
            else
            {
                ViewData["info"] = "用户名或密码错误";
                return View("Login");
            }
        }
    }
}