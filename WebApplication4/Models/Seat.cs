using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApplication4.Models.DBAttribute;

namespace WebApplication4.Models
{
    [DBTable("Seating_Chart")]
    public class Seat
    {
        [DBPrimaryKey("Flight_ID")]
        [DBMember("Flight_ID")]
        [Display(Name = "航班ID")]
        public string Flight_ID { get; set; }

        [DBMember("Seat_Number")]
        [Display(Name = "座位号")]
        public int Seat_Number { get; set; }

        [DBPrimaryKey("Customer_ID")]
        [DBMember("Customer_ID")]
        [Display(Name = "客户ID")]
        public string Customer_ID { get; set; }

        [DBMember("Seat_State")]
        [Display(Name = "座位状态")]
        public int Seat_State { get; set; }

        public Seat(string fid)
        {
            Flight_ID = fid;
        }
        public Seat(string fd, int sn, string cd, int ss)
        {
            Flight_ID = fd;
            Seat_Number = sn;
            Customer_ID = cd;
            Seat_State = ss;
        }
        public Seat() { }
    }
}