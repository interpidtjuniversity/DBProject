using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApplication4.Models.DBAttribute;

namespace WebApplication4.Models
{
    [DBTable("Flight_Chart")]
    public class Flight
    {
        [DBPrimaryKey("Flight_ID")]
        [DBMember("Flight_ID")]
        [Display(Name = "航班ID")]
        public string Flight_ID { get; set; }

        [DBMember("Plane_ID")]
        [Display(Name = "飞机ID")]
        public string Plane_ID { get; set; }

        [DBMember("Max_Capacity")]
        [Display(Name = "最大容量")]
        public int Max_Capacity { get; set; }

        [DBMember("Reserve_Num")]
        [Display(Name = "预订人数")]
        public int Reserve_Num { get; set; }

        [DBMember("Pass_Security_Inspection_Num")]
        [Display(Name = "过安检人数")]
        public int Pass_Security_Inspection_Num { get; set; }

        [DBMember("Boarding_Num")]
        [Display(Name = "登机时人数")]
        public int Boarding_Num { get; set; }

        [DBMember("Price")]
        [Display(Name = "价格")]
        public int Price { get; set; }

        [DBMember("Max_Baggage_Weight")]
        [Display(Name = "最大行李重量")]
        public int Max_Baggage_Weight { get; set; }


        public Flight(string fid,string pid,int capacity,int rn,int psin,int bn,int price,int mbw)
        {
            Flight_ID = fid;
            Plane_ID = pid;
            Max_Capacity = capacity;
            Reserve_Num = rn;
            Pass_Security_Inspection_Num = psin;
            Boarding_Num = bn;
            Price = price;
            Max_Baggage_Weight = mbw;
        }
        public Flight() { }
    }
}