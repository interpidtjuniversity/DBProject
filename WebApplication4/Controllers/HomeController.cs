using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication4.Models;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: MainHome1
        public ActionResult Home()
        {
            ShowUsers();
            return View();
        }

        public ActionResult ShowUsers()
        {
            User obj = new User();
            SelectReturn sr = DataBaseAccess.GetAllTInfo(obj);
            List<object> list = sr.list;
            JsonSerializer jsonlist = new JsonSerializer();
            StringWriter sw = new StringWriter();
            jsonlist.Serialize(new JsonTextWriter(sw), list);
            string result = sw.GetStringBuilder().ToString();             //list转化为JSON

            return Content(result);
        }

        
    }
}