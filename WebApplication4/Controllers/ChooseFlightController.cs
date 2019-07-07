using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ChooseFlightController : Controller
    {
        private static List<Flight> Flights;
        // GET: ChooseSeat
        public ActionResult ChooseFlight()
        {
            ShowFlight();
            return View();
        }

        public ActionResult ShowFlight()
        {
            Flights = new List<Flight>();
            Flight obj = new Flight();
            SelectReturn sr = DataBaseAccess.GetAllTInfo(obj);
            List<object> list = sr.list;//object
            List<string> value = sr.value;//值
            //object转Flight
            int flag = 0;   //游标
            foreach (object j in list)
            {
                Flight flight = new Flight();//current
                //手动赋值,暂时没有找到映射的方法
                flight.Flight_ID = value[flag++];
                flight.Plane_ID = value[flag++];
                flight.Max_Capacity = int.Parse(value[flag++]);
                flight.Reserve_Num = int.Parse(value[flag++]);
                flight.Pass_Security_Inspection_Num = int.Parse(value[flag++]);
                flight.Boarding_Num = int.Parse(value[flag++]);
                flight.Price = int.Parse(value[flag++]);
                flight.Max_Baggage_Weight = int.Parse(value[flag++]);
                Flights.Add(flight);
                /*
                JsonSerializer jsonlist = new JsonSerializer();
                StringWriter sw = new StringWriter();
                jsonlist.Serialize(new JsonTextWriter(sw), j);
                string result = sw.GetStringBuilder().ToString();
                MessageBox.Show(result[0].ToString());
                */
            }
            //jsonlist.Serialize(new JsonTextWriter(sw), list);
            //string result = sw.GetStringBuilder().ToString();             //list转化为JSON
            //return Content(result);
            return View("ChooseFlight", Flights);
        }

        public ActionResult GetFlightInfo(string id,int capacity)
        {
            //需要在此函数中传回一个数组,为了方便先传递一个list
            Seat obj = new Seat(id);     //定义Flight_ID为id的航班上的一个座位
            List<string> needs = new List<string>();    //查询的数据需求,此处时座位号
            needs.Add("Seat_Number");
            List<string> res = new List<string>();     //查询结果
            res = DataBaseAccess.GetSingleInfo(obj, needs);      //已经办理过登机牌的顾客的座位号用List返回

            int[] SeatArray = new int[capacity];
            for (int i = 0; i < capacity; i++)        //初始化
            {
                SeatArray[i] = int.MinValue;
            }
            for (int i = 0; i < res.Count; i++)
            {
                SeatArray[int.Parse(res[i]) - 1] = 0;
            }
            FlightSelectReturn data = new FlightSelectReturn(SeatArray, id);
            return View("Flight", data);
        }

        public ActionResult ReceiveMsg()
        {
            //获取当前飞机ID
            string Current_Flight_ID = Request.Params["current_flight"];
            //从这里将座位信息插入 Seating_Chart   座位号
            int Pickrt = int.Parse(Request.Params["result"]);
            //航班ID   Current_Flight_ID
            //顾客ID   从页面传来
            string Current_Customer_ID = Request.Params["Customer_ID"];
            //座位状态,还没有就坐默认为0

            Seat obj = new Seat(Current_Flight_ID, Pickrt, Current_Customer_ID, 0);
            DataBaseAccess.insertObj(obj);
            return View("ChooseFlight", Flights);
        }
    }
}