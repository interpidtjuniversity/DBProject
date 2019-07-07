using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApplication4.Models.DBAttribute;

namespace WebApplication4.Models
{

    [DBTable("people")]
    public class User
    {
        [DBPrimaryKey("sid")]
        [DBMember("sid")]
        [Display(Name = "账号")]
        public string sid { get; set; }

        [DBMember("skey")]
        [Display(Name ="密码")]
        public string skey { get; set; }

        [DBMember("rem_check")]
        [Display(Name ="是否为会员")]
        public int rem_check { get; set; }

        public User(string id, string pwd,int rc)
        {
            sid = id;
            skey = pwd;
            rem_check = rc;
        }
        public User() { }
    }
}