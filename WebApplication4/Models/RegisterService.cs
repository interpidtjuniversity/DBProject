using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace WebApplication4.Models
{
    public class RegisterService
    {
        public User UserCheck(User objcheck)
        {
            string sid = objcheck.sid;
            string sql = "select sid from people where sid='" + sid + "'";

            OracleDataReader objReader = OracleHelper.GetReader(sql);
            if (!objReader.Read())
            {
                objcheck = null;
            }
            return objcheck;
        }
    }
}