using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WebApplication4.Models
{
    public class LoginService
    {
        public User AdminLogin(User objAdmin)
        {
            string sid = objAdmin.sid;
            string skey = objAdmin.skey;
            string sql = "select sid from people where sid='" + sid + "'and skey='" + skey + "'";

            OracleDataReader objReader = OracleHelper.GetReader(sql);
            if (!objReader.Read())
            {
                objAdmin = null;
            }
            return objAdmin;
        }
    }
}